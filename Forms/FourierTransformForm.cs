using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using Paint.Classes;
using System.ComponentModel;

namespace Paint.Forms {
	public partial class FourierTransformForm : Form {
		private readonly MainForm mainForm;
		private readonly int resizedSize;
		private readonly DirectBitmap directBitmapResized;
		private readonly DirectBitmap directBitmapFourier;
		private readonly DirectBitmap directBitmapVisualisation;

		private Point center;
		private int filterMode;
		private int outerRadius;
		private int innerRadius;
		private readonly Color blackPixel = Color.FromArgb(255, 0, 0, 0);
		private readonly Color whitePixel = Color.FromArgb(255, 255, 255, 255);

		public FourierTransformForm(MainForm mainForm) {
			InitializeComponent();
			this.mainForm = mainForm;
			Closing += Form_Closing;

			DirectBitmap directBitmap = Layers.choosenLayer.directBitmapPictureBoxImage;
			resizedSize = GetResizedSize(directBitmap.Width, directBitmap.Height);
			Bitmap resizedBitmap = new Bitmap(directBitmap.Bitmap, resizedSize, resizedSize);
			directBitmapResized = new DirectBitmap(resizedBitmap);
			directBitmapFourier = new DirectBitmap(resizedSize, resizedSize);
			directBitmapVisualisation = new DirectBitmap(resizedSize, resizedSize);

			center = new Point((resizedSize - 1) / 2, (resizedSize - 1) / 2);
			pictureBoxResized.Image = directBitmapResized.Bitmap;
			pictureBoxFourier.Image = directBitmapFourier.Bitmap;
			pictureBoxVisualisation.Image = directBitmapVisualisation.Bitmap;

			trackBarOuterRadius.Maximum = (int) Math.Round(Math.Sqrt(Math.Pow(resizedSize / 2.0, 2.0) * 2.0));
			trackBarInnerRadius.Maximum = trackBarOuterRadius.Value - 1;
			numericUpDownOuterRadius.Maximum = trackBarOuterRadius.Maximum;
			numericUpDownInnerRadius.Maximum = trackBarInnerRadius.Maximum;

			comboBoxFilterMode.SelectedIndex = 0;
			checkBoxFilter.Checked = false;
			//VisabilityController();

		}

		private int GetResizedSize(int width, int height) {
			int max = Math.Max(width, height);

			int i = 1;
			while (Math.Pow(2, i) < max) {
				i++;
			}

			return (int) Math.Pow(2, i);
		}

		private Complex W(int k, int N) {
			if (k % N == 0) {
				return 1.0;
			}
			double arg = -2.0 * Math.PI * k / N;

			return new Complex(Math.Cos(arg), Math.Sin(arg));
		}

		private Complex[] OneDimensionalDiscreteFourierTransform(Complex[] x) {
			Complex[] G;
			int N = x.Length;

			if (N == 2) {
				G = new Complex[2];
				G[0] = x[0] + x[1];
				G[1] = x[0] - x[1];
			} else {
				Complex[] x_even = new Complex[N / 2];
				Complex[] x_odd = new Complex[N / 2];

				for (int i = 0; i < N / 2; i++) {
					x_even[i] = x[2 * i];
					x_odd[i] = x[(2 * i) + 1];
				}

				Complex[] X_even = OneDimensionalDiscreteFourierTransform(x_even);
				Complex[] X_odd = OneDimensionalDiscreteFourierTransform(x_odd);

				G = new Complex[N];

				for (int i = 0; i < N / 2; i++) {
					G[i] = X_even[i] + (W(i, N) * X_odd[i]);
					G[i + (N / 2)] = X_even[i] - (W(i, N) * X_odd[i]);
				}
			}

			return G;
		}

		private Complex[] InverseOneDimensionalDiscreteFourierTransform(Complex[] G) {
			int N = G.Length;
			double multiplier = 1.0 / N;
			Complex[] x = new Complex[N];

			for (int u = 0; u < N; u++) {
				for (int k = 0; k < N; k++) {
					double angle = 2.0 * Math.PI * u * k * multiplier;
					x[u] += new Complex(Math.Cos(angle), Math.Sin(angle)) * G[k];
				}
			}

			return x;
		}


		private void TwoDimensionalDiscreteFourierTransform() {
			Complex[,,] G = new Complex[resizedSize, resizedSize, 3];

			ParallelLoopResult unused_0 = Parallel.For(0, 3, colorChannel => {
				Complex[,] X_1 = new Complex[resizedSize, resizedSize];

				ParallelLoopResult unused_1 = Parallel.For(0, resizedSize, j => {
					double[] x = new double[resizedSize];

					ParallelLoopResult unused_2 = Parallel.For(0, resizedSize, i => {
						Color pixel = directBitmapResized.GetPixel(i, j);

						int color = 0;
						switch (colorChannel) {
							case 0:
								color = pixel.R;
								break;
							case 1:
								color = pixel.G;
								break;
							case 2:
								color = pixel.B;
								break;
						}

						double resultColor = color * Math.Pow(-1.0, j + i);
						x[i] = resultColor;
					});

					Complex[] complices = new Complex[resizedSize];
					ParallelLoopResult unused_3 = Parallel.For(0, resizedSize, i => complices[i] = new Complex(x[i], 0.0));

					Complex[] result = OneDimensionalDiscreteFourierTransform(complices);
					ParallelLoopResult unused_4 = Parallel.For(0, resizedSize, i => X_1[i, j] = result[i]);
				});

				ParallelLoopResult unused_5 = Parallel.For(0, resizedSize, i => {
					Complex[] complices = new Complex[resizedSize];
					ParallelLoopResult unused_6 = Parallel.For(0, resizedSize, j => complices[j] = X_1[i, j]);

					Complex[] result = OneDimensionalDiscreteFourierTransform(complices);
					ParallelLoopResult unused_7 = Parallel.For(0, resizedSize, j => G[i, j, colorChannel] = result[j]);
				});
			});

			if (checkBoxFilter.Checked) {
				ParallelLoopResult unused_8 = Parallel.For(0, resizedSize, j => {
					ParallelLoopResult unused_9 = Parallel.For(0, resizedSize, i => {
						switch (filterMode) {
							case 0:
								if (Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) > Math.Pow(outerRadius, 2.0)) {
									for (int k = 0; k < 3; k++) {
										G[i, j, k] = new Complex(0, 0);
									}
								}
								break;
							case 1:
								if (Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) < Math.Pow(outerRadius, 2.0)) {
									for (int k = 0; k < 3; k++) {
										G[i, j, k] = new Complex(0, 0);
									}
								}
								break;
							case 2:
								if ((Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) > Math.Pow(outerRadius, 2.0)) ||
									(Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) < Math.Pow(innerRadius, 2.0))) {
									for (int k = 0; k < 3; k++) {
										G[i, j, k] = new Complex(0, 0);
									}
								}
								break;
							case 3:
								if ((Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) < Math.Pow(outerRadius, 2.0)) &&
									(Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) > Math.Pow(innerRadius, 2.0))) {
									for (int k = 0; k < 3; k++) {
										G[i, j, k] = new Complex(0, 0);
									}
								}
								break;
						}
					});
				});
			}

			double intensivityAVG = 0.0;
			for (int j = 0; j < resizedSize; j++) {
				for (int i = 0; i < resizedSize; i++) {
					double intensivity = 0.0;

					for (int k = 0; k < 3; k++) {
						double magnitude = G[i, j, k].Magnitude;
						intensivity += magnitude;
					}

					intensivity /= 3.0;
					intensivityAVG += intensivity;
				}
			}

			intensivityAVG /= resizedSize * resizedSize;
			double multiplier = 255.0 / (128.0 * intensivityAVG);

			ParallelLoopResult unused_10 = Parallel.For(0, resizedSize, j => {
				ParallelLoopResult unused_11 = Parallel.For(0, resizedSize, i => {
					int red = (int) Math.Min(Math.Round(G[i, j, 0].Magnitude * multiplier), 255.0);
					int green = (int) Math.Min(Math.Round(G[i, j, 1].Magnitude * multiplier), 255.0);
					int blue = (int) Math.Min(Math.Round(G[i, j, 2].Magnitude * multiplier), 255.0);

					Color pixel = Color.FromArgb(255, red, green, blue);
					directBitmapFourier.SetPixel(i, j, pixel);
				});
			});

			pictureBoxFourier.Image = directBitmapFourier.Bitmap;
		}

		private void DrawFilterVisualisation() {
			ParallelLoopResult unused_0 = Parallel.For(0, resizedSize, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, resizedSize, i => {
					switch (filterMode) {
						case 0:
							if (Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) <= Math.Pow(outerRadius, 2.0)) {
								directBitmapVisualisation.SetPixel(i, j, whitePixel);
							} else {
								directBitmapVisualisation.SetPixel(i, j, blackPixel);
							}
							break;
						case 1:
							if (Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) <= Math.Pow(outerRadius, 2.0)) {
								directBitmapVisualisation.SetPixel(i, j, blackPixel);
							} else {
								directBitmapVisualisation.SetPixel(i, j, whitePixel);
							}
							break;
						case 2:
							if ((Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) <= Math.Pow(outerRadius, 2.0)) &&
								(Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) >= Math.Pow(innerRadius, 2.0))) {
								directBitmapVisualisation.SetPixel(i, j, whitePixel);
							} else {
								directBitmapVisualisation.SetPixel(i, j, blackPixel);
							}
							break;
						case 3:
							if ((Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) <= Math.Pow(outerRadius, 2.0)) &&
								(Math.Pow(i - center.X, 2.0) + Math.Pow(j - center.Y, 2.0) >= Math.Pow(innerRadius, 2.0))) {
								directBitmapVisualisation.SetPixel(i, j, blackPixel);
							} else {
								directBitmapVisualisation.SetPixel(i, j, whitePixel);
							}
							break;
					}
				});
			});

			pictureBoxVisualisation.Image = directBitmapVisualisation.Bitmap;
		}


		private void CheckBoxFilter_CheckedChanged(object sender, EventArgs e) {
			bool isChecked = checkBoxFilter.Checked;

			if (isChecked) {
				comboBoxFilterMode.Enabled = true;
				VisabilityController();
			} else {
				comboBoxFilterMode.Enabled = false;
				labelOuterRadius.Enabled = false;
				labelInnerRadius.Enabled = false;
				trackBarOuterRadius.Enabled = false;
				trackBarInnerRadius.Enabled = false;
				numericUpDownOuterRadius.Enabled = false;
				numericUpDownInnerRadius.Enabled = false;
			}
		}

		private void ComboBoxFilterMode_SelectedIndexChanged(object sender, EventArgs e) {
			filterMode = comboBoxFilterMode.SelectedIndex;
			VisabilityController();
			Parallel.Invoke(DrawFilterVisualisation);
		}

		private void VisabilityController() {
			switch (filterMode) {
				case 0:
				case 1:
					labelOuterRadius.Enabled = true;
					labelInnerRadius.Enabled = false;
					trackBarOuterRadius.Enabled = true;
					trackBarInnerRadius.Enabled = false;
					numericUpDownOuterRadius.Enabled = true;
					numericUpDownInnerRadius.Enabled = false;
					break;
				case 2:
				case 3:
					labelOuterRadius.Enabled = true;
					labelInnerRadius.Enabled = true;
					trackBarOuterRadius.Enabled = true;
					trackBarInnerRadius.Enabled = true;
					numericUpDownOuterRadius.Enabled = true;
					numericUpDownInnerRadius.Enabled = true;
					break;
			}
		}


		private void TrackBarOuterRadius_Scroll(object sender, EventArgs e) {
			int value = trackBarOuterRadius.Value;
			numericUpDownOuterRadius.Value = value;

			trackBarInnerRadius.Maximum = value - 1;
			numericUpDownInnerRadius.Maximum = trackBarInnerRadius.Maximum;
		}

		private void TrackBarInnerRadius_Scroll(object sender, EventArgs e) {
			int value = trackBarInnerRadius.Value;
			numericUpDownInnerRadius.Value = value;
		}

		private void NumericUpDownOuterRadius_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownOuterRadius.Value;
			trackBarOuterRadius.Value = value;
			outerRadius = value;

			trackBarInnerRadius.Maximum = value - 1;
			numericUpDownInnerRadius.Maximum = trackBarInnerRadius.Maximum;

			Parallel.Invoke(DrawFilterVisualisation);
		}

		private void NumericUpDownInnerRadius_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownInnerRadius.Value;
			trackBarInnerRadius.Value = value;
			innerRadius = value;
			Parallel.Invoke(DrawFilterVisualisation);
		}

		private void ButtonApply_Click(object sender, EventArgs e) {
			Parallel.Invoke(TwoDimensionalDiscreteFourierTransform);
			Parallel.Invoke(DrawFilterVisualisation);
		}


		private void Form_Closing(object sender, CancelEventArgs e) {
			directBitmapResized.Dispose();
			directBitmapFourier.Dispose();
			directBitmapVisualisation.Dispose();
		}
	}
}

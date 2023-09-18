using Paint.Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class BinarizationForm : Form {
		private readonly MainForm mainForm;
		private readonly int[,] integralMatrix;
		private readonly int[,] powIntegralMatrix;
		private readonly DirectBitmap directBitmap;

		private int selectedCriterion;
		private double a_value;
		private double k_value;
		private readonly Color blackPixel = Color.FromArgb(255, 0, 0, 0);
		private readonly Color whitePixel = Color.FromArgb(255, 255, 255, 255);


		public BinarizationForm(MainForm mainForm) {
			InitializeComponent();
			this.mainForm = mainForm;
			directBitmap = Layers.choosenLayer.directBitmapPictureBoxImage;
			integralMatrix = new int[directBitmap.Width, directBitmap.Height];
			powIntegralMatrix = new int[directBitmap.Width, directBitmap.Height];

			ConvertToBlackAndWhiteImage();
			CalculateIntegralMatrixs();

			comboBoxCriteria.SelectedIndex = 0;
			label_a_value.Text = "";
			label_k_value.Text = "";
		}

		private void ConvertToBlackAndWhiteImage() {
			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Width, i => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Height, j => {
					Color pixel = directBitmap.GetPixel(i, j);

					int A = pixel.A;
					int R = pixel.R;
					int G = pixel.G;
					int B = pixel.B;

					double intensivityDouble = (R + G + B) / 3.0;
					int intensivityInt = (int) Math.Round(intensivityDouble);

					Color newPixel = Color.FromArgb(A, intensivityInt, intensivityInt, intensivityInt);
					directBitmap.SetPixel(i, j, newPixel);
				});
			});

			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void CalculateIntegralMatrixs() {
			for (int x = 0; x < directBitmap.Width; x++) {
				for (int y = 0; y < directBitmap.Height; y++) {
					Color pixel = directBitmap.GetPixel(x, y);

					int previousIntensivity_X = 0;
					int previousPowIntensivity_X = 0;
					if (x > 0) {
						previousIntensivity_X = integralMatrix[x - 1, y];
						previousPowIntensivity_X = powIntegralMatrix[x - 1, y];
					}

					int previousIntensivity_Y = 0;
					int previousPowIntensivity_Y = 0;
					if (y > 0) {
						previousIntensivity_Y = integralMatrix[x, y - 1];
						previousPowIntensivity_Y = powIntegralMatrix[x, y - 1];
					}

					int previousIntensivity_XY = 0;
					int previousPowIntensivity_XY = 0;
					if (x > 0 && y > 0) {
						previousIntensivity_XY = integralMatrix[x - 1, y - 1];
						previousPowIntensivity_XY = powIntegralMatrix[x - 1, y - 1];
					}

					integralMatrix[x, y] =
						pixel.R +
						previousIntensivity_X +
						previousIntensivity_Y -
						previousIntensivity_XY;
					powIntegralMatrix[x, y] =
						(pixel.R * pixel.R) +
						previousPowIntensivity_X +
						previousPowIntensivity_Y -
						previousPowIntensivity_XY;
				}
			}
		}


		private void ComboBoxCriteria_SelectedIndexChanged(object sender, EventArgs e) {
			selectedCriterion = comboBoxCriteria.SelectedIndex;

			switch (selectedCriterion) {
				// Gavrilov
				case 0:
					label_a.Enabled = false;
					label_k.Enabled = false;

					trackBar_a.Enabled = false;
					trackBar_k.Enabled = false;

					numericUpDown_a.Enabled = false;
					numericUpDown_k.Enabled = false;

					label_a_value.Enabled = false;
					label_k_value.Enabled = false;

					trackBar_a.Minimum = 0;
					trackBar_a.Maximum = 0;
					trackBar_k.Minimum = 0;
					trackBar_k.Maximum = 0;
					break;
				// Otsu
				case 1:
					label_a.Enabled = false;
					label_k.Enabled = false;

					trackBar_a.Enabled = false;
					trackBar_k.Enabled = false;

					numericUpDown_a.Enabled = false;
					numericUpDown_k.Enabled = false;

					label_a_value.Enabled = false;
					label_k_value.Enabled = false;

					trackBar_a.Minimum = 0;
					trackBar_a.Maximum = 0;
					trackBar_k.Minimum = 0;
					trackBar_k.Maximum = 0;
					break;
				// Niblack
				case 2:
					label_a.Enabled = true;
					label_k.Enabled = true;

					trackBar_a.Enabled = true;
					trackBar_k.Enabled = true;

					numericUpDown_a.Enabled = true;
					numericUpDown_k.Enabled = true;

					label_a_value.Enabled = true;
					label_k_value.Enabled = true;

					trackBar_a.Minimum = 2;
					trackBar_a.Maximum = (Math.Max(directBitmap.Width, directBitmap.Height) / 2) + 1;
					trackBar_k.Minimum = -20;
					trackBar_k.Maximum = 20;
					break;
				// Sauvola
				case 3:
					label_a.Enabled = true;
					label_k.Enabled = true;

					trackBar_a.Enabled = true;
					trackBar_k.Enabled = true;

					numericUpDown_a.Enabled = true;
					numericUpDown_k.Enabled = true;

					label_a_value.Enabled = true;
					label_k_value.Enabled = true;

					trackBar_a.Minimum = 2;
					trackBar_a.Maximum = (Math.Max(directBitmap.Width, directBitmap.Height) / 2) + 1;
					trackBar_k.Minimum = 0;
					trackBar_k.Maximum = 30;
					break;
				// Christian Wulff
				case 4:
					label_a.Enabled = true;
					label_k.Enabled = true;

					trackBar_a.Enabled = true;
					trackBar_k.Enabled = true;

					numericUpDown_a.Enabled = true;
					numericUpDown_k.Enabled = true;

					label_a_value.Enabled = true;
					label_k_value.Enabled = true;

					trackBar_a.Minimum = 2;
					trackBar_a.Maximum = (Math.Max(directBitmap.Width, directBitmap.Height) / 2) + 1;
					trackBar_k.Minimum = 0;
					trackBar_k.Maximum = 100;
					break;
				// Bradley-Roth
				case 5:
					label_a.Enabled = true;
					label_k.Enabled = true;

					trackBar_a.Enabled = true;
					trackBar_k.Enabled = true;

					numericUpDown_a.Enabled = true;
					numericUpDown_k.Enabled = true;

					label_a_value.Enabled = true;
					label_k_value.Enabled = true;

					trackBar_a.Minimum = 2;
					trackBar_a.Maximum = Math.Max(directBitmap.Width * 2, directBitmap.Height * 2);
					trackBar_k.Minimum = 0;
					trackBar_k.Maximum = 100;
					break;
			}
			numericUpDown_a.Minimum = trackBar_a.Minimum;
			numericUpDown_a.Maximum = trackBar_a.Maximum;
			numericUpDown_k.Minimum = trackBar_k.Minimum;
			numericUpDown_k.Maximum = trackBar_k.Maximum;

			trackBar_a.Value = trackBar_a.Minimum;
			trackBar_k.Value = trackBar_k.Minimum;

			numericUpDown_a.Value = trackBar_a.Value;
			numericUpDown_k.Value = trackBar_k.Value;

			SetTextToLabelValues();
		}

		private void TrackBar_a_Scroll(object sender, EventArgs e) {
			int value = ((TrackBar) sender).Value;
			numericUpDown_a.Value = value;
			SetTextToLabelValues();
		}

		private void NumericUpDown_a_ValueChanged(object sender, EventArgs e) {
			int value = (int) ((NumericUpDown) sender).Value;
			trackBar_a.Value = value;
			SetTextToLabelValues();
		}

		private void TrackBar_k_Scroll(object sender, EventArgs e) {
			int value = ((TrackBar) sender).Value;
			numericUpDown_k.Value = value;
			SetTextToLabelValues();
		}

		private void NumericUpDown_k_ValueChanged(object sender, EventArgs e) {
			int value = (int) ((NumericUpDown) sender).Value;
			trackBar_k.Value = value;
			SetTextToLabelValues();
		}

		private void ButtonApply_Click(object sender, EventArgs e) {
			int selectedCriterion = comboBoxCriteria.SelectedIndex;

			switch (selectedCriterion) {
				// Gavrilov
				case 0:
					Parallel.Invoke(GavrilovCriterion);
					break;
				// Otsu
				case 1:
					Parallel.Invoke(OtsyCriterion);
					break;
				// Niblack
				case 2:
					Parallel.Invoke(NiblackCriterion);
					break;
				// Sauvola
				case 3:
					Parallel.Invoke(SauvolaCriterion);
					break;
				// Christian Wulff
				case 4:
					Parallel.Invoke(ChristianWulffCriterion);
					break;
				// Bradley-Roth
				case 5:
					Parallel.Invoke(BradleyRothCriterion);
					break;
			}

			Parallel.Invoke(mainForm.MergeLayers);
		}


		private void SetTextToLabelValues() {
			int a = trackBar_a.Value;
			int k = trackBar_k.Value;

			switch (selectedCriterion) {
				// Gavrilov
				case 0:
					label_a_value.Text = "";
					label_k_value.Text = "";
					break;
				// Otsu
				case 1:
					label_a_value.Text = "";
					label_k_value.Text = "";
					break;
				// Sauvola
				case 3:
					a_value = (2 * a) - 1;
					k_value = 0.2 + (k * 0.01);
					label_a_value.Text = "a = " + a_value;
					label_k_value.Text = "k = " + k_value;
					break;
				// Niblack
				// Christian Wulff
				// Bradley-Roth
				case 2:
				case 4:
				case 5:
					a_value = (2 * a) - 1;
					k_value = k * 0.01;
					label_a_value.Text = "a = " + a_value;
					label_k_value.Text = "k = " + k_value;
					break;
			}
		}


		private void GavrilovCriterion() {
			double avgIntensivity = 0.0;
			for (int i = 0; i < directBitmap.Width; i++) {
				for (int j = 0; j < directBitmap.Height; j++) {
					Color pixel = directBitmap.GetPixel(i, j);
					avgIntensivity += pixel.R;
				}
			}
			avgIntensivity /= directBitmap.Width * directBitmap.Height;

			int t = (int) Math.Round(avgIntensivity);
			ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					if (pixel.R <= t) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}

		private void OtsyCriterion() {
			int intensitySum = 0;
			int[] p = new int[256];
			Array.Clear(p, 0, p.Length);

			for (int i = 0; i < directBitmap.Width; i++) {
				for (int j = 0; j < directBitmap.Height; j++) {
					Color pixel = directBitmap.GetPixel(i, j);
					int intensivity = pixel.R;

					intensitySum += intensivity;
					p[intensivity]++;
				}
			}


			int t_best = 0;
			double s_best = 0.0;
			int firstClassPixelCount = 0;
			int firstClassIntensitySum = 0;
			int imageSize = directBitmap.Width * directBitmap.Height;

			for (int t = 0; t < 255; ++t) {
				firstClassPixelCount += p[t];
				firstClassIntensitySum += t * p[t];

				double firstClassProb = firstClassPixelCount / (double) imageSize;
				double secondClassProb = 1.0 - firstClassProb;

				double first_class_mean = firstClassIntensitySum / (double) firstClassPixelCount;
				double second_class_mean = (intensitySum - firstClassIntensitySum)
					/ (double) (imageSize - firstClassPixelCount);

				double meanDelta = first_class_mean - second_class_mean;

				double s = firstClassProb * secondClassProb * meanDelta * meanDelta;

				if (s > s_best) {
					s_best = s;
					t_best = t;
				}
			}

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					if (pixel.R <= t_best) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}

		private void NiblackCriterion() {
			int halfCorner = ((int) a_value - 1) / 2;
			int[,] results = new int[directBitmap.Width, directBitmap.Height];

			for (int j = 0; j < directBitmap.Height; j++) {
				int bottomCorner = j + halfCorner > directBitmap.Height - 1 ? directBitmap.Height - 1 : j + halfCorner;
				int topCorner = j - halfCorner < 0 ? 0 : j - halfCorner;

				for (int i = 0; i < directBitmap.Width; i++) {
					int leftCorner = i - halfCorner < 0 ? 0 : i - halfCorner;
					int rightCorner = i + halfCorner > directBitmap.Width - 1 ? directBitmap.Width - 1 : i + halfCorner;

					double probability = 1.0 / ((rightCorner - leftCorner + 1) * (bottomCorner - topCorner + 1));

					int s_1 = integralMatrix[rightCorner, bottomCorner];
					int pow_s_1 = powIntegralMatrix[rightCorner, bottomCorner];

					int s_2 = 0;
					int pow_s_2 = 0;
					if (leftCorner > 0 && topCorner > 0) {
						s_2 = integralMatrix[leftCorner - 1, topCorner - 1];
						pow_s_2 = powIntegralMatrix[leftCorner - 1, topCorner - 1];
					}

					int s_3 = 0;
					int pow_s_3 = 0;
					if (leftCorner > 0) {
						s_3 = integralMatrix[leftCorner - 1, bottomCorner];
						pow_s_3 = powIntegralMatrix[leftCorner - 1, bottomCorner];
					}

					int s_4 = 0;
					int pow_s_4 = 0;
					if (topCorner > 0) {
						s_4 = integralMatrix[rightCorner, topCorner - 1];
						pow_s_4 = powIntegralMatrix[rightCorner, topCorner - 1];
					}

					int sum = s_1 + s_2 - s_3 - s_4;
					int sumPow = pow_s_1 + pow_s_2 - pow_s_3 - pow_s_4;

					double expectedValue = sum * probability;
					double expectedValuePowInside = sumPow * probability;
					double expectedValuePowOutside = expectedValue * expectedValue;
					double variance = expectedValuePowInside - expectedValuePowOutside;

					double sigma = Math.Sqrt(variance);
					int t = (int) Math.Round(expectedValue + (k_value * sigma));

					results[i, j] = t;
				}
			}

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					if (pixel.R <= results[i, j]) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}

		private void SauvolaCriterion() {
			int halfCorner = ((int) a_value - 1) / 2;
			int[,] results = new int[directBitmap.Width, directBitmap.Height];

			for (int j = 0; j < directBitmap.Height; j++) {
				int bottomCorner = j + halfCorner > directBitmap.Height - 1 ? directBitmap.Height - 1 : j + halfCorner;
				int topCorner = j - halfCorner < 0 ? 0 : j - halfCorner;

				for (int i = 0; i < directBitmap.Width; i++) {
					int leftCorner = i - halfCorner < 0 ? 0 : i - halfCorner;
					int rightCorner = i + halfCorner > directBitmap.Width - 1 ? directBitmap.Width - 1 : i + halfCorner;

					double probability = 1.0 / ((rightCorner - leftCorner + 1) * (bottomCorner - topCorner + 1));

					int s_1 = integralMatrix[rightCorner, bottomCorner];
					int pow_s_1 = powIntegralMatrix[rightCorner, bottomCorner];

					int s_2 = 0;
					int pow_s_2 = 0;
					if (leftCorner > 0 && topCorner > 0) {
						s_2 = integralMatrix[leftCorner - 1, topCorner - 1];
						pow_s_2 = powIntegralMatrix[leftCorner - 1, topCorner - 1];
					}

					int s_3 = 0;
					int pow_s_3 = 0;
					if (leftCorner > 0) {
						s_3 = integralMatrix[leftCorner - 1, bottomCorner];
						pow_s_3 = powIntegralMatrix[leftCorner - 1, bottomCorner];
					}

					int s_4 = 0;
					int pow_s_4 = 0;
					if (topCorner > 0) {
						s_4 = integralMatrix[rightCorner, topCorner - 1];
						pow_s_4 = powIntegralMatrix[rightCorner, topCorner - 1];
					}

					int sum = s_1 + s_2 - s_3 - s_4;
					int sumPow = pow_s_1 + pow_s_2 - pow_s_3 - pow_s_4;

					double expectedValue = sum * probability;
					double expectedValuePowInside = sumPow * probability;
					double expectedValuePowOutside = expectedValue * expectedValue;
					double variance = expectedValuePowInside - expectedValuePowOutside;

					double sigma = Math.Sqrt(variance);
					int t = (int) (expectedValue * (1.0 + (k_value * ((sigma / 128.0) - 1.0))));

					results[i, j] = t;
				}
			}

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					if (pixel.R <= results[i, j]) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}

		private void ChristianWulffCriterion() {
			double minIntensivity = 255.0;

			for (int j = 0; j < directBitmap.Height; j++) {
				for (int i = 0; i < directBitmap.Width; i++) {
					Color pixel = directBitmap.GetPixel(i, j);

					if (pixel.R < minIntensivity) {
						minIntensivity = pixel.R;
					}
				}
			}

			int halfCorner = ((int) a_value - 1) / 2;
			double[,] sigmas = new double[directBitmap.Width, directBitmap.Height];
			double[,] expectedValues = new double[directBitmap.Width, directBitmap.Height];
			for (int j = 0; j < directBitmap.Height; j++) {
				int bottomCorner = j + halfCorner > directBitmap.Height - 1 ? directBitmap.Height - 1 : j + halfCorner;
				int topCorner = j - halfCorner < 0 ? 0 : j - halfCorner;

				for (int i = 0; i < directBitmap.Width; i++) {
					int leftCorner = i - halfCorner < 0 ? 0 : i - halfCorner;
					int rightCorner = i + halfCorner > directBitmap.Width - 1 ? directBitmap.Width - 1 : i + halfCorner;

					double probability = 1.0 / ((rightCorner - leftCorner + 1) * (bottomCorner - topCorner + 1));

					int s_1 = integralMatrix[rightCorner, bottomCorner];
					int pow_s_1 = powIntegralMatrix[rightCorner, bottomCorner];

					int s_2 = 0;
					int pow_s_2 = 0;
					if (leftCorner > 0 && topCorner > 0) {
						s_2 = integralMatrix[leftCorner - 1, topCorner - 1];
						pow_s_2 = powIntegralMatrix[leftCorner - 1, topCorner - 1];
					}

					int s_3 = 0;
					int pow_s_3 = 0;
					if (leftCorner > 0) {
						s_3 = integralMatrix[leftCorner - 1, bottomCorner];
						pow_s_3 = powIntegralMatrix[leftCorner - 1, bottomCorner];
					}

					int s_4 = 0;
					int pow_s_4 = 0;
					if (topCorner > 0) {
						s_4 = integralMatrix[rightCorner, topCorner - 1];
						pow_s_4 = powIntegralMatrix[rightCorner, topCorner - 1];
					}

					int sum = s_1 + s_2 - s_3 - s_4;
					int sumPow = pow_s_1 + pow_s_2 - pow_s_3 - pow_s_4;

					double expectedValue = sum * probability;
					double expectedValuePowInside = sumPow * probability;
					double expectedValuePowOutside = expectedValue * expectedValue;
					double variance = expectedValuePowInside - expectedValuePowOutside;

					double sigma = Math.Sqrt(variance);

					sigmas[i, j] = sigma;
					expectedValues[i, j] = expectedValue;
				}
			}

			double maxSigma = sigmas[0, 0];
			for (int j = 0; j < directBitmap.Height; j++) {
				for (int i = 0; i < directBitmap.Width; i++) {
					if (sigmas[i, j] > maxSigma) {
						maxSigma = sigmas[i, j];
					}
				}
			}

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					double sigma = sigmas[i, j];
					double expectedValue = expectedValues[i, j];
					int t = (int) (((1.0 - k_value) * expectedValue) +
						(k_value * minIntensivity) +
						(k_value * sigma * (expectedValue - minIntensivity) / maxSigma));

					if (pixel.R <= t) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}

		private void BradleyRothCriterion() {
			int halfCorner = ((int) a_value - 1) / 2;
			int[,] sizes = new int[directBitmap.Width, directBitmap.Height];
			int[,] sums = new int[directBitmap.Width, directBitmap.Height];
			for (int j = 0; j < directBitmap.Height; j++) {
				int bottomCorner = j + halfCorner > directBitmap.Height - 1 ? directBitmap.Height - 1 : j + halfCorner;
				int topCorner = j - halfCorner < 0 ? 0 : j - halfCorner;

				for (int i = 0; i < directBitmap.Width; i++) {
					int leftCorner = i - halfCorner < 0 ? 0 : i - halfCorner;
					int rightCorner = i + halfCorner > directBitmap.Width - 1 ? directBitmap.Width - 1 : i + halfCorner;

					int s_1 = integralMatrix[rightCorner, bottomCorner];

					int s_2 = 0;
					if (leftCorner > 0 && topCorner > 0) {
						s_2 = integralMatrix[leftCorner - 1, topCorner - 1];
					}

					int s_3 = 0;
					if (leftCorner > 0) {
						s_3 = integralMatrix[leftCorner - 1, bottomCorner];
					}

					int s_4 = 0;
					if (topCorner > 0) {
						s_4 = integralMatrix[rightCorner, topCorner - 1];
					}

					int sum = s_1 + s_2 - s_3 - s_4;
					sums[i, j] = sum;
					sizes[i, j] = (rightCorner - leftCorner + 1) * (bottomCorner - topCorner + 1);
				}
			}

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					Color pixel = directBitmap.GetPixel(i, j);

					int sum = sums[i, j];
					int size = sizes[i, j];

					if (pixel.R * size < sum * (1.0 - k_value)) {
						directBitmap.SetPixel(i, j, blackPixel);
					} else {
						directBitmap.SetPixel(i, j, whitePixel);
					}
				});
			});
		}
	}
}

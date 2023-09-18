using Paint.Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class GaussianBlurForm : Form {
		private readonly MainForm mainForm;
		private DirectBitmap directBitmap;

		private int windowSize;
		private double sigma;
		private double[,] matrix;

		public GaussianBlurForm(MainForm mainForm) {
			InitializeComponent();
			this.mainForm = mainForm;
			directBitmap = Layers.choosenLayer.directBitmapPictureBoxImage;

			trackBarWindowSize.Minimum = 2;
			trackBarWindowSize.Maximum = (Math.Max(directBitmap.Width, directBitmap.Height) / 2) + 1;
			trackBarSigma.Minimum = 1;
			trackBarSigma.Maximum = 100;
			numericUpDownWindowSize.Minimum = trackBarWindowSize.Minimum;
			numericUpDownWindowSize.Maximum = trackBarWindowSize.Maximum;

			trackBarSigma.Value = 30;
			numericUpDownSigma.Value = trackBarSigma.Value;
		}


		private void TrackBarWindowSize_Scroll(object sender, EventArgs e) {
			int value = trackBarWindowSize.Value;
			numericUpDownWindowSize.Value = value;
			SetTextToLabels();
		}

		private void TrackBarSigma_Scroll(object sender, EventArgs e) {
			int value = trackBarSigma.Value;
			numericUpDownSigma.Value = value;
			SetTextToLabels();
		}


		private void NumericUpDownWindowSize_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownWindowSize.Value;
			trackBarWindowSize.Value = value;
			SetTextToLabels();
		}

		private void NumericUpDownSigma_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownSigma.Value;
			trackBarSigma.Value = value;
			SetTextToLabels();
		}


		private void SetTextToLabels() {
			int currentWindowSize = trackBarWindowSize.Value;
			int currentSigma = trackBarSigma.Value;

			windowSize = (2 * currentWindowSize) - 1;
			sigma = currentSigma / 10.0;

			labelWindowSize.Text = "Window size: " + windowSize;
			labelSigma.Text = "Sigma: " + sigma;
			labelSum.Text = "Sum: " + CalculateGaussian();
		}


		private double CalculateGaussian() {
			matrix = new double[(windowSize * 2) + 1, (windowSize * 2) + 1];
			double sum = 0.0;

			int i_index = 0;
			for (int i = -windowSize; i <= windowSize; i++) {
				int j_index = 0;
				for (int j = -windowSize; j <= windowSize; j++) {
					double gauss =
							1.0 / (2.0 * Math.PI * sigma * sigma) *
							Math.Exp(-((i * i) + (j * j)) / (2.0 * sigma * sigma));
					sum += gauss;

					matrix[i_index, j_index] = gauss;
					j_index++;
				}
				i_index++;
			}

			return sum;
		}


		private void ButtonApply_Click(object sender, EventArgs e) {
			Parallel.Invoke(GaussianFilter);
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void GaussianFilter() {
			int halfWindowSize = windowSize;

			DirectBitmap directBitmapResult = new DirectBitmap(directBitmap.Bitmap);

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				int y_1 = j - halfWindowSize;
				int y_2 = j + halfWindowSize;

				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					int x_1 = i - halfWindowSize;
					int x_2 = i + halfWindowSize;

					double totalintensity = 0.0;
					for (int y = y_1, matrix_j = 0; y <= y_2; y++, matrix_j++) {
						for (int x = x_1, matrix_i = 0; x <= x_2; x++, matrix_i++) {
							int X = x;
							int Y = y;

							if (x < 0) {
								X = -x;
							} else if (x >= directBitmap.Width) {
								X = directBitmap.Width - 1 - (x - directBitmap.Width);
							}

							if (y < 0) {
								Y = -y;
							} else if (y >= directBitmap.Height) {
								Y = directBitmap.Height - 1 - (y - directBitmap.Height);
							}

							Color pixel = directBitmap.GetPixel(X, Y);
							int R = pixel.R;
							int G = pixel.G;
							int B = pixel.B;

							double value = matrix[matrix_i, matrix_j];
							double intensity = (R + G + B) * value / 3.0;

							totalintensity += intensity;
						}
					}

					Color currentPixel = directBitmap.GetPixel(i, j);
					int cur_R = currentPixel.R;
					int cur_G = currentPixel.G;
					int cur_B = currentPixel.B;
					cur_R = cur_R > 0 ? cur_R : 1;
					cur_G = cur_G > 0 ? cur_G : 1;
					cur_B = cur_B > 0 ? cur_B : 1;
					double currentIntensity = (cur_R + cur_G + cur_B) / 3.0;

					int new_A = currentPixel.A;
					if (totalintensity < 0.0) {
						totalintensity = 0.0;
					}
					if (currentIntensity == 0.0) {
						currentIntensity = 0.0001;
					}

					double multiplier = (double) totalintensity / currentIntensity;
					int new_R = (int) Math.Min(Math.Round(cur_R * multiplier), 255.0);
					int new_G = (int) Math.Min(Math.Round(cur_G * multiplier), 255.0);
					int new_B = (int) Math.Min(Math.Round(cur_B * multiplier), 255.0);
					Color result = Color.FromArgb(new_A, new_R, new_G, new_B);

					directBitmapResult.SetPixel(i, j, result);
					int progress = (int) Math.Round((double) j / directBitmap.Height * 100.0);
				});
			});

			DirectBitmap toDelete = directBitmap;
			Layers.choosenLayer.directBitmapPictureBoxImage = directBitmapResult;
			toDelete.Dispose();
			directBitmap = directBitmapResult;
		}
	}
}

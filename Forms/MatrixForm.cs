using Paint.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class MatrixForm : Form {
		private readonly MainForm mainForm;
		private int columnNumber;
		private int rowNumber;
		private readonly double[,] matrix;
		private DirectBitmap directBitmap;


		public MatrixForm(MainForm mainForm) {
			InitializeComponent();
			this.mainForm = mainForm;
			directBitmap = Layers.choosenLayer.directBitmapPictureBoxImage;
			matrix = new double[directBitmap.Width + 1, directBitmap.Height + 1];
			Array.Clear(matrix, 0, matrix.Length);

			trackBarColumns.Minimum = 2;
			trackBarColumns.Maximum = (Math.Max(directBitmap.Width, directBitmap.Height) / 2) + 1;
			trackBarRows.Minimum = 2;
			trackBarRows.Maximum = (Math.Min(directBitmap.Width, directBitmap.Height) / 2) + 1;
			numericUpDownColumns.Minimum = trackBarColumns.Minimum;
			numericUpDownColumns.Maximum = trackBarColumns.Maximum;
			numericUpDownRows.Minimum = numericUpDownColumns.Minimum;
			numericUpDownRows.Maximum = numericUpDownColumns.Maximum;
		}


		private void TrackBarColumns_Scroll(object sender, EventArgs e) {
			int value = trackBarColumns.Value;
			numericUpDownColumns.Value = value;
			SetTextToLabels();
		}

		private void TrackBarRows_Scroll(object sender, EventArgs e) {
			int value = trackBarRows.Value;
			numericUpDownRows.Value = value;
			SetTextToLabels();
		}


		private void NumericUpDownColumns_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownColumns.Value;
			trackBarColumns.Value = value;
			SetTextToLabels();
		}

		private void NumericUpDownRows_ValueChanged(object sender, EventArgs e) {
			int value = (int) numericUpDownRows.Value;
			trackBarRows.Value = value;
			SetTextToLabels();
		}


		private void SetTextToLabels() {
			int columns = trackBarColumns.Value;
			int rows = trackBarRows.Value;

			columnNumber = (2 * columns) - 1;
			rowNumber = (2 * rows) - 1;
			labelColumns.Text = "Columns number: " + columnNumber;
			labelRows.Text = "Rows number: " + rowNumber;

			dataGridView.Columns.Clear();
			dataGridView.Rows.Clear();
			for (int i = 0; i < columnNumber; i++) {
				int unused = dataGridView.Columns.Add("", "");
				dataGridView.Columns[i].Width = 40;
			}
			for (int i = 0; i < rowNumber; i++) {
				int unused = dataGridView.Rows.Add("", "");
				dataGridView.Rows[i].Height = 20;
			}

			for (int i = 0; i < columnNumber; i++) {
				for (int j = 0; j < rowNumber; j++) {
					dataGridView[i, j].Value = matrix[i, j];
				}
			}
		}


		private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			double result = 0.0;
			try {
				result = Convert.ToDouble(dataGridView[e.ColumnIndex, e.RowIndex].Value);
			} catch (Exception) {
				dataGridView[e.ColumnIndex, e.RowIndex].Value = result;
			}
			matrix[e.ColumnIndex, e.RowIndex] = result;
		}


		private void ButtonApply_Click(object sender, EventArgs e) {
			Parallel.Invoke(ApplyMatrix);
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void ButtonMedian_Click(object sender, EventArgs e) {
			Parallel.Invoke(MedianFiltering);
			Parallel.Invoke(mainForm.MergeLayers);
		}


		private void ApplyMatrix() {
			int halfCornerColumn = (columnNumber - 1) / 2;
			int halfCornerRow = (rowNumber - 1) / 2;

			DirectBitmap directBitmapResult = new DirectBitmap(directBitmap.Bitmap);

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				int y_1 = j - halfCornerRow;
				int y_2 = j + halfCornerRow;

				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					int x_1 = i - halfCornerColumn;
					int x_2 = i + halfCornerColumn;

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
							double newIntensity = (R + G + B) * value / 3.0;

							totalintensity += newIntensity;
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

					double multiplier = ((double) totalintensity) / currentIntensity;
					int new_R = (int) Math.Min(Math.Round(cur_R * multiplier), 255.0);
					int new_G = (int) Math.Min(Math.Round(cur_G * multiplier), 255.0);
					int new_B = (int) Math.Min(Math.Round(cur_B * multiplier), 255.0);
					Color result = Color.FromArgb(new_A, new_R, new_G, new_B);

					directBitmapResult.SetPixel(i, j, result);
				});
			});

			DirectBitmap toDelete = directBitmap;
			Layers.choosenLayer.directBitmapPictureBoxImage = directBitmapResult;
			toDelete.Dispose();
			directBitmap = directBitmapResult;
		}

		private void MedianFiltering() {
			int halfCornerColumn = (columnNumber - 1) / 2;
			int halfCornerRow = (rowNumber - 1) / 2;

			DirectBitmap directBitmapResult = new DirectBitmap(directBitmap.Bitmap);

			ParallelLoopResult unused_0 = Parallel.For(0, directBitmap.Height, j => {
				int y_1 = j - halfCornerRow;
				int y_2 = j + halfCornerRow;

				ParallelLoopResult unused_1 = Parallel.For(0, directBitmap.Width, i => {
					int x_1 = i - halfCornerColumn;
					int x_2 = i + halfCornerColumn;

					List<int> intensities = new List<int>();
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

							if (!(Y == j && X == i)) {
								Color pixel = directBitmap.GetPixel(X, Y);
								int R = pixel.R;
								int G = pixel.G;
								int B = pixel.B;

								int intensity = (int) Math.Round((R + G + B) / 3.0);
								intensities.Add(intensity);
							}
						}
					}
					int k = intensities.Count / 2;
					intensities.Sort();

					Color currentPixel = directBitmap.GetPixel(i, j);
					int new_A = currentPixel.A;
					int cur_R = currentPixel.R;
					int cur_G = currentPixel.G;
					int cur_B = currentPixel.B;
					cur_R = cur_R > 0 ? cur_R : 1;
					cur_G = cur_G > 0 ? cur_G : 1;
					cur_B = cur_B > 0 ? cur_B : 1;
					double currentIntensity = (cur_R + cur_G + cur_B) / 3.0;

					if (currentIntensity == 0.0) {
						currentIntensity = 0.0001;
					}

					double median = (intensities[k - 1] + intensities[k]) / 2.0;
					double multiplier = median / currentIntensity;

					int new_R = (int) Math.Min(Math.Round(cur_R * multiplier), 255.0);
					int new_G = (int) Math.Min(Math.Round(cur_G * multiplier), 255.0);
					int new_B = (int) Math.Min(Math.Round(cur_B * multiplier), 255.0);
					Color result = Color.FromArgb(new_A, new_R, new_G, new_B);

					directBitmapResult.SetPixel(i, j, result);
				});
			});

			DirectBitmap toDelete = directBitmap;
			Layers.choosenLayer.directBitmapPictureBoxImage = directBitmapResult;
			toDelete.Dispose();
			directBitmap = directBitmapResult;
		}
	}
}

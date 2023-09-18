using Paint.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class CurvesForm : Form {
		private bool movePoint;
		private int indexPointToMove;

		private DirectBitmap directBitmapSaved;
		private bool channel_R = true;
		private bool channel_G = true;
		private bool channel_B = true;

		private readonly Bitmap graph;
		private readonly Graphics graphics;
		private readonly Pen redPen = new Pen(Brushes.Red, 5);
		private readonly Pen blackPen = new Pen(Brushes.Black, 1);
		private readonly Pen silverPen = new Pen(Brushes.Silver, 1);
		private List<Point> points = new List<Point>();

		private readonly MainForm mainForm;
		private readonly DirectBitmap directBitmapOriginal;
		private readonly DirectBitmap directBitmapHistogram;
		private Point mouseCoordinates;


		public CurvesForm(MainForm mainForm) {
			InitializeComponent();
			directBitmapOriginal = new DirectBitmap(Layers.choosenLayer.directBitmapPictureBoxImage.Bitmap);
			this.mainForm = mainForm;
			Closing += Form_Closing;

			graph = new Bitmap(pictureBoxGraph.Width, pictureBoxGraph.Height);
			graphics = Graphics.FromImage(graph);

			Bitmap histogram = new Bitmap(pictureBoxHistogram.Width, pictureBoxHistogram.Height);
			directBitmapHistogram = new DirectBitmap(histogram);

			Point point_0 = new Point(0, 255);
			Point point_1 = new Point(255, 0);
			points.Add(point_0);
			points.Add(point_1);

			Parallel.Invoke(EditPicture);
			DrawGraph();
			DrawHistogram(directBitmapOriginal);
		}


		private void PictureBoxGraph_Click(object sender, EventArgs e) {
			MouseEventArgs mouseEventArgs = (MouseEventArgs) e;

			bool confirmAdding = true;
			if (movePoint) {
				foreach (Point point in points) {
					if (points.IndexOf(point) != indexPointToMove && point.X == mouseCoordinates.X) {
						confirmAdding = false;
						break;
					}
				}
			}

			if (confirmAdding) {
				movePoint = false;
				bool addNewPoint = true;
				if (mouseEventArgs.Button == MouseButtons.Left) {
					if (mouseCoordinates.X == 0 || mouseCoordinates.X == 255) {
						addNewPoint = false;
						if (mouseCoordinates.X == 0) {
							points[0] = mouseCoordinates;
						} else {
							points[points.Count - 1] = mouseCoordinates;
						}
					} else {
						foreach (Point point in points) {
							if ((Math.Abs(point.X - mouseCoordinates.X) < 6 &&
								Math.Abs(point.Y - mouseCoordinates.Y) < 6) ||
								point.X == mouseCoordinates.X) {
								addNewPoint = false;
								if (point.X != mouseCoordinates.X) {
									movePoint = true;
									indexPointToMove = points.IndexOf(point);
								}
								break;
							}
						}
					}
					if (addNewPoint) {
						Point newPoint = new Point(mouseCoordinates.X, mouseCoordinates.Y);
						points.Add(mouseCoordinates);

						movePoint = true;
						points = points.OrderBy(o => o.X).ToList();
						indexPointToMove = points.IndexOf(newPoint);
					}
				}
			}
			if (mouseEventArgs.Button == MouseButtons.Right && !movePoint) {
				foreach (Point point in points) {
					if (Math.Abs(point.X - mouseCoordinates.X) < 6 &&
						Math.Abs(point.Y - mouseCoordinates.Y) < 6) {
						if (point != points[0] && point != points[points.Count - 1]) {
							bool unused = points.Remove(point);
							break;
						}
					}
				}
			}

			if (!movePoint) {
				points = points.OrderBy(o => o.X).ToList();
				Parallel.Invoke(EditPicture);
			}
		}

		private void PictureBoxGraph_MouseMove(object sender, MouseEventArgs e) {
			mouseCoordinates = new Point(e.X, e.Y);
			if (movePoint) {
				Point newPoint = indexPointToMove == 0 || indexPointToMove == points.Count - 1
					? indexPointToMove == 0 ? new Point(0, mouseCoordinates.Y) : new Point(255, mouseCoordinates.Y)
					: new Point(mouseCoordinates.X, mouseCoordinates.Y);
				points[indexPointToMove] = newPoint;
				points = points.OrderBy(o => o.X).ToList();
				indexPointToMove = points.IndexOf(newPoint);
			}
			toolStripStatusLabelCoords.Text = e.X + ", " + (255 - e.Y);
			DrawGraph();
		}

		private void PictureBoxGraph_MouseLeave(object sender, EventArgs e) {
			mouseCoordinates = Point.Empty;
			toolStripStatusLabelCoords.Text = "";
			DrawGraph();
		}


		private void EditPicture() {
			int[] brightnessLevels = new int[256];
			for (int i = 0; i < points.Count - 1; i++) {
				Point p1 = new Point(points[i].X, 255 - points[i].Y);
				Point p2 = new Point(points[i + 1].X, 255 - points[i + 1].Y);

				double c = p2.X - p1.X;
				double b = -((p1.X * p2.Y) - (p2.X * p1.Y));
				double k = -(p1.Y - p2.Y);

				for (int j = p1.X; j < p2.X + 1; j++) {
					brightnessLevels[j] = (int) Math.Round(((k * j) + b) / c);
				}
			}

			for (int i = 0; i < directBitmapOriginal.Width; i++) {
				for (int j = 0; j < directBitmapOriginal.Height; j++) {
					Color pixel = directBitmapOriginal.GetPixel(i, j);

					int A = pixel.A;
					int R = pixel.R;
					int G = pixel.G;
					int B = pixel.B;

					int new_R = channel_R ? brightnessLevels[R] : R;
					int new_G = channel_G ? brightnessLevels[G] : G;
					int new_B = channel_B ? brightnessLevels[B] : B;

					Color resultPixel = Color.FromArgb(A, new_R, new_G, new_B);
					Layers.choosenLayer.directBitmapPictureBoxImage.SetPixel(i, j, resultPixel);
				}
			}

			DrawHistogram(Layers.choosenLayer.directBitmapPictureBoxImage);
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void DrawGraph() {
			Point line_X_bottom = new Point(mouseCoordinates.X, 0);
			Point line_X_top = new Point(mouseCoordinates.X, 255);

			Point line_Y_start = new Point(0, mouseCoordinates.Y);
			Point line_Y_end = new Point(255, mouseCoordinates.Y);

			graphics.Clear(Color.White);

			graphics.DrawLine(silverPen, new Point(64, 0), new Point(64, 255));
			graphics.DrawLine(silverPen, new Point(128, 0), new Point(128, 255));
			graphics.DrawLine(silverPen, new Point(192, 0), new Point(192, 255));

			graphics.DrawLine(silverPen, new Point(0, 64), new Point(255, 64));
			graphics.DrawLine(silverPen, new Point(0, 128), new Point(255, 128));
			graphics.DrawLine(silverPen, new Point(0, 192), new Point(255, 192));

			graphics.DrawLine(silverPen, points[0], points[points.Count - 1]);
			graphics.DrawEllipse(redPen, points[0].X - 3, points[0].Y - 3, 6, 6);
			for (int i = 0; i < points.Count - 1; i++) {
				graphics.DrawEllipse(redPen, points[i + 1].X - 3, points[i + 1].Y - 3, 6, 6);
				graphics.DrawLine(blackPen, points[i], points[i + 1]);
			}

			if (mouseCoordinates != Point.Empty) {
				graphics.DrawLine(silverPen, line_X_bottom, line_X_top);
				graphics.DrawLine(silverPen, line_Y_start, line_Y_end);
			}
			pictureBoxGraph.Image = graph;
		}

		private void DrawHistogram(DirectBitmap picture) {
			int[] brightnessLevels = new int[256];
			Array.Clear(brightnessLevels, 0, brightnessLevels.Length);

			LayerModel layer = Layers.choosenLayer;

			for (int i = 0; i < picture.Width; i++) {
				for (int j = 0; j < picture.Height; j++) {
					Color pixel = picture.GetPixel(i, j);

					int R = layer.channel_R ? pixel.R : 0;
					int G = layer.channel_G ? pixel.G : 0;
					int B = layer.channel_B ? pixel.B : 0;

					int currentBrightness = (int) Math.Round((R + G + B) / 3.0);
					brightnessLevels[currentBrightness]++;
				}
			}

			int max = brightnessLevels.Max();
			double k = 256.0 / max;

			for (int i = 0; i < 256; i++) {
				brightnessLevels[i] = 255 - (int) Math.Truncate(brightnessLevels[i] * k);
			}

			Color blackPixel = Color.FromArgb(255, 0, 0, 0);
			Color whitePixel = Color.FromArgb(255, 255, 255, 255);

			for (int i = 0; i < directBitmapHistogram.Width; i++) {
				for (int j = 0; j < directBitmapHistogram.Height; j++) {
					if (j < brightnessLevels[i]) {
						directBitmapHistogram.SetPixel(i, j, whitePixel);
					} else {
						directBitmapHistogram.SetPixel(i, j, blackPixel);
					}
				}
			}
			pictureBoxHistogram.Image = directBitmapHistogram.Bitmap;
		}


		private void CheckBoxRed_CheckedChanged(object sender, EventArgs e) {
			channel_R = ((CheckBox) sender).Checked;
			Parallel.Invoke(EditPicture);
		}

		private void CheckBoxGreen_CheckedChanged(object sender, EventArgs e) {
			channel_G = ((CheckBox) sender).Checked;
			Parallel.Invoke(EditPicture);
		}

		private void CheckBoxBlue_CheckedChanged(object sender, EventArgs e) {
			channel_B = ((CheckBox) sender).Checked;
			Parallel.Invoke(EditPicture);
		}

		private void CheckBoxOriginal_CheckedChanged(object sender, EventArgs e) {
			if (((CheckBox) sender).Checked == true) {
				pictureBoxGraph.Enabled = false;
				checkBoxRed.Checked = true;
				checkBoxGreen.Checked = true;
				checkBoxBlue.Checked = true;
				checkBoxRed.Enabled = false;
				checkBoxGreen.Enabled = false;
				checkBoxBlue.Enabled = false;
				toolStripStatusLabelReset.Enabled = false;
				directBitmapSaved = Layers.choosenLayer.directBitmapPictureBoxImage;
				Layers.choosenLayer.directBitmapPictureBoxImage = directBitmapOriginal;
				Parallel.Invoke(mainForm.MergeLayers);
				DrawHistogram(directBitmapOriginal);
			} else {
				pictureBoxGraph.Enabled = true;
				checkBoxRed.Checked = channel_R;
				checkBoxGreen.Checked = channel_G;
				checkBoxBlue.Checked = channel_B;
				checkBoxRed.Enabled = true;
				checkBoxGreen.Enabled = true;
				checkBoxBlue.Enabled = true;
				toolStripStatusLabelReset.Enabled = true;
				Layers.choosenLayer.directBitmapPictureBoxImage = directBitmapSaved;
				Parallel.Invoke(mainForm.MergeLayers);
				DrawHistogram(Layers.choosenLayer.directBitmapPictureBoxImage);
			}
		}

		private void ToolStripStatusLabelReset_Click(object sender, EventArgs e) {
			movePoint = false;

			while (points.Count != 2) {
				points.RemoveAt(1);
			}
			Parallel.Invoke(EditPicture);
		}


		private void Form_Closing(object sender, CancelEventArgs e) {
			checkBoxOriginal.Checked = false;
			directBitmapOriginal.Dispose();
			directBitmapHistogram.Dispose();
		}
	}
}

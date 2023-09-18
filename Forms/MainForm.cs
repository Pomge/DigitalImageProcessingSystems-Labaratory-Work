using Paint.Classes;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Paint.Forms {
	public partial class MainForm : Form {
		private readonly int maxZoomRatio = 30;

		private int zoomRatioCount = 0;
		private int originalPictureBoxSize;
		private Point mousePosition;
		private Point pictureBoxPosition;

		private LayersForm layersForm = null;

		public MainForm() {
			InitializeComponent();
			panel.MouseWheel += Panel_MouseWheel;
			toolStripStatusLabel_pictureBoxImageSize.Text = pictureBox.Width + " x " + pictureBox.Height;
			toolStripStatusLabel_mousePosition.Text = "";
			toolStripStatusLabel_zoomRatio.Text = "100%";

			Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap)) {
				graphics.Clear(Color.White);
			}
			pictureBox.Image = bitmap;
			originalPictureBoxSize = pictureBox.Width;

			LayerModel layerModel = new LayerModel {
				directBitmapOriginalImage = new DirectBitmap(bitmap),
				directBitmapPictureBoxImage = new DirectBitmap(bitmap),
				layerName = "Background"
			};
			Layers.choosenLayer = layerModel;
			Layers.layers.Add(layerModel);
		}


		private void Panel_MouseWheel(object sender, MouseEventArgs e) {
			if (ModifierKeys == Keys.Control) {
				Point pictureBoxLocation = pictureBox.Location;
				if (e.Delta > 0 && zoomRatioCount < maxZoomRatio) {
					zoomRatioCount++;
					pictureBoxLocation.X -= pictureBox.Width / 32;
					pictureBoxLocation.Y -= pictureBox.Height / 32;
					pictureBox.Width += pictureBox.Width / 16;
					pictureBox.Height += pictureBox.Height / 16;
				} else if (zoomRatioCount > -maxZoomRatio) {
					zoomRatioCount--;
					pictureBoxLocation.X += pictureBox.Width / 32;
					pictureBoxLocation.Y += pictureBox.Height / 32;
					pictureBox.Width -= pictureBox.Width / 16;
					pictureBox.Height -= pictureBox.Height / 16;
				}
				pictureBox.Location = pictureBoxLocation;
				int percentage = (int) (pictureBox.Width / (double) originalPictureBoxSize * 100.0);
				toolStripStatusLabel_zoomRatio.Text = percentage + "%";
			}
		}

		private void Panel_MouseDown(object sender, MouseEventArgs e) {
			mousePosition = e.Location;
			Point currentPictureBoxLocation = pictureBox.Location;
			pictureBoxPosition = new Point(
				currentPictureBoxLocation.X - mousePosition.X,
				currentPictureBoxLocation.Y - mousePosition.Y);
		}

		private void Panel_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				int pictureBoxLocation_X = e.X, pictureBoxLocation_Y = e.Y;
				if (sender == panel) {
					pictureBoxLocation_X += pictureBoxPosition.X;
					pictureBoxLocation_Y += pictureBoxPosition.Y;
				} else {
					pictureBoxLocation_X += pictureBox.Left - mousePosition.X;
					pictureBoxLocation_Y += pictureBox.Top - mousePosition.Y;
				}

				if (pictureBox.Width < panel.Width && pictureBox.Height < panel.Height) {
					int pictureBoxHalfWidth = pictureBox.Width / 2;
					int pictureBoxHalfHeight = pictureBox.Height / 2;

					if (pictureBoxLocation_X < -pictureBoxHalfWidth) {
						pictureBoxLocation_X = -pictureBoxHalfWidth;
					} else if (pictureBoxLocation_X > panel.Width - pictureBoxHalfWidth) {
						pictureBoxLocation_X = panel.Width - pictureBoxHalfWidth;
					}

					if (pictureBoxLocation_Y < -pictureBoxHalfHeight) {
						pictureBoxLocation_Y = -pictureBoxHalfHeight;
					} else if (pictureBoxLocation_Y > panel.Height - pictureBoxHalfHeight) {
						pictureBoxLocation_Y = panel.Height - pictureBoxHalfHeight;
					}
				} else {
					int panelHalfWidth = panel.Width / 2;
					int panelHalfHeight = panel.Height / 2;

					if (pictureBoxLocation_X + pictureBox.Width < panelHalfWidth) {
						pictureBoxLocation_X = panelHalfWidth - pictureBox.Width;
					} else if (pictureBoxLocation_X > panelHalfWidth) {
						pictureBoxLocation_X = panelHalfWidth;
					}

					if (pictureBoxLocation_Y + pictureBox.Height < panelHalfHeight) {
						pictureBoxLocation_Y = panelHalfHeight - pictureBox.Height;
					} else if (pictureBoxLocation_Y > panelHalfHeight) {
						pictureBoxLocation_Y = panelHalfHeight;
					}
				}
				pictureBox.Location = new Point(pictureBoxLocation_X, pictureBoxLocation_Y);
			}
			toolStripStatusLabel_mousePosition.Text =
				sender == pictureBox ? e.X + ", " + e.Y :
				e.X - pictureBox.Left + ", " + (e.Y - pictureBox.Top);
		}


		private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog {
				Filter = "Image Files (*.png; *.jpg; *.bmp; *.gif)|*.png; *.jpg; *.bmp; *.gif|" +
				"PNG (*.png)|*.png|" +
				"JPEG (*.jpg)|*.jpg|" +
				"BMP (*.bmp)|*.bmp|" +
				"GIF (*.gif)|*.gif",
				RestoreDirectory = true
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				bool isPNG = openFileDialog.FileName.ToLower().Contains(".png");
				Bitmap bitmap = new Bitmap(openFileDialog.FileName);
				DirectBitmap directBitmap = new DirectBitmap(bitmap);
				Layers.choosenLayer.directBitmapOriginalImage = directBitmap;
				Layers.choosenLayer.directBitmapPictureBoxImage = directBitmap;
				Parallel.Invoke(ResizeAllImages);
				Parallel.Invoke(MergeLayers);

				originalPictureBoxSize = Layers.choosenLayer.directBitmapPictureBoxImage.Width;
				toolStripStatusLabel_pictureBoxImageSize.Text =
					Layers.choosenLayer.directBitmapPictureBoxImage.Width + " x " +
					Layers.choosenLayer.directBitmapPictureBoxImage.Height;
				toolStripStatusLabel_zoomRatio.Text = "100%";
				zoomRatioCount = 0;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new SaveFileDialog {
				Filter = "PNG (*.png)|*.png|" +
				"JPEG (*.jpg)|*.jpg|" +
				"BMP (*.bmp)|*.bmp|" +
				"GIF (*.gif)|*.gif",
				RestoreDirectory = true
			};

			ImageFormat imageFormat = ImageFormat.Png;
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				string ext = System.IO.Path.GetExtension(saveFileDialog.FileName);
				switch (ext) {
					case ".jpg":
						imageFormat = ImageFormat.Jpeg;
						break;
					case ".bmp":
						imageFormat = ImageFormat.Bmp;
						break;
					case ".gif":
						imageFormat = ImageFormat.Gif;
						break;
				}
				pictureBox.Image.Save(saveFileDialog.FileName, imageFormat);
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		//public void SetMaximumProgressValue(int maximum) {
		//	toolStripProgressBar.Maximum = maximum;
		//}

		//public void IncreaseProgressValue() {
		//	toolStripProgressBar.Value += 1;
		//}

		//public void SetProgress(int progress) {
		//	if (progress < toolStripProgressBar.Minimum ||
		//		progress > toolStripProgressBar.Maximum) {
		//		toolStripProgressBar.Enabled = false;
		//		toolStripProgressBar.Value = 0;
		//	} else {
		//		toolStripProgressBar.Enabled = true;
		//		toolStripProgressBar.Value = progress;
		//	}
		//}


		private void AddNewLayerInLayersList() {
			Bitmap bitmap;
			if (Layers.choosenLayer != null) {
				Console.WriteLine("Width: " + pictureBox.Width + "; Height: " + pictureBox.Height);
				bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
				pictureBox.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
			} else {
				bitmap = new Bitmap(650, 351);
				pictureBox.Size = new Size(650, 351);
			}
			using (Graphics graphics = Graphics.FromImage(bitmap)) {
				graphics.Clear(Color.White);
			}
			pictureBox.Image = bitmap;

			LayerModel newLayer = new LayerModel {
				directBitmapOriginalImage = new DirectBitmap(bitmap),
				directBitmapPictureBoxImage = new DirectBitmap(bitmap),
				layerName = "Layer " + (Layers.layers.Count + 1)
			};

			if (Layers.choosenLayer == null) {
				Layers.layers.Add(newLayer);
			} else {
				Layers.layers.Insert(Layers.layers.IndexOf(Layers.choosenLayer) + 1, newLayer);
			}
			Layers.choosenLayer = newLayer;
			LayerSwitcherController();
		}

		private void RemoveLayerFromLayersList() {
			LayerModel nextChoosenLayer = null;
			if (Layers.layers.Count > 1) {
				if (Layers.layers[0] == Layers.choosenLayer) {
					nextChoosenLayer = Layers.layers[1];
				} else {
					for (int i = 0; i < Layers.layers.Count - 1; i++) {
						if (Layers.layers[i + 1] == Layers.choosenLayer) {
							nextChoosenLayer = Layers.layers[i];
							break;
						}
					}
				}
			}
			Layers.choosenLayer.directBitmapOriginalImage.Dispose();
			Layers.choosenLayer.directBitmapPictureBoxImage.Dispose();
			bool unused = Layers.layers.Remove(Layers.choosenLayer);
			Layers.choosenLayer = nextChoosenLayer;
			LayerSwitcherController();
		}

		private void DuplicateLayerFromLayerList() {
			Console.WriteLine(Layers.choosenLayer.directBitmapPictureBoxImage.Bitmap.Width);
			LayerModel cloneLayer = (LayerModel) Layers.choosenLayer.Clone();
			Layers.layers.Insert(Layers.layers.IndexOf(Layers.choosenLayer) + 1, cloneLayer);
			LayerSwitcherController();
		}

		public void LayerSwitcherController() {
			if (Layers.layers.Count > 1) {
				LayerModel topLayer = Layers.layers[Layers.layers.Count - 1];
				LayerModel BottomLayer = Layers.layers[0];

				if (Layers.choosenLayer != topLayer) {
					goToTopLayerToolStripMenuItem.Enabled = true;
					goToLayerAboveToolStripMenuItem.Enabled = true;
				} else {
					goToTopLayerToolStripMenuItem.Enabled = false;
					goToLayerAboveToolStripMenuItem.Enabled = false;
				}
				if (Layers.choosenLayer != BottomLayer) {
					goToBottomLayerToolStripMenuItem.Enabled = true;
					goToLayerBelowToolStripMenuItem.Enabled = true;
				} else {
					goToBottomLayerToolStripMenuItem.Enabled = false;
					goToLayerBelowToolStripMenuItem.Enabled = false;
				}
			} else {
				goToTopLayerToolStripMenuItem.Enabled = false;
				goToLayerAboveToolStripMenuItem.Enabled = false;
				goToBottomLayerToolStripMenuItem.Enabled = false;
				goToLayerBelowToolStripMenuItem.Enabled = false;
			}

			SetCurvesToolStripMenuItemEnabled();
		}

		public void SetCurvesToolStripMenuItemEnabled() {
			curvesToolStripMenuItem.Enabled = Layers.choosenLayer != null && Layers.choosenLayer.isVisible;
		}


		private void LayersToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
			if (layersForm == null) {
				layersForm = new LayersForm(showLayersPanelToolStripMenuItem, this);
				layersForm.Show();
			} else {
				layersForm.Close();
				layersForm = null;
			}
		}

		private void AddNewLayerToolStripMenuItem_Click(object sender, EventArgs e) {
			AddNewLayerInLayersList();
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			if (Layers.layers.Count == 1) {
				deleteLayerToolStripMenuItem.Enabled = true;
				duplicateLayerToolStripMenuItem.Enabled = true;
				layerPropertiesToolStripMenuItem.Enabled = true;
				pictureBox.Visible = true;
				pictureBox.Enabled = true;
				panel.Enabled = true;
			}
		}

		private void DeleteLayerToolStripMenuItem_Click(object sender, EventArgs e) {
			RemoveLayerFromLayersList();
			Parallel.Invoke(MergeLayers);

			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			if (Layers.layers.Count == 0) {
				deleteLayerToolStripMenuItem.Enabled = false;
				duplicateLayerToolStripMenuItem.Enabled = false;
				layerPropertiesToolStripMenuItem.Enabled = false;
				pictureBox.Visible = false;
				pictureBox.Enabled = false;
				panel.Enabled = false;
			}
		}

		private void DuplicateLayerToolStripMenuItem_Click(object sender, EventArgs e) {
			DuplicateLayerFromLayerList();
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			if (Layers.layers.Count == 0) {
				deleteLayerToolStripMenuItem.Enabled = false;
				duplicateLayerToolStripMenuItem.Enabled = false;
				layerPropertiesToolStripMenuItem.Enabled = false;
				pictureBox.Visible = false;
				pictureBox.Enabled = false;
				panel.Enabled = false;
			}
		}

		private void MergeLayerDownToolStripMenuItem_Click(object sender, EventArgs e) {

		}


		private void GoToTopLayerToolStripMenuItem_Click(object sender, EventArgs e) {
			Layers.choosenLayer = Layers.layers[Layers.layers.Count - 1];
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			LayerSwitcherController();
		}

		private void GoToLayerAboveToolStripMenuItem_Click(object sender, EventArgs e) {
			Layers.choosenLayer = Layers.layers[Layers.layers.IndexOf(Layers.choosenLayer) + 1];
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			LayerSwitcherController();
		}

		private void GoToLayerBelowToolStripMenuItem_Click(object sender, EventArgs e) {
			Layers.choosenLayer = Layers.layers[Layers.layers.IndexOf(Layers.choosenLayer) - 1];
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			LayerSwitcherController();
		}

		private void GoToBottomLayerToolStripMenuItem_Click(object sender, EventArgs e) {
			Layers.choosenLayer = Layers.layers[0];
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			LayerSwitcherController();
		}


		private void MoveLayerToTopToolStripMenuItem_Click(object sender, EventArgs e) {
			LayerModel topLayerModel = (LayerModel) Layers.layers[Layers.layers.Count - 1].Clone();
			LayerModel currentLayer = (LayerModel) Layers.choosenLayer.Clone();
			Layers.layers[Layers.layers.Count - 1] = currentLayer;
			Layers.layers[Layers.layers.IndexOf(Layers.choosenLayer)] = topLayerModel;
			Layers.choosenLayer = Layers.layers[Layers.layers.Count - 1];
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
			LayerSwitcherController();
		}

		private void MoveLayerUpToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void MoveLayerDownToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void MoveLayerToBottomToolStripMenuItem_Click(object sender, EventArgs e) {

		}


		private void LayerPropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new LayerPropertiesForm(Layers.choosenLayer, this).ShowDialog();
			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
		}


		private void ResizeAllImages() {
			int maxWidth = 0;
			int maxHeight = 0;

			foreach (LayerModel layerModel in Layers.layers) {
				if (layerModel.directBitmapOriginalImage.Width > maxWidth) {
					maxWidth = layerModel.directBitmapOriginalImage.Width;
				}
				if (layerModel.directBitmapOriginalImage.Height > maxHeight) {
					maxHeight = layerModel.directBitmapOriginalImage.Height;
				}
			}

			foreach (LayerModel layerModel in Layers.layers) {
				DirectBitmap directBitmap = layerModel.directBitmapPictureBoxImage;
				Bitmap resizedBitmap = new Bitmap(directBitmap.Bitmap, maxWidth, maxHeight);
				layerModel.directBitmapPictureBoxImage = new DirectBitmap(resizedBitmap);
				directBitmap.Dispose();
			}
			pictureBox.Size = new Size(maxWidth, maxHeight);

			if (layersForm != null) {
				Parallel.Invoke(layersForm.UpdateLayersList);
			}
		}

		public void MergeLayers() {
			DirectBitmap result = null;
			List<LayerModel> layerModelList = GetVisibleLayerModels();

			if (layerModelList.Count > 1) {
				for (int i = 0; i < layerModelList.Count - 1; i++) {
					BlendModes blendModes = i == 0
						? new BlendModes(
							Layers.layers[Layers.layers.IndexOf(layerModelList[i + 1])],
							Layers.layers[Layers.layers.IndexOf(layerModelList[i])],
							false)
						: new BlendModes(
							Layers.layers[Layers.layers.IndexOf(layerModelList[i + 1])],
							Layers.layers[Layers.layers.IndexOf(layerModelList[i])],
							false, result);
					result = GetDirectBitmapWithBlendMode(
						blendModes,
						Layers.layers[Layers.layers.IndexOf(layerModelList[i + 1])].blendMode);
				}
			} else if (layerModelList.Count == 1) {
				LayerModel layerModel = new LayerModel {
					opacity = 0,
					directBitmapPictureBoxImage = new DirectBitmap(
						layerModelList[0].directBitmapPictureBoxImage.Width,
						layerModelList[0].directBitmapPictureBoxImage.Height)
				};
				BlendModes blendModes = new BlendModes(layerModelList[0], layerModel, true);
				result = GetDirectBitmapWithBlendMode(blendModes, layerModelList[0].blendMode);
				layerModel.directBitmapPictureBoxImage.Dispose();
			} else {
				LayerModel layerModel = new LayerModel {
					opacity = 0,
					directBitmapPictureBoxImage = new DirectBitmap(
						pictureBox.Width, pictureBox.Height)
				};
				BlendModes blendModes = new BlendModes(layerModel, layerModel, false);
				result = GetDirectBitmapWithBlendMode(blendModes, 0);
				layerModel.directBitmapPictureBoxImage.Dispose();
			}

			pictureBox.Image.Dispose();
			Bitmap resultBitmap = new Bitmap(result.Bitmap);
			pictureBox.Image = resultBitmap;
			result.Dispose();
		}


		private List<LayerModel> GetVisibleLayerModels() {
			List<LayerModel> result = new List<LayerModel>();
			for (int i = 0; i < Layers.layers.Count; i++) {
				LayerModel layer = Layers.layers[i];
				if (layer.isVisible) {
					result.Add(layer);
				}
			}
			return result;
		}

		private DirectBitmap GetDirectBitmapWithBlendMode(BlendModes blendModes, int blendMode) {
			switch (blendMode) {
				case 0:
					return blendModes.Normal();
				case 1:
					return blendModes.Multiply();
				case 2:
					return blendModes.Additive();
				case 3:
					return blendModes.Overlay();
				case 4:
					return blendModes.Difference();
				case 5:
					return blendModes.Negation();
				case 6:
					return blendModes.Lighten();
				case 7:
					return blendModes.Darken();
				case 8:
					return blendModes.Screen();
			}
			return null;
		}


		private void CurvesToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new CurvesForm(this).ShowDialog();
		}

		private void BinarizationToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new BinarizationForm(this).ShowDialog();
		}

		private void MatrixToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new MatrixForm(this).ShowDialog();
		}

		private void GaussianBlurToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new GaussianBlurForm(this).ShowDialog();
		}

		private void FourierTransformToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult unused = new FourierTransformForm(this).ShowDialog();
		}
	}
}
using Paint.Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class LayersForm : Form {
		private readonly int sizeOffsetWithScrollBar = 23;
		private readonly int sizeOffsetWithoutScrollBar = 6;

		private readonly MainForm mainForm;
		private readonly ToolStripMenuItem showLayersPanelToolStripMenuItem;

		public LayersForm(ToolStripMenuItem showLayersPanelToolStripMenuItem, MainForm mainForm) {
			InitializeComponent();
			this.showLayersPanelToolStripMenuItem = showLayersPanelToolStripMenuItem;
			this.mainForm = mainForm;
			UpdateLayersList();
		}


		public void UpdateLayersList() {
			flowLayoutPanel.Controls.Clear();
			foreach (LayerModel layerModel in Layers.layers) {
				AddNewLayer(layerModel);
			}
			UpdateLayersView();
		}

		private void ResizePanel(LayerModel layerModel) {
			layerModel.layerPanel.Width = flowLayoutPanel.Height / Layers.layers.Count < 56
				? flowLayoutPanel.Width - sizeOffsetWithScrollBar
				: flowLayoutPanel.Width - sizeOffsetWithoutScrollBar;
		}

		private void AddNewLayer(LayerModel layerModel) {
			Panel panel = new Panel {
				Width = flowLayoutPanel.Height / (Layers.layers.Count + 1) < 56 ?
				flowLayoutPanel.Width - sizeOffsetWithScrollBar :
				flowLayoutPanel.Width - sizeOffsetWithoutScrollBar,
				Height = 50,
				BackColor = Color.LightGray,
			};

			Bitmap originalBitmap = layerModel.directBitmapPictureBoxImage.Bitmap;
			float divider = Math.Max(originalBitmap.Width, originalBitmap.Height) / 44.0f;
			Bitmap miniatureBitmap = new Bitmap(originalBitmap,
				(int) (originalBitmap.Width / divider),
				(int) (originalBitmap.Height / divider));
			PictureBox miniature = new PictureBox {
				Image = miniatureBitmap,
				Size = new Size(50, 50),
				Enabled = false,
				Location = new Point(
				(50 - miniatureBitmap.Width) / 2,
				(50 - miniatureBitmap.Height) / 2)
			};

			Label layerName = new Label {
				Size = new Size(panel.Width - miniature.Width - 20, 50),
				Location = new Point(miniature.Right, 0),
				Enabled = false,
				Text = layerModel.layerName,
				TextAlign = ContentAlignment.MiddleLeft,
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
			};

			CheckBox checkBox = new CheckBox {
				Size = new Size(20, 20),
				Location = new Point(miniature.Width + layerName.Width, 15),
				Padding = new Padding(3, 0, 0, 0),
				Anchor = AnchorStyles.Right,
				Checked = layerModel.isVisible,
				AutoSize = false,
				Text = "",
			};
			checkBox.CheckedChanged += new EventHandler((sender, e) => CheckBox_CheckedChanged(panel, e));

			panel.Controls.Add(miniature);
			panel.Controls.Add(layerName);
			panel.Controls.Add(checkBox);
			panel.Click += new EventHandler(LayerPanel_Click);
			panel.DoubleClick += new EventHandler(LayerPanel_DoubleClick);
			foreach (Control element in panel.Controls) {
				if (element != checkBox) {
					element.Click += new EventHandler((sender, e) => LayerPanel_Click(panel, e));
					element.Click += new EventHandler((sender, e) => LayerPanel_DoubleClick(panel, e));
				}
			}

			layerModel.layerPanel = panel;
			flowLayoutPanel.Controls.Add(panel);
			ResizePanel(layerModel);
		}


		private void UpdateLayersView() {
			foreach (LayerModel layerModel in Layers.layers) {
				layerModel.layerPanel.BackColor = Color.LightGray;
			}
			if (Layers.choosenLayer != null) {
				Layers.choosenLayer.layerPanel.BackColor = Color.Gray;
			}
		}

		private void LayerPanel_Click(object sender, EventArgs e) {
			Layers.choosenLayer.layerPanel.BackColor = Color.LightGray;
			Panel panel = (Panel) sender;
			panel.BackColor = Color.Gray;
			LayerModel clickedLayer = Layers.GetLayerByPanel(panel);
			Layers.choosenLayer = Layers.layers[Layers.layers.IndexOf(clickedLayer)];
			mainForm.LayerSwitcherController();
			mainForm.SetCurvesToolStripMenuItemEnabled();
		}

		private void LayerPanel_DoubleClick(object sender, EventArgs e) {
			DialogResult unused = new LayerPropertiesForm(Layers.GetLayerByPanel((Panel) sender), mainForm).ShowDialog();
			UpdateLayersList();
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e) {
			LayerModel layerModel = Layers.GetLayerByPanel((Panel) sender);
			layerModel.isVisible = ((CheckBox) layerModel.layerPanel.Controls[2]).Checked;
			Parallel.Invoke(mainForm.MergeLayers);
			mainForm.SetCurvesToolStripMenuItemEnabled();
		}


		private void LayersForm_FormClosed(object sender, FormClosedEventArgs e) {
			showLayersPanelToolStripMenuItem.Checked = false;
		}


		private void LayersForm_Resize(object sender, EventArgs e) {
			foreach (LayerModel layerModel in Layers.layers) {
				ResizePanel(layerModel);
			}
		}
	}
}

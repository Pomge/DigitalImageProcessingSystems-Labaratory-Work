using Paint.Classes;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Forms {
	public partial class LayerPropertiesForm : Form {
		private readonly LayerModel layerModel;
		private readonly MainForm mainForm;

		public LayerPropertiesForm(LayerModel layerModel, MainForm mainForm) {
			InitializeComponent();
			this.layerModel = layerModel;
			this.mainForm = mainForm;
			Closing += Form_Closing;

			labelLayerName.Text = layerModel.layerName;
			comboBoxLayerMode.SelectedIndex = layerModel.blendMode;
			trackBarOpacity.Value = layerModel.opacity;
			numericUpDownOpacity.Value = layerModel.opacity;
			checkBoxVisible.Checked = layerModel.isVisible;
			checkBoxChannelR.Checked = layerModel.channel_R;
			checkBoxChannelG.Checked = layerModel.channel_G;
			checkBoxChannelB.Checked = layerModel.channel_B;
		}


		private void CheckBoxVisible_CheckedChanged(object sender, System.EventArgs e) {
			layerModel.isVisible = ((CheckBox) sender).Checked;
			Parallel.Invoke(mainForm.MergeLayers);
			mainForm.SetCurvesToolStripMenuItemEnabled();
		}

		private void ComboBoxLayerMode_SelectedIndexChanged(object sender, System.EventArgs e) {
			layerModel.blendMode = ((ComboBox) sender).SelectedIndex;
			Parallel.Invoke(mainForm.MergeLayers);
			mainForm.SetCurvesToolStripMenuItemEnabled();
		}

		private void TrackBarOpacity_Scroll(object sender, System.EventArgs e) {
			int opacity = ((TrackBar) sender).Value;
			numericUpDownOpacity.Value = opacity;
			layerModel.opacity = opacity;
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void NumericUpDownOpacity_ValueChanged(object sender, System.EventArgs e) {
			int opacity = (int) ((NumericUpDown) sender).Value;
			trackBarOpacity.Value = opacity;
			layerModel.opacity = opacity;
			Parallel.Invoke(mainForm.MergeLayers);
		}


		private void CheckBoxChannelR_CheckedChanged(object sender, System.EventArgs e) {
			layerModel.channel_R = ((CheckBox) sender).Checked;
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void CheckBoxChannelG_CheckedChanged(object sender, System.EventArgs e) {
			layerModel.channel_G = ((CheckBox) sender).Checked;
			Parallel.Invoke(mainForm.MergeLayers);
		}

		private void CheckBoxChannelB_CheckedChanged(object sender, System.EventArgs e) {
			layerModel.channel_B = ((CheckBox) sender).Checked;
			Parallel.Invoke(mainForm.MergeLayers);
		}


		private void Form_Closing(object sender, CancelEventArgs e) {
			layerModel.layerName = labelLayerName.Text;
		}
	}
}

using System.Collections.Generic;
using System.Windows.Forms;

namespace Paint.Classes {
	public static class Layers {
		public static LayerModel choosenLayer;
		public static List<LayerModel> layers = new List<LayerModel>();

		public static LayerModel GetLayerByPanel(Panel panel) {
			foreach (LayerModel layerModel in layers) {
				if (layerModel.layerPanel == panel) {
					return layerModel;
				}
			}
			return null;
		}
	}
}

using System;
using System.Windows.Forms;

namespace Paint.Classes {
	public class LayerModel : ICloneable {
		public DirectBitmap directBitmapOriginalImage;
		public DirectBitmap directBitmapPictureBoxImage;
		public Panel layerPanel;

		public string layerName;
		public bool isVisible = true;
		public int blendMode = 0;
		public int opacity = 255;

		public bool channel_R = true;
		public bool channel_G = true;
		public bool channel_B = true;

		public object Clone() {
			return MemberwiseClone();
		}
	}
}

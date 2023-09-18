using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint {
	public class MyPictureBox : PictureBox {
		public MyPictureBox() {
			InterpolationMode = InterpolationMode.NearestNeighbor;
		}

		[Category("Behavior")]
		[DefaultValue(InterpolationMode.NearestNeighbor)]
		public InterpolationMode InterpolationMode { get; set; }

		protected override void OnPaint(PaintEventArgs pe) {
			pe.Graphics.InterpolationMode = InterpolationMode;
			base.OnPaint(pe);
		}
	}
}

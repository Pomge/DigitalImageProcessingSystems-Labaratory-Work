using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Paint.Classes {
	public class DirectBitmap : IDisposable {
		public Bitmap Bitmap { get; private set; }
		public int[] Bits { get; private set; }
		public bool Disposed { get; private set; }
		public int Height { get; private set; }
		public int Width { get; private set; }


		protected GCHandle BitsHandle { get; private set; }


		public DirectBitmap(int width, int height) {
			Width = width;
			Height = height;
			Bits = new int[Width * Height];
			BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
			Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
			using (Graphics graphics = Graphics.FromImage(Bitmap)) {
				graphics.Clear(Color.White);
			}
		}

		public DirectBitmap(Bitmap bitmap) {
			Width = bitmap.Width;
			Height = bitmap.Height;

			bitmap.MakeTransparent(Color.White);

			Bits = new int[Width * Height];
			BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
			Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
			using (Graphics graphics = Graphics.FromImage(Bitmap)) {
				graphics.DrawImage(bitmap, 0, 0);
			}

			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					if (GetPixel(i, j).A == 0) {
						SetPixel(i, j, Color.White);
					}
				}
			}
		}


		public void SetPixel(int x, int y, Color color) {
			int index = x + (y * Width);
			Bits[index] = color.ToArgb();
		}

		public Color GetPixel(int x, int y) {
			int index = x + (y * Width);
			int color = Bits[index];

			return Color.FromArgb(color);
		}


		public void Dispose() {
			if (Disposed) {
				return;
			}
			Disposed = true;
			Bitmap.Dispose();
			BitsHandle.Free();
		}
	}
}

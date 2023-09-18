using System;
using System.Drawing;

namespace Paint.Classes {
	class BlendModes {
		private readonly DirectBitmap bitmapAbove;
		private readonly DirectBitmap bitmapBelow;
		private readonly int alphaAboveInteger;
		private readonly int alphaBelowInteger;
		private readonly bool channel_R;
		private readonly bool channel_G;
		private readonly bool channel_B;

		private readonly bool isSingleLayer;
		private readonly float alphaAboveFloat;
		private readonly float alphaBelowFloat;
		private readonly float alphaOverallFloat;
		private readonly int alphaOverallInteger;


		public BlendModes(LayerModel layerModelAbove, LayerModel layerModelBelow, bool isSingleLayer, DirectBitmap resultBefore = null) {
			bitmapAbove = layerModelAbove.directBitmapPictureBoxImage;
			bitmapBelow = resultBefore ?? layerModelBelow.directBitmapPictureBoxImage;
			alphaAboveInteger = layerModelAbove.opacity;
			alphaBelowInteger = layerModelBelow.opacity;
			channel_R = layerModelAbove.channel_R;
			channel_G = layerModelAbove.channel_G;
			channel_B = layerModelAbove.channel_B;

			this.isSingleLayer = isSingleLayer;
			alphaAboveFloat = alphaAboveInteger / 255.0f;
			alphaBelowFloat = alphaBelowInteger / 255.0f;
			alphaOverallFloat = alphaAboveFloat + (alphaBelowFloat * (1.0f - alphaAboveFloat));
			alphaOverallInteger = (int) (alphaOverallFloat * 255.0f);
		}


		public DirectBitmap Normal() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float colorAbove_R = colorAbove.R * alphaAboveFloat;
					float colorAbove_G = colorAbove.G * alphaAboveFloat;
					float colorAbove_B = colorAbove.B * alphaAboveFloat;

					float colorBelow_R = colorBelow.R * alphaBelowFloat;
					float colorBelow_G = colorBelow.G * alphaBelowFloat;
					float colorBelow_B = colorBelow.B * alphaBelowFloat;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						if (alphaOverallFloat != 0.0) {
							R = channel_R ? (int) Math.Min((colorAbove_R +
								(colorBelow_R * (1.0f - alphaAboveFloat)))
								/ alphaOverallFloat, 255) : 0;
							G = channel_G ? (int) Math.Min((colorAbove_G +
								(colorBelow_G * (1.0f - alphaAboveFloat)))
								/ alphaOverallFloat, 255) : 0;
							B = channel_B ? (int) Math.Min((colorAbove_B +
								(colorBelow_B * (1.0f - alphaAboveFloat)))
								/ alphaOverallFloat, 255) : 0;
						} else {
							R = 255;
							G = 255;
							B = 255;
						}
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Multiply() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
							((premultipliedColorAbove_R * premultipliedColorBelow_R) +
							complementaryColorAbove_R + complementaryColorBelow_R) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							((premultipliedColorAbove_G * premultipliedColorBelow_G) +
							complementaryColorAbove_G + complementaryColorBelow_G) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							((premultipliedColorAbove_B * premultipliedColorBelow_B) +
							complementaryColorAbove_B + complementaryColorBelow_B) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Additive() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
					   (premultipliedColorAbove_R + premultipliedColorBelow_R) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
						   (premultipliedColorAbove_G + premultipliedColorBelow_G) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
						   (premultipliedColorAbove_B + premultipliedColorBelow_B) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Overlay() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R = 0, G = 0, B = 0;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						if (channel_R) {
							R = premultipliedColorAbove_R * 2.0f <= alphaAboveFloat
								? Math.Min((int) (
									((2.0f * premultipliedColorAbove_R * premultipliedColorBelow_R) +
									complementaryColorAbove_R + complementaryColorBelow_R) * 255.0f), 255)
								: Math.Min((int) (
									(complementaryColorAbove_R + complementaryColorBelow_R -
									(2.0f *
									(alphaAboveFloat - premultipliedColorAbove_R) *
									(alphaBelowFloat - premultipliedColorBelow_R)) +
									(alphaAboveFloat * alphaBelowFloat)) * 255.0f), 255);
						}
						if (channel_G) {
							G = premultipliedColorAbove_G * 2.0f <= alphaAboveFloat
								? Math.Min((int) (
									((2.0f * premultipliedColorAbove_G * premultipliedColorBelow_G) +
									complementaryColorAbove_G + complementaryColorBelow_G) * 255.0f), 255)
								: Math.Min((int) (
									(complementaryColorAbove_G + complementaryColorBelow_G -
									(2.0f *
									(alphaAboveFloat - premultipliedColorAbove_G) *
									(alphaBelowFloat - premultipliedColorBelow_G)) +
									(alphaAboveFloat * alphaBelowFloat)) * 255.0f), 255);
						}
						if (channel_B) {
							B = premultipliedColorAbove_B * 2.0f <= alphaAboveFloat
								? Math.Min((int) (
									((2.0f * premultipliedColorAbove_B * premultipliedColorBelow_B) +
									complementaryColorAbove_B + complementaryColorBelow_B) * 255.0f), 255)
								: Math.Min((int) (
									(complementaryColorAbove_B + complementaryColorBelow_B -
									(2.0f *
									(alphaAboveFloat - premultipliedColorAbove_B) *
									(alphaBelowFloat - premultipliedColorBelow_B)) +
									(alphaAboveFloat * alphaBelowFloat)) * 255.0f), 255);
						}
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Difference() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
						(premultipliedColorAbove_R + premultipliedColorBelow_R -
						(2.0f * Math.Min(
							premultipliedColorAbove_R * alphaBelowFloat,
							premultipliedColorBelow_R * alphaAboveFloat))) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							(premultipliedColorAbove_G + premultipliedColorBelow_G -
							(2.0f * Math.Min(
								premultipliedColorAbove_G * alphaBelowFloat,
								premultipliedColorBelow_G * alphaAboveFloat))) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							(premultipliedColorAbove_B + premultipliedColorBelow_B -
							(2.0f * Math.Min(
								premultipliedColorAbove_B * alphaBelowFloat,
								premultipliedColorBelow_B * alphaAboveFloat))) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Negation() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
							((premultipliedColorAbove_R * alphaBelowFloat) +
							(premultipliedColorBelow_R * alphaAboveFloat) -
							(2.0f * premultipliedColorAbove_R * premultipliedColorBelow_R) +
							complementaryColorAbove_R + complementaryColorBelow_R) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							((premultipliedColorAbove_G * alphaBelowFloat) +
							(premultipliedColorBelow_G * alphaAboveFloat) -
							(2.0f * premultipliedColorAbove_G * premultipliedColorBelow_G) +
							complementaryColorAbove_G + complementaryColorBelow_G) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							((premultipliedColorAbove_B * alphaBelowFloat) +
							(premultipliedColorBelow_B * alphaAboveFloat) -
							(2.0f * premultipliedColorAbove_B * premultipliedColorBelow_B) +
							complementaryColorAbove_B + complementaryColorBelow_B) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Lighten() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
							(Math.Max(premultipliedColorAbove_R * alphaBelowFloat,
							premultipliedColorBelow_R * alphaAboveFloat) +
							complementaryColorAbove_R + complementaryColorBelow_R) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							(Math.Max(premultipliedColorAbove_G * alphaBelowFloat,
							premultipliedColorBelow_G * alphaAboveFloat) +
							complementaryColorAbove_G + complementaryColorBelow_G) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							(Math.Max(premultipliedColorAbove_B * alphaBelowFloat,
							premultipliedColorBelow_B * alphaAboveFloat) +
							complementaryColorAbove_B + complementaryColorBelow_B) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Darken() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					float complementaryColorAbove_R = GetComplementaryColor(colorAbove, alphaBelowInteger).R / 255.0f;
					float complementaryColorAbove_G = GetComplementaryColor(colorAbove, alphaBelowInteger).G / 255.0f;
					float complementaryColorAbove_B = GetComplementaryColor(colorAbove, alphaBelowInteger).B / 255.0f;

					float complementaryColorBelow_R = GetComplementaryColor(colorBelow, alphaAboveInteger).R / 255.0f;
					float complementaryColorBelow_G = GetComplementaryColor(colorBelow, alphaAboveInteger).G / 255.0f;
					float complementaryColorBelow_B = GetComplementaryColor(colorBelow, alphaAboveInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
							(Math.Min(premultipliedColorAbove_R * alphaBelowFloat,
							premultipliedColorBelow_R * alphaAboveFloat) +
							complementaryColorAbove_R + complementaryColorBelow_R) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							(Math.Min(premultipliedColorAbove_G * alphaBelowFloat,
							premultipliedColorBelow_G * alphaAboveFloat) +
							complementaryColorAbove_G + complementaryColorBelow_G) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							(Math.Min(premultipliedColorAbove_B * alphaBelowFloat,
							premultipliedColorBelow_B * alphaAboveFloat) +
							complementaryColorAbove_B + complementaryColorBelow_B) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}

		public DirectBitmap Screen() {
			DirectBitmap result = new DirectBitmap(bitmapAbove.Width, bitmapAbove.Height);

			for (int i = 0; i < result.Width; i++) {
				for (int j = 0; j < result.Height; j++) {
					Color colorAbove = bitmapAbove.GetPixel(i, j);
					Color colorBelow = bitmapBelow.GetPixel(i, j);

					float premultipliedColorAbove_R = GetPremultipliedColor(colorAbove, alphaAboveInteger).R / 255.0f;
					float premultipliedColorAbove_G = GetPremultipliedColor(colorAbove, alphaAboveInteger).G / 255.0f;
					float premultipliedColorAbove_B = GetPremultipliedColor(colorAbove, alphaAboveInteger).B / 255.0f;

					float premultipliedColorBelow_R = GetPremultipliedColor(colorBelow, alphaBelowInteger).R / 255.0f;
					float premultipliedColorBelow_G = GetPremultipliedColor(colorBelow, alphaBelowInteger).G / 255.0f;
					float premultipliedColorBelow_B = GetPremultipliedColor(colorBelow, alphaBelowInteger).B / 255.0f;

					int R, G, B;
					if (isSingleLayer) {
						R = channel_R ? colorAbove.R : 0;
						G = channel_G ? colorAbove.G : 0;
						B = channel_B ? colorAbove.B : 0;
					} else {
						R = channel_R ? Math.Min((int) (
							(premultipliedColorAbove_R + premultipliedColorBelow_R -
							(premultipliedColorAbove_R * premultipliedColorBelow_R)) * 255.0f), 255) : 0;
						G = channel_G ? Math.Min((int) (
							(premultipliedColorAbove_G + premultipliedColorBelow_G -
							(premultipliedColorAbove_G * premultipliedColorBelow_G)) * 255.0f), 255) : 0;
						B = channel_B ? Math.Min((int) (
							(premultipliedColorAbove_B + premultipliedColorBelow_B -
							(premultipliedColorAbove_B * premultipliedColorBelow_B)) * 255.0f), 255) : 0;
					}
					result.SetPixel(i, j, Color.FromArgb(alphaOverallInteger, R, G, B));
				}
			}
			return result;
		}


		private Color GetPremultipliedColor(Color color, int alpha) {
			float newAlpha = alpha / 255.0f;
			int color_R = (int) (color.R * newAlpha);
			int color_G = (int) (color.G * newAlpha);
			int color_B = (int) (color.B * newAlpha);

			return Color.FromArgb(255, color_R, color_G, color_B);
		}

		private Color GetComplementaryColor(Color color, int alpha) {
			float newAlpha = 1.0f - (alpha / 255.0f);
			int color_R = (int) (color.R * newAlpha);
			int color_G = (int) (color.G * newAlpha);
			int color_B = (int) (color.B * newAlpha);

			return Color.FromArgb(255, color_R, color_G, color_B);
		}


		public void Dispose() {
			bitmapAbove.Dispose();
			bitmapBelow.Dispose();
		}
	}
}

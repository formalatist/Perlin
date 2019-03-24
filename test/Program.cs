using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		int size = 512;

		// System.Diagnostics.Debugger.Launch();

		// for(int z = 0; z < 1; z++) {
		// 	for(int x = 0; x < size; x++) {
		// 		for(int y = 0; y < size; y++) {
		// 			int color = (int)(80*(1d+perlin.NoiseOctaves(
		// 				(double)x/32,
		// 				(double)y/32)));
		// 			bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
		// 		 }
		// 	}
		// 	bitmap.Save("octavesImage.png");
		// }

		CreateNoiseImage(size);
		CreateNoiseOctavesImage(size);
		CreateWorldMap(size);
		CreateMixedColoredOctaves(size);
		Console.ReadLine();
	}
  

	private static void CreateNoiseImage(int size) {
		Bitmap bitmap = new Bitmap(size, size);
		var perlin = new Perlin();
		for(int x = 0; x < size; x++) {
			for(int y = 0; y < size; y++) {
				int color = (int)(80*(1d+perlin.Noise(
					(double)x/32,
					(double)y/32)));
				bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
			}
		}
		bitmap.Save("images/Noise image.png");
	}

	private static void CreateNoiseOctavesImage(int size) {
		Bitmap bitmap = new Bitmap(size, size);
		var perlin = new Perlin();
		for(int x = 0; x < size; x++) {
			for(int y = 0; y < size; y++) {
				int color = (int)(80*(1d+perlin.NoiseOctaves(
					(double)x/32,
					(double)y/32,
					0.5d)));
				bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
			}
		}
		bitmap.Save("images/NoiseOctaves image.png");
	}

	private static void CreateWorldMap(int size) {
		Func<double, Color> GetColor = (color)=>{
			if(color < 0.35d) {//water
				return Color.FromArgb(60, 110, 200);
			} else if(color < 0.45d) {	//shallow water
				return Color.FromArgb(64, 104, 192);
			} else if(color < 0.48d) { //sand
				return Color.FromArgb(208, 207, 130);
			} else if(color < 0.55d) { //grass
				return Color.FromArgb(84, 150, 29);
			} else if(color < 0.6d) { //forrest
				return Color.FromArgb(61, 105, 22);
			} else if(color < 0.7d) { //mountain
				return Color.FromArgb(91, 68, 61);
			} else if(color < 0.87d) { //high mountain
				return Color.FromArgb(75, 58, 54);
			} else { //snow
				return Color.FromArgb(255, 254, 255);
			}
		};

		Bitmap bitmap = new Bitmap(size, size);
		var perlin = new Perlin();
		for(int x = 0; x < size; x++) {
			for(int y = 0; y < size; y++) {
				Color color = GetColor((1d+perlin.NoiseOctaves(
					(double)x/32,
					(double)y/32,
					0.5d))/2d);
				bitmap.SetPixel(x, y, color);
			}
		}
		bitmap.Save("images/WorldMap image.png");
	}

	private static void CreateMixedColoredOctaves(int size) {
		Bitmap bitmap = new Bitmap(size, size);
		var perlin = new Perlin();
		for(int x = 0; x < size; x++) {
			for(int y = 0; y < size; y++) {
				double colorScalar = (1d+perlin.NoiseOctaves(
					(double)x/32,
					05d,
					(double)y/32))/2d;
				int colorBlue = (int)(255*colorScalar*(double)x/size);
				int colorRed = (int)(255*colorScalar*(double)y/size);

				bitmap.SetPixel(x, y, Color.FromArgb(colorRed, 20, colorBlue));
			}
		}
		bitmap.Save("images/MixedColoredOctaves image.png");
	}
}
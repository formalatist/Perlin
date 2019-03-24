using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		var perlin = new Perlin();

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

}
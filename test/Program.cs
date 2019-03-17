using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		var perlin = new Perlin();

		int size = 1024;
		Bitmap bitmap = new Bitmap(size, size);

		// System.Diagnostics.Debugger.Launch();

		for(int z = 0; z < 240; z++) {

			for(int x = 0; x < size; x++) {
				for(int y = 0; y < size; y++) {
					int color = (int)(80*(1d+perlin.NoiseOctaves((double)x/64, (double)y/64, (double)z/64, 6)));
					
					bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
				 }
			}
			bitmap.Save("octaves" + z + ".png");
		}
		Console.ReadLine();
	}

}
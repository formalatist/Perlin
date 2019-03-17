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
					int color = (int)(127*(1d+perlin.NoiseTiled((double)x/64, (double)z/64, (double)y/64, 3)));
					// if(color < 0) {
					// 	Console.WriteLine(color);
					// 	color = 0;
					// } else if(color > 255) {
					// 	Console.WriteLine(color);
					// 	color = 255;
					// }
					bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
				 }
			}
			bitmap.Save("testTiled" + z + ".png");
		}

		Console.ReadLine();
	}

}
using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		var perlin = new Perlin();

		int size = 1024;
		Bitmap bitmap = new Bitmap(size, size);

		// System.Diagnostics.Debugger.Launch();

		for(int z = 0; z < 480; z++) {

			for(int x = 0; x < size; x++) {
				for(int y = 0; y < size; y++) {
					int color = (int)(127*(1d+perlin.Noise((double)x/128, (double)y/128, (double)z/120)));
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
			bitmap.Save("test" + z + ".png");
		}

		Console.ReadLine();
	}

}
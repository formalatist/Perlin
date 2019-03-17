using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		var perlin = new Perlin();

		int size = 256;
		Bitmap bitmap = new Bitmap(size, size);

		// System.Diagnostics.Debugger.Launch();

		for(int x = 0; x < size; x++) {
			for(int y = 0; y < size; y++) {
				int color = (int)(128*(1d+perlin.Noise((double)x/2, (double)y/2)));
				if(color < 0) {
					Console.WriteLine(color);
					color = 0;
				} else if(color > 255) {
					Console.WriteLine(color);
					color = 255;
				}
				bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
			 }
		}

		bitmap.Save("test.png");
		Console.ReadLine();
	}

}
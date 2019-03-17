using System;
using System.Drawing;

public class Program {
	
	public static void Main(string[] args) {
		Console.WriteLine("test");

		var perlin = new Perlin();

		Bitmap bitmap = new Bitmap(512, 512);

		for(int x = 0; x < 512; x++) {
			for(int y = 0; y < 512; y++) {
				int color = (int)(128*(1d+perlin.Noise((double)x/64, (double)y/64)));
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
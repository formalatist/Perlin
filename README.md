# Perlin Noise
This is a C# implementation of Perlins original noise algorithm. It gives continuous and tileable noise in 1-3 dimensions.

## Motivation
This project was created because i needed a good Perlin noise class for art creation and since the algorithm is simple enough i decided to implement it myself.
 
## Screenshots
# Using 2d noise to create a "world map"
![](/images/WorldMap-image.png?raw=true "2D world map created using noise with multiple octaves.")

Code for creating the above 2d map:
```C#
Bitmap bitmap = new Bitmap(size, size);
var perlin = new Perlin();
for(int x = 0; x < size; x++) {
	for(int y = 0; y < size; y++) {
	    //GetColor() takes in a double in the range 0..1 and returns the proper color
		Color color = GetColor((1d+perlin.NoiseOctaves(
			(double)x/32,
			(double)y/32,
			0.5d))/2d);
		bitmap.SetPixel(x, y, color);
	}
}
bitmap.Save("images/WorldMap-image.png");

Color GetColor = (color)=>{
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
```
# 3d noise being used to create a globe
![](/images/out.gif?raw=true "A 3d spinning globe, where light reflects of the ocean.")

# Difference between Perlin noise and random values (1d)
Random noise:

![](/images/Random-noise1d.png?raw=true "250 random values.")
Perlin noise:

![](/images/Perlin-noise1d.png?raw=true "250 Perlin noise values")

# Grayscale Perlin noise in 2d, 1 octave
![](/images/Noise-image.png?raw=true "Grayscale 2d Perlin noise, one octave.")

# Grayscale Perlin noise in 2d, 6 octaves
![](/images/NoiseOctaves-image.png?raw=true "Grayscale 2d Perlin noise, 6 octaves.")


## Features
The base Perlin class is generic over Gradient data types and Dot product implementations. Noise functions are often used in performance critical applications where providing custom implementations for these are usefull. A different implementation of Gradient and Dot product can be found in the *Original noise function* paper linked in Sources.

The provided subclass stores gradients as structs of doubles and performs dot product by component-wise multiplication.

## Code Example
To use the noise functions you have to create an instance of the Perlin class. By default all Perlin objects will use the same array for noise generation, which means two different instances of the Perlin class will create the same noise values for the same inputs.
```C#
Perlin perlin = new Perlin();

//Standard noise, provide the x, y and z coordinate to sample the noise func. y and z are optional parameters.
double noise = perlin.Noise(x, y, z);

//Creates noise that will seamlessly tile in all directions in all dimensions. tileRegion specifies the size of the region to "tile over", a larger value means it will take longer for the noise to repeat. y, z and tileRedion are optional parameters.
double noiseTiled = perlin.NoiseTiled(x, y, z, tileRegion);

//Samples the standard noise functions multiple times and adds the results together. Each sample is sampled at a higher frequency and lower amplitude, adding more and smaller features to the noise. numberOfOctaves determines how many times to sample the standard noise function. lacunarity specifies how quickly the frequency increases. persistence specifies how quickly the amplitude of consecutive samples decreases. All parameters except x are optional.
double noiseOctaves = perlin.NoiseOctaves(x, y, z, numberOfOctaves, lacunarity, persistence);

//Combines the Octaves and Tiled nosise functions to create tilable noise that consists of multiple octaves.
double noiseTiledOctaves = perlin.noiseTiledOctaves(x, y, z, tileRegion, numberOfOctaves, lacunarity, persistence);

```

## Sources
Ken Perlin. *Improving Noise*. https://mrl.nyu.edu/~perlin/paper445.pdf

Ken Perlin. Original noise function.
https://mrl.nyu.edu/~perlin/doc/oscar.html#noise

Wikipedia article on Perlin noise. https://en.wikipedia.org/wiki/Perlin_noise

Flafla2. *Understading Perlin Noise*.
https://flafla2.github.io/2014/08/09/perlinnoise.html
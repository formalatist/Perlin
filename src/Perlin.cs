using System;

public abstract class Perlin<GradientType> {

	//The function we use to smooth the interpolation between the
	//different corners of the cube. With a linear interpolation
	//we'll get hard edges.
	private Func<double, double> SmoothingFunction;
	private GradientType[] gradients;
	//Function that performs the dot product (inner product) of two 3D vectors
	//where one of the vectors is stored in the GradientType type.
	private Func<GradientType, double, double, double, double> Dot;

	protected Perlin(GradientType[] gradients, Func<GradientType, double, double, double, double> dot, Func<double, double> smoothingFunction) {
		this.gradients = gradients;
		this.Dot = dot;
		this.SmoothingFunction = smoothingFunction;
	}

	public double Noise(double x, double y, double z = 0.5d) {



		return 0;
	}


	private static double LinearlyInterpolate(double valueA, double valueB, double t) {
		return valueA + t*(valueB - valueA);
	}

	//Takes a val in the range 0..1 and returns an s-curve
	//in the range 0..1
	//from Perlins original paper TODO: add link to paper
	protected static double SmoothToSCurve(double val) {
		return val*val*val*(val*(val*6d-15d)+10d);
	}
}

//Performant Perlin class that stores gradients as ints
public class Perlin : Perlin<int> {

	private static int[] gradients = {5};

	public Perlin(Func<double, double> smoothingFunction) : base(gradients, Dot, smoothingFunction) {
		Console.WriteLine("Perlin<int>");
	}

	public Perlin() : this(SmoothToSCurve){}

	private static double Dot(int gradient, double x, double y, double z) {
		return 0d;
	}
}
using System;

public abstract class Perlin<GradientType> {

	//The function we use to smooth the interpolation between the
	//different corners of the cube. With a linear interpolation
	//we'll get hard edges.
	private Func<double, double> SmoothingFunction;

	internal int[] permuatationTable;
	//the defaultPermutationTable is 512 ints long and an contains values 0..255
	private static int[] defaultPermutationTable = {151,160,137,91,90,15,
   131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
   190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
   88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
   77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
   102,143,54,65,25,63,161,1,216,80,73,209,76,132,187,208,89,18,169,200,196,
   135,130,116,188,159,86,164,100,109,198,173,186,3,64,52,217,226,250,124,123,
   5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
   223,183,170,213,119,248,152,2,44,154,163,70,221,153,101,155,167,43,172,9,
   129,22,39,253,19,98,108,110,79,113,224,232,178,185,112,104,218,246,97,228,
   251,34,242,193,238,210,144,12,191,179,162,241,81,51,145,235,249,14,239,107,
   49,192,214,31,181,199,106,157,184,84,204,176,115,121,50,45,127,4,150,254,
   138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180};

	private GradientType[] gradients;
	//Function that performs the dot product (inner product) of two 3D vectors
	//where one of the vectors is stored in the GradientType type.
	private Func<GradientType, double, double, double, double> Dot;

	protected Perlin(GradientType[] gradients, Func<GradientType, double, double, double, double> dot, Func<double, double> smoothingFunction) {
		this.gradients = gradients;
		this.Dot = dot;
		this.SmoothingFunction = smoothingFunction;
		permuatationTable = defaultPermutationTable;
	}

	public double Noise(double x, double y = 0.5d, double z = 0.5d) {
		//determine what cube we are in
		int cubeX = (int)x & permuatationTable.Length/2;
		int cubeY = (int)y & permuatationTable.Length/2;
		int cubeZ = (int)z & permuatationTable.Length/2;


		return 0;
	}

	public void SetPermutationTable(int[] newPermutationTable) {
		permuatationTable = newPermutationTable;
	}

	private static double LinearlyInterpolate(double valueA, double valueB, double t) {
		return valueA + t*(valueB - valueA);
	}

	//Takes a val in the range 0..1 and returns an s-curve
	//in the range 0..1
	//This is a recommended replacement for the original 3t^2 - 2t^3
	//from https://mrl.nyu.edu/~perlin/paper445.pdf
	protected static double SmoothToSCurve(double val) {
		return val*val*val*(val*(val*6d-15d)+10d);
	}
}

public class Perlin : Perlin<Perlin.Vector3> {

	private static Vector3[] gradients = {new Vector3(0d,0d,0d)};

	public Perlin(Func<double, double> smoothingFunction) : base(gradients, Dot, smoothingFunction) {
		Console.WriteLine("Perlin<int>");
	}

	public Perlin() : this(SmoothToSCurve){}

	private static double Dot(Vector3 gradient, double x, double y, double z) {
		return gradient.x*x+gradient.y*y+gradient.z*z;
	}

	public struct Vector3{
		public double x, y, z;

		public Vector3(double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}
using System;
using static System.Math;
public class nn
{
    public int n; /* number of hidden neurons */
	public vector parameters; /* network parameters */
	Func<double,double> f; /* activation function */
	
	public nn(int N, Func<double,double> F)
	{
		this.n = N;
		this.f = F;
		this.parameters = new vector(n*3);
	}
	public vector getParams()
	{
		return parameters;
	}
	/* apply the network to input parameter x */
	public double feedforwad(double x) 
	{
		double y = 0;
		for(int i = 0; i<n; i++)
		{
			double a = parameters[i];
			double b = parameters[i+1];
			double w = parameters[i+2];
			y += f((x-a)/b)*w;
			// if(i == 1){
			// 	Console.WriteLine($"{a} {b} {w} {y}");
			//}
		}
		return y;
	} 

	/* train to interpolate the given table {x,y} */
	public void train(vector x, vector y)
	{
		Func<vector,double> cost = (p) =>
		{
			parameters = p;
			double sum = 0;
			for(int k = 0; k<x.size; k++)
			{
				sum += Pow(feedforwad(x[k])-y[k],2);
			};
			// for(int i=0;i<n;i++)
            //     sum += 0.001*(Pow(1/parameters[i*3+1],2) + Pow(parameters[i*3+2],2));
			return sum;
		};	
			vector v = parameters.copy();
			double eps = 1e-4;
			int steps = minimization.qnewton(cost,ref v, eps );
			parameters = v;
	}
}
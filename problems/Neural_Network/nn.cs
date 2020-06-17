using System;
using static System.Math;
public class nn
{
    public int n; /* number of hidden neurons */
	public vector parameters; /* network parameters */
	Func<double,double> f; /* activation function */
	Func<double,double> df; /* derivatived activation function */
	Func<double,double> F; /* integrated/antiderivatived activation function */
	
	// constructor for A
	public nn(int N, Func<double,double> F)
	{
		this.n = N;
		this.f = F;
		this.parameters = new vector(n*3);
	}
	// constructor for B
	public nn(int N, Func<double,double> f,Func<double,double> dF,Func<double,double> F)
	{
		this.n = N;
		this.f = f;
		this.df = dF;
		this.F = F;

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
			double a = parameters[3*i];
			double b = parameters[3*i+1];
			double w = parameters[3*i+2];
			y += f((x-a)/b)*w;
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
			return sum;
		};	
			vector v = parameters.copy();
			double eps = 1e-4;
			int steps = minimization.qnewton(cost,ref v, eps );
			parameters = v;
	}
	// feedforward that approximate the derivative
	public double ff_derivative(double x)
	{
		double y_prime = 0;
		for(int i = 0; i<n ; i++)
		{
			double a = parameters[3*i];
			double b = parameters[3*i+1];
			double w = parameters[3*i+2];
			y_prime += df((x-a)/b)*w/b;
		}
		return y_prime;
	}

	// feedforward that approximate the antiderivative
	public double ff_integrate(double x)
	{
		double y_master = 0;
		for(int i = 0; i<n ; i++)
		{
			double a = parameters[3*i];
			double b = parameters[3*i+1];
			double w = parameters[3*i+2];
			y_master += F((x-a)/b)*w*b;
		}
		return y_master;
	}

	
}
using System;
using static System.Math;
using System.Collections.Generic;
public static class Ode{
	public class Result{
		public List<double> xs; public List<vector> ys;
		public vector ya;
		public Result(List<double> x, List<vector> y, vector yas)
			{
				xs = x; ys = y; ya = yas;
			}
	}
	

 public static vector rkstep12(
	Func<double,vector,vector> f, /* the right-hand-side of dydt=f(t,y) */
	double t,                     /* the current value of the variable */
	vector yt,                    /* the current value y(t) of the sought function */
	double h,                     /* the step to be taken */
	vector err                    /* output: error estimate dy */
) 
{
    int n = yt.size;
	vector yh = new vector(n);
	vector hold = new vector(n);
	var k0 = f(t,yt);
	for(int i = 0; i< n; i++)
	{	
		hold[i] = yt[i] + k0[i]*h/2;
	}
	var k12 = f(t+h/2,hold);
	for(int i = 0; i<n; i++)
	{
		yh[i] = yt[i] + k12[i]*h;
	}
	for(int i = 0; i<n;i++)
	{
		err[i] = (k0[i]+ -k12[i])*h/2;
	}
	return yh;
}	   
public static Result driver(
	Func<double,vector,vector> f, /* right-hand-side of dydt=f(t,y) */
	double a,                     /* the start-point a */
	vector ya,                     /* y(a) */
	double b,                     /* the end-point of the integration */
	double h,                      /* initial step-size */
	double acc,                   /* absolute accuracy goal */
	double eps,
	int maxsteps)                  /* relative accuracy goal */
{
	int n = ya.size;
	List<double> xlist = new List<double>(maxsteps);
	List<vector> ylist = new List<vector>(maxsteps);	
	xlist.Add(a);
	ylist.Add(ya);
	int k = 0;
	var err = new vector(n);
	while(xlist[k]<b)
	{
		double x = xlist[k];
		if(x+h>b)
		{
			h = b-x;
		}
		ya = rkstep12(f,x,ya,h,err);
		double sum_err = 0, sum_yh = 0;
		for(int i = 0;i<n;i++)
		{
			sum_err += err[i]*err[i];
		}
		var err_y = Sqrt(sum_err);
		for(int i=0;i<n;i++)
		{
			sum_yh += ya[i]*ya[i];
		}			
		var norm_y = Sqrt(sum_yh);	
		var tol = (norm_y*eps*acc)*Sqrt(h/(b-a));
		if(err_y<tol)
		{
			k++;
			xlist.Add(x+h);
			ylist.Add(ya);
		}
		if(err_y>0)	
		{
			h *=Pow(tol/err_y,0.25)*0.95;
		}
		else
		{
			h*=2;	
		}
	}
	var res = new Result(xlist,ylist,ya);
	return res;
}

}
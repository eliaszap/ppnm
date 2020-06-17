using System;
using static System.Math;
using static System.Console;
public class main
{
    public static double errorfunction(double x)
	{
		if(x<0)
		{
			return -errorfunction(-x);
		}
        double p = 0.3275911;
        double[] a = {0.254829592, -0.284496736, 1.421413741, -1.453152027,  1.061405429};
        double t = 1/(1+p*x);
        double erf = 1 - Exp(-x*x)*(a[0]*t+a[1]*t*t+a[2]*t*t*t+a[3]*t*t*t*t+a[4]*t*t*t*t*t);
        return erf;
	}
    public static int Main()
    {
        
        int N = 15;
        Func<double,double> activate_func = (f) =>
        {
            // return Cos(f);
            // return Sin(f);
            return Exp(-f*f);

            // return Cos(5*f)*Exp(-f*f);
        };

        Func<double,double> fit_func = (f) =>
        {
            // return Cos(5*f)*Exp(-f*f);
            // return Exp(-f*f);
            return f*Exp(-f*f);

        };
        Func<double, double> derive_func = (f) =>
        {
            // return -2*f*Exp(-f*f);
            // return -Exp(-f*f)*(5*Sin(5*f)+2*f*Cos(5*f));
            return Exp(-f*f)-2*f*f*Exp(-f*f);
        };
        Func<double, double> int_func = (f) =>
        {
            // return Sqrt(PI)/2*errorfunction(f);
            // return (Sqrt(2)/2)*(2*errorfunction(f))/(Exp(24/4));
            return - 1.0/2*Exp(-f*f);

        };
        nn NN = new nn(N/3,fit_func,derive_func,int_func);

        double a = -3/2;
        double b = 3/2;
        vector x = new vector(N);
        vector y = new vector(N);
        vector dy = new vector(N);
        vector Y = new vector(N);

        System.IO.StreamWriter data = new System.IO.StreamWriter("xydata.txt");
        for(int i = 0; i<N; i++)
        {
            x[i] = a + (b-a)*i/(N-1);
            y[i] = fit_func(x[i]);
            dy[i] = derive_func(x[i]);
            Y[i] = int_func(x[i]);
            data.WriteLine("{0} {1} {2} {3}", x[i],y[i],dy[i],Y[i]);
        }
        data.Close();

        for(int i=0;i<NN.n;i++)
        {
            NN.parameters[3*i+0]=a+(b-a)*i/(NN.n-1);
            NN.parameters[3*i+1]=1;
            NN.parameters[3*i+2]=1;
	    }
        
        NN.train(x,y);
        
        vector fit_x = new vector(vector.linspace(a,b,100));
        WriteLine("fit data:");
        System.IO.StreamWriter fit = new System.IO.StreamWriter("fitdata.txt");
        for(int i = 0; i<fit_x.size; i++)
        {
            double feeded = NN.feedforwad(fit_x[i]);
            double derived = NN.ff_derivative(fit_x[i]);
            double integrated = NN.ff_integrate(fit_x[i]);
            // fit.WriteLine($"{feeded}");
            fit.WriteLine("{0} {1} {2} {3}",fit_x[i],feeded,derived,0.28+integrated);
        }
        fit.Close();

        return 0;
    }
}

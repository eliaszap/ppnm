using System;
using static System.Math;
using static System.Console;
public class main
{
    public static int Main()
    {   
        int N = 15;
        Func<double,double> fit_func = (f) =>
        {
            // return Cos(5*f)*Exp(-f*f);
            return f*Exp(-f*f);
            // return Exp(-f*f);
        };
        Func<double,double> activate_func = (f) =>
        {
            // return Cos(f);
            return Cos(5*f)*Exp(-f*f);
        };

        nn NN = new nn(N/3,activate_func);

        double a = -3/2;
        double b = 3/2;
        vector x = new vector(N);
        vector y = new vector(N);
        System.IO.StreamWriter data = new System.IO.StreamWriter("xydata.txt");
        for(int i = 0; i<N; i++)
        {
            x[i] = a + (b-a)*i/(N-1);
            y[i] = fit_func(x[i]);
            data.WriteLine("{0} {1}", x[i],y[i]);
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
            // fit.WriteLine($"{feeded}");
            fit.WriteLine("{0} {1}",fit_x[i],feeded);
        }
        fit.Close();
        return 0;
    }
}
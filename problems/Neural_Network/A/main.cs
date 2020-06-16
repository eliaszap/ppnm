using System;
using static System.Math;
using static System.Console;
public class main
{
    public static int Main()
    {   
    
        int N = 15;
        Func<double,double> wavelet = (f) =>
        {
            return Exp(-f*f);
            // return Exp(Cos(5*f)-(f*f));
        };
        Func<double,double> train_func = (f) =>
        {
            return Sin(f);
        };

        nn NN = new nn(N,wavelet);

        double a = -3*PI;
        double b = 3*PI;
        vector x = new vector(vector.linspace(a, b,N));
        vector y = new vector(N);
        System.IO.StreamWriter data = new System.IO.StreamWriter("xydata.txt");
        for(int i = 0; i<N; i++)
        {
            y[i] = train_func(x[i]);
            data.WriteLine("{0} {1}", x[i],y[i]);
        }
        data.Close();
        x.print();
        double mean_x = vector.sum(x)/N;
        double xx = x.dot(x)/N;
        double std = Sqrt(xx-mean_x*mean_x);
        vector x_norm = (x-mean_x)/std;
        // WriteLine($"{mean_x} {xx} {std}");

        // The networks trains on the activation function
        NN.train(x_norm,y);
        var p = NN.getParams();
        p.print(" ");   

        vector fit_x = new vector(vector.linspace(a,b,100));
        WriteLine("fit data:");
        System.IO.StreamWriter fit = new System.IO.StreamWriter("fitdata.txt");
        for(int i = 0; i<fit_x.size; i++)
        {
            double feeded = NN.feedforwad((fit_x[i]-mean_x)/std);
            // fit.WriteLine($"{feeded}");
            fit.WriteLine("{0} {1}",fit_x[i],feeded);
        }
        fit.Close();
        return 0;
    }
}
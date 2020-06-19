using System;
using static System.Console;
using static System.Math;
public class main
{
    public static int Main()
    {
        Func<vector,double> f= (x) =>
        {
            return 1.0/2.0*(x[0]*x[0] + x[1]*x[1]);
        };
        var accurate = 1.0/3;

        for(int N =(int) 2e3; N<(int) 1e6; N = (int) (1.2*N))
        {
            var a = new vector(new double[]{0,0});
            var b = new vector(new double[]{1,1});
            var integration = montecarlo.mc_plain(f,a,b,N);
            var mean = integration.mean;
            var sigma = integration.sigma;
            var acc_error = mean - accurate;
            WriteLine($"{N} {4.15*sigma} {1/Sqrt(N)}");
        }
      

        return 0;
    }
}
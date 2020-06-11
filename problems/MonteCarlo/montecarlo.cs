using System;
using static System.Math;
public static class montecarlo
{
    public class Result
    {
		public double mean; public double sigma;
		public Result(double x, double y)
			{
				mean = x;  sigma = y;
			}
	}

    private static vector randomx(vector a, vector b)
    {
        var rand = new Random();
        var x = new vector(a.size);
        for(int i = 0; i<a.size;i++)
        {
            x[i] = rand.NextDouble()*(b[i]-a[i])+a[i];
        }
        return x;
    }

    public static Result mc_plain(Func<vector, double> func, vector a, vector b, int N)
    {
        
        double volume = 1;
        for(int i = 0; i <a.size;i++)
        {
            volume *= b[i]-a[i];
        }
        double sum = 0;
        double sum2 = 0;
        for(int i = 0; i<N ; i++)
        {
            var fx = func(randomx(a,b));
            sum += fx;
            sum2 += fx*fx;  
        }
        double mean = sum/N;
        double sigma = Sqrt(sum2/N - mean*mean);
        double res_sigma = sigma/Sqrt(N);
        var res = new Result(mean*volume, res_sigma*volume);
        return res;  
    }
}
using System;
using static System.Math;
using System.Collections.Generic;
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
    private static vector randomx(vector a, vector b, Random rand)
    {
        var x = new vector(a.size);
        for(int i = 0; i<a.size;i++)
        {
            x[i] = rand.NextDouble()*(b[i]-a[i])+a[i];
        }
        return x;
    }

    private static vector statistics(vector xs)
    {
        double mean = 0;
        double variance = 0;
        for(int i = 0; i<xs.size;i++)
        {
            variance += Pow(xs[i]-mean,2);
            mean += xs[i];
        }
        mean /= xs.size;
        variance /= xs.size;
        return new vector(new double[]{mean,variance,xs.size});
    }

    private static vector statistics(List<double> xs)
    {
        double mean = 0;
        double variance = 0;
        for(int i = 0; i<xs.Count;i++)
        {
            variance += Pow(xs[i]-mean,2);
            mean += xs[i];
        }
        mean /= xs.Count;
        variance /= xs.Count;
        return new vector(new double[]{mean,variance,xs.Count});
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

    public static vector stratified_sampling(Func<vector,double> f, vector a, vector b, double acc, double eps, vector reuse, Random rnd = null)
    {   
        if(rnd == null)
        {
            rnd = new Random();
        }
        int dim = a.size;
        int n = 16*dim;
        double V =1;
        for(int i = 0; i<dim;i++)
        {
            V *=(b[i]-a[i]);
        }
        matrix xs = new matrix(dim,n);
        for(int i = 0; i<n;i++)
        {
            xs[i] = randomx(a,b,rnd);
        }
        vector ys = new vector(n);
        for(int i = 0; i<n;i++)
        {
            ys[i] = f(xs[i]);
        }
        var stats = statistics(ys);
        var mean = stats[0];
        var variance = stats[1];
        var old_mean = reuse[0];
        var old_var = reuse[1];
        var old_n = reuse[2];
        double integ = V*(mean*n+old_mean*old_n)/(n+old_n);
        double error = V*Sqrt((variance*n+old_var*old_n))/(old_n+n)/Sqrt(n+old_n);
        double vmax= -1;
        int kmax = 0;
        vector reuse_right = new vector(new double[]{0,0,0});
        vector reuse_left = new vector(new double[]{0,0,0});
        if(error<acc+eps*Abs(integ))
        {
            vector res = new vector(new double[]{integ,error});
            return res;
        }
        else
        {
            for(int k = 0; k<dim;k++)
            {
                for(int i = 0; i<n;i++)
                {
                    List<double> left = new List<double>();
                    List<double> right = new List<double>();

                    if(xs[k,i]<(a[k]+b[k])/2)
                    {
                        left.Add(ys[i]);
                    }

                    if(xs[k,i]>=(a[k]+b[k])/2)
                    {
                        right.Add(ys[i]);
                    }
                    vector left_stat = statistics(left);
                    vector right_stat = statistics(right);
                    double v = Abs(left_stat[0]-left_stat[0]);
                    if(v>vmax)
                    {
                        vmax = v;
                        kmax = k;
                        reuse_right = right_stat.copy();
                        reuse_left =left_stat.copy();
                    }
                }
            }   
        }
        vector a2 = a.copy();
        vector b2 = b.copy();
        a2[kmax] = (a[kmax]+b[kmax])/2;
        b2[kmax] = (a[kmax]+b[kmax])/2;
        vector res_left = stratified_sampling(f, a, b2, acc/1.414, eps, reuse_left, rnd);
        double i1 = res_left[0];
        double e1 = res_left[1];
        vector res_right = stratified_sampling(f, a2, b, acc/1.414, eps, reuse_right, rnd);
        double i2 = res_right[0];
        double e2 = res_right[1];
        vector res_vec = new vector(new double[]{i1+i2,Sqrt(e1*e1+e2*e2)});
        return res_vec;
    }

}
using System;
using static System.Math;
public static class lanczos
{
    public class Result
    {
		public matrix T; public matrix V;
		public Result(matrix x, matrix y)
			{
				T = x; V = y;
			}
	}

    public static Result lanczos_al(matrix A)
    {
        int n = A.size1;
        int m = A.size1;
        vector v0 = new vector(n);
        // vector v0 = new vector(n);
        for(int i = 0; i<n;i++)
        {
            v0[i]=1.0/Sqrt(n);
            // v0[i]=0;
        }
        matrix V = new matrix(n,n);
        matrix T = new matrix(n,n);
        
        var w0 = A*v0;
        var a0 = w0.dot(v0);
        w0 = w0 - a0*v0;
        var B = Sqrt(w0.dot(w0));   
        T[0,0] = a0;
        T[1,0] = B;
        T[0,1] = B;
        V[0] = v0;
        
        for(int j = 1; j<m-1;j++)
        {
            
            var v = w0/B;
            var w = A*v;
            var a = w.dot(v);
            w = w -a*v - B*v0;
            w0 = w;
            v0 = v;
            B = Sqrt(w.dot(w));
            // v.print($"v_{j}= ");
            T[j,j] = a;
            T[j+1,j] = B;
            T[j,j+1] = B;
            V[j] =v; 
        }
        var vn = w0/B;
        var wn = A*vn;
        var an = wn.dot(vn);
        wn = wn- an*vn - B*v0;
        T[m-1,m-1] = an;
        V[m-1] = vn;
        var results = new Result(T,V);
        return results;
    }

}
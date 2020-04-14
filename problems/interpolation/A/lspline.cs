using System;
using static System.Math;
public class lspline{

    public static double linterp(double[] x, double[] y, double z){
        int i = 0, j = x.Length - 1;   
        while(j-i > 1){
            int m = (i+j)/2;
            if (z>x[m]){ i = m;}
            else {j=m;}
        }
        return y[i] + ((y[i+1]- y[i])/(x[i+1]-x[i]))*(z-x[i]);
    }

    public static double linterpInteg(double[] x, double[] y, double z){
        if (z < x[0] || z > x[x.Length - 1]) {
			throw new System.ArgumentException ($"z = {z} is out of range x form {x[0]} to {x[x.Length - 1]}", "z");
		}
            double integral = 0;
            int i = 0;
            while(z>x[i+1]){
                double sum = y[i]*(x[i+1]-x[i])+1/2*(y[i+1]- y[i])*(x[i+1]-x[i]); 
                integral += sum;
                i++;
            }
            integral += y[i]*(z-x[i])+1/2*((y[i+1]- y[i])/(x[i+1]-x[i]))*(z-x[i])*(z-x[i]);
            return integral;
    }
}
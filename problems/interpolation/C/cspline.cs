using System;
using static System.Math;
using static System.Console;
public class cspline 
{
	public vector x,y,b,c,d;

    public cspline(vector xs, vector ys)
    {
        int n = xs.size;
        x = xs;
        y = ys;
        b = new vector(n);
        c = new vector(n-1);    
        d = new vector(n-1);
        var p = new vector(n-1);
        var h = new vector(n-1);

         // calculate p_i
        for(int i = 0; i < n-1 ; i++){
            h[i] = (x[i+1]-x[i]);
            if(h[i]>0)
            {
                p[i] =(y[i+1]-y[i])/h[i];
            }
        }

        vector D = new vector(n);
        vector B = new vector(n);
        vector Q = new vector(n-1);
        D[0] = 2;
        Q[0] = 1;
        B[0] = 3*p[0];
        for(int i = 0; i<n-2;i++)
        {
            D[i+1] = 2*h[i]/h[i+1]+2;
            Q[i+1] = h[i]/h[i+1];
            B[i+1] = 3*(p[i]+p[i+1]*h[i]/h[i+1]);
        }
        D[n-1] = 2;
        B[n-1] = 3*p[n-2];
        for(int i = 1; i<n; i++)
        {
            D[i] -= Q[i-1]/D[i-1];
            B[i] -= B[i-1]/D[i-1];
        }

        b[n-1] =B[n-1]/D[n-1];

        for(int i = n-2; i>=0;i--)
        {
            b[i] = (B[i]-Q[i]*b[i+1])/D[i];
        }

        for(int i = 0; i<n-1; i++)
        {
            c[i] = (-2*b[i]-b[i+1]+3*p[i])/h[i];
            d[i] =(b[i]+b[i+1]-2*p[i])/(h[i]*h[i]);
        }
    }  

     /* evaluate the spline */
	public double spline(double z)
    {
        if (z < x[0] || z > x[x.size - 1]) 
        {
			throw new System.ArgumentException ($"z = {z} is out of range x form {x[0]} to {x[x.size - 1]}", "z");
		}
        int i = 0; 
        int j = x.size;
        while(j-i > 1){
            int m = (i+j)/2;
            if (z>x[m]){ i = m;}
            else {j=m;}
        }
        return y[i] + b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2)+d[i]*Pow((z-x[i]),3);
    }

    /* evaluate the derivative */
	public double derivative(double z)
    {
        
        if (z < x[0] || z > x[x.size - 1]) 
        {
			throw new System.ArgumentException ($"z = {z} is out of range x form {x[0]} to {x[x.size - 1]}", "z");
		}	
        int i = 0; 
        int j = x.size;
        while(j-i > 1){
            int m = (i+j)/2;
            if (z>x[m]){ i = m;}
            else {j=m;}
        }
        return b[i] + 2*c[i]*(z-x[i]) + 3*d[i]*Pow((z-x[i]),2);
    }

    /* evaluate the integral */
	public double integral(double z)
    {
        if (z < x[0] || z > x[x.size - 1]) 
        {
			throw new System.ArgumentException ($"z = {z} is out of range x form {x[0]} to {x[x.size - 1]}", "z");
		}
        double integral = 0;
         int i = 0;
        while(z>x[i+1]){
            double sum = y[i]*(x[i+1]-x[i])+1.0/2*b[i]*Pow((x[i+1]-x[i]),2)+1.0/3*c[i]*Pow((x[i+1]-x[i]),3)+1.0/4*d[i]*Pow((x[i+1]-x[i]),4); 
            integral += sum;
            i++;
        }
        integral += y[i]*(z-x[i])+1.0/2*b[i]*Pow((z-x[i]),2)+1.0/3*c[i]*Pow((z-x[i]),3)+1.0/4*d[i]*Pow((z-x[i]),4);
        
        return integral;
	}

}
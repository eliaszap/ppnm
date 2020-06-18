using System;
using static System.Math;
using static System.Console;
public class qspline 
{
	public vector x,y,b,c;

    /* calculate b and c */
    public qspline(vector xs,vector ys) 
    {    
        
        int n = xs.size;
        x = xs;
        y = ys;
        var c_f = new vector(n-1);
        c_f[0] = 0;
        var c_b = new vector(n-1);
        c_b[n-2] = 0;
        c = new vector(n-1);
        b = new vector(n-1);
        var p = new vector(n-1);
        
        // calculate p_i
        for(int i = 0; i < n-1 ; i++){
            p[i] =(ys[i+1]-ys[i])/(xs[i+1]-xs[i]);
        }
        
        //Backward recursion
        for(int i = n-3; i>0;i--)
        {
         c_b[i] = 1.0/(x[i+1]-x[i])*(p[i+1]-p[i]-c_b[i+1]*(x[i+2]-x[i+1]));   
        }
        //Forward recursiom
        for(int i = 0; i<n-2;i++)
        {
            c_f[i+1] =  1.0/(x[i+2]-x[i+1])*(p[i+1]-p[i]-c[i]*(x[i+1]-x[i]));
        }
 
        //Averaging to get c
        for(int i = 0; i < n-1;i++ )
        {
            c[i] = (c_b[i]+c_f[i])/2;
        }

        //Calculate B
        for(int i =0; i<n-1;i++)
        {
            
            b[i] =p[i]-c[i]*(xs[i+1]-xs[i]);
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
        return y[i] + b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2);
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
        
        return b[i] + 2*c[i]*(z-x[i]);
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
            double sum = y[i]*(x[i+1]-x[i])+1.0/2*b[i]*Pow((x[i+1]-x[i]),2)+1.0/3*c[i]*Pow((x[i+1]-x[i]),3); 
            integral += sum;
            i++;
        }
        integral += y[i]*(z-x[i])+1.0/2*b[i]*Pow((z-x[i]),2)+1.0/3*c[i]*Pow((z-x[i]),3);
        
        return integral;
	}

}
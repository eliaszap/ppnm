using System;
using static System.Console;
public static class root{

    public static vector newton
    (
        Func<vector,vector> f, //takes the input vector x and retrun f(x)
	                    vector xstart, //Starting point
	                    double eps=1e-3, //The accuracy goal, ||f(x)||< epsilon
	                    double dx=1e-6 //finite difference
    ) 
    {
        vector x = xstart.copy();
        int n = xstart.size;
        vector fx = f(x);
        vector y;
        vector fy;
        do
        {
            matrix J = new matrix(n,n);
            for(int j = 0; j<n;j++)
            {
                x[j]+=dx;
                vector df = f(x)-fx;
                for(int i = 0; i<n;i++)
                {
                    J[i,j] = df[i]/dx;
                }
                x[j] -= dx;
            }
            var JQR = new qrdecompositionGS(J);
            matrix B = JQR.inverse();
            vector Dx = -B*fx;
            double s=1;
            do
            {
                y = x+Dx*s;
                fy = f(y);
                if(fy.norm()<(1-s/2)*fx.norm())
                {
                    break;
                }
                if(s<1.0/32)
                {
                    break;
                }
                s /= 2;
            } while (true);
            x = y;
            fx = fy;
            if(fx.norm()<eps)
            {
                break;
            }
        } while (true);
        return x;
    }

    public static double hydrogen_schrodinger(double e, double r)
    {
        double r_min = 1e-3;
        Func<double,vector,vector> F_epsilon = (x,y) =>
        {
            /* Solution to the schrodinger equation: -(1/2)f'' -(1/r)f = εf */
            double f_primeprime = 2*y[0]*(-1/x - e);
            return new vector(y[1], f_primeprime);
        };
        double eps = 1e-3;
        double acc = 1e-3;
        double h = 1e-3;
        int maxsteps = 1000;
        vector y_rmin = new vector(r_min-r_min*r_min, 1-2*r_min);

        var result = Ode.driver(F_epsilon,r_min,y_rmin,r,h,acc,eps,maxsteps);

        var y_result= result.ya[0];

        return y_result;
    }
}
using System;
using static System.Math;

public static class minimization
{
    public static readonly double EPS=1.0/4194304;

    public static vector gradient
    (
        Func<vector,double> f,
        vector x
    )
    {
        vector grad_f = new vector(x.size);
        double fx = f(x);

        for(int i = 0; i<x.size;i++)
        {
            double dx = Abs(x[i])*EPS;
            if(Abs(x[i])<Sqrt(EPS))
            {
                dx = EPS;
            }
            x[i] += dx;
            grad_f[i] = (f(x)-fx)/dx;
            x[i] -= dx;
        }
        return grad_f;
    }
    public static int qnewton
    (
        Func<vector,double> f, /* objective function */
        ref vector xstart, /* starting point */
        double eps /* accuracy goal, on exit |gradient| should be <eps */
    )
    {
        double fx = f(xstart);
        vector grad_fx = gradient(f,xstart);
        matrix A = matrix.id(xstart.size);
        int n_steps = 0;
        while(n_steps<999)
        {
            n_steps++;
            var Dx = -A*grad_fx;
            if(Dx.norm()<EPS*xstart.norm())
            {
                break;
            }
            if(grad_fx.norm()<eps)
            {
                break;  
            }
            double lam = 1.0;
            vector y;
            double fy;
            while(true)
            {
                y = xstart+Dx*lam;
                fy = f(y);
                if(fy<fx)
                {
                    break;
                }
                if(lam<EPS)
                {
                    A.setid();
                    break;
                }
                lam /= 2;
            }
            vector  s = y-xstart;
            vector grad_fy = gradient(f,y);
            vector z = grad_fy-grad_fx;
            vector u = s-A*z;
            double uTz = u.dot(z);
            if(Abs(uTz)>1e-6)
            {
                A.update(u,u,1.0/uTz);
            }
            xstart = y;
            grad_fx = grad_fy;
            fx = fy;
        }
        return n_steps;
    }
}
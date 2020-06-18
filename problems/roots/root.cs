using System;
using static System.Console;
public static class root{

    public static vector newton(
	                    Func<vector,vector> f, //takes the input vector x and retrun f(x)
	                    vector xstart, //Starting point
	                    double eps=1e-3, //The accuracy goal, ||f(x)||< epsilon
	                    double dx=1e-6 //finite difference
                        ) 
    {    
	vector x = xstart.copy();
    int n = x.size;
    matrix J = new matrix(n,n);
	do
    {
        var fx = f(x);
        for(int j = 0; j<n;j++)
        {
            x[j] += dx;
            var df = f(x)-fx;
            for(int i = 0; i<n;i++)
            {
                J[i,j] = df[i]/dx;
                
            }
            x[j] -= dx;
        }  
        var QR = new qrdecompositionGS(J);
        var J_QR = QR.Q*QR.R;
        var Dx = QR.solve(J_QR,-1.0*fx); 
        double s = 2.0;
        vector y = new vector(n);
        vector fy = new vector(n); 
        do
        {
            s/=2;
            y = x + Dx*s;
            fy = f(y);
            if(fy.norm()<(1-s/2)*fx.norm() || s < 0.02)
            {
                break;
            }
        }
        while(true);
        x = y;
        fy = f(y);
        if(Dx.norm()<dx || fx.norm()<eps)
        {
            break;
        }
    }
    while(true);
	return x;
    }
}
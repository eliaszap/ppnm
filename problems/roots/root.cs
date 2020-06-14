using System;
using static System.Console;
public static class root{

    public static vector newton(
	                    Func<vector,vector> f, //takes the input vector x and retrun f(x)
	                    vector x, //Starting point
	                    double eps, //The accuracy goal, ||f(x)||< epsilon
	                    double dx=1e-7 //finite difference
                        ) 
    {   
	vector root = x.copy();
    int n = root.size;
    matrix J = new matrix(n,n);
    
	do
    {
        var fx = f(root);
        for(int j = 0; j<n;j++)
        {
            root[j] += dx;
            var df = f(root)-fx;
            for(int i = 0; i<n;i++)
            {
                J[i,j] = df[i]/dx;
                
            }
            root[j] -= dx;
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
            y = root + Dx*s;
            fy = f(y);
            if(fy.norm()<(1-s/2)*fx.norm() || s < 1.0/32)
            {
                break;
            }
        }
        while(true);
        root = x+s*Dx;
        fx = f(root);
        if(fx.norm()<eps)
        {
            break;
        }
    }
    while(true);
	return root;
    }
}
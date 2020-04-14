using System;
using static System.Console;
using static System.Math;
class main
{

    static int Main()
    {
        int N = 2000, n = 20;
        double z = 0;
        double integration = 0;
        double[] xs = new double[N];
        double[] ys = new double[N];
        System.IO.StreamWriter  xyfile = new System.IO.StreamWriter("out-xy.txt",append:false);
        for(int i=0;i<=N-1;i++){
            xs[i] = 2.5*PI*i/(N-1);
            ys[i] = Sin(xs[i]);
            
            if(i == 0)
            {
                integration= 0;
            }
            else
            {
                integration += -Cos(xs[i])+Cos(xs[i-1]);
            }
            xyfile.WriteLine("{0} {1} {2} {3}",xs[i],ys[i],integration,Cos(xs[i]));
        }
            xyfile.Close();
        var Q = new qspline(new vector(xs),new vector(ys));
       
        System.IO.StreamWriter  qinterpfile = new System.IO.StreamWriter("out-qinterp.txt",append:false);
        for(int i = 0; i<=n;i++){
            z = 2*PI*i/(n-1);
            qinterpfile.WriteLine("{0} {1} ",z,Q.spline(z));
        }
            qinterpfile.Close();
        
        System.IO.StreamWriter  qintegratefile = new System.IO.StreamWriter("out-qintegrate.txt",append:false);
        for(int i = 0; i<=n;i++){
            z = 2*PI*i/(n-1);
             qintegratefile.WriteLine("{0} {1} ",z,Q.integral(z));
        }
             qintegratefile.Close();

        System.IO.StreamWriter  qderivative = new System.IO.StreamWriter("out-qderivative.txt",append:false);
        for(int i = 0; i<=n;i++){
            z = 2*PI*i/(n-1);
             qderivative.WriteLine("{0} {1} ",z,Q.derivative(z));
        }
            qderivative.Close();

        
        return 0;
        
    }
}
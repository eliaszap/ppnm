using System;
using static System.Console;
using static System.Math;
class main{
    static int Main(){
        int n = 16, N = 20; int i=0;

        double[] xs = new double[N];
        
        double[] ys = new double[N];

        System.IO.StreamWriter  xyfile = new System.IO.StreamWriter("out-xy.txt",append:false);
        for(i=0;i<=N-1;i++){
            xs[i] = 4*PI*i/(N-1);
            ys[i] = Cos(xs[i]);
            xyfile.WriteLine("{0} {1}",xs[i],ys[i]);
        }
            xyfile.Close();

        
        System.IO.StreamWriter  linterpfile = new System.IO.StreamWriter("out-linterp.txt",append:false);

        i = 0;
        double z = 0;
        for(i = 0; i<=n;i++){
            z = 4*PI*i/(n-1);
            linterpfile.WriteLine("{0} {1} ",z,lspline.linterp(xs,ys,z));
        }
            linterpfile.Close();

        System.IO.StreamWriter  lintegralfile = new System.IO.StreamWriter("out-lintegral.txt",append:false);

         for(i = 0; i<=n;i++){
            z = 2*PI*i/(n-1);
            // lintegralfile.WriteLine("{0} {1} {2}",z,Cos(z),Sin(z));
            lintegralfile.WriteLine("{0} {1} {2}",z,lspline.linterpInteg(xs,ys,z),Sin(z));
        }
        lintegralfile.Close();

        
        return 0;
    }
}
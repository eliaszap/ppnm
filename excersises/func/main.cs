using System;
using static System.Console;
using static System.Math;
class main{

    static double gamma(double z){
        const double inf=System.Double.PositiveInfinity;
        if(z<0) return -PI/Sin(PI*z)/gamma(1-z);
        if(z<1) return gamma(z+1)/z;
        if(z>3) return gamma(z-1)*(z-1);
        Func<double,double> f= delegate(double x){
            return Pow(x,z-1)*Exp(-x);
            };
        return quad.o8av(f,0,inf,acc:1e-3,eps:0);
    }

    static int Main(){
        const double inf=System.Double.PositiveInfinity;

        Func<double,double> f = (x) => Log(x)/Sqrt(x);
        double a=0,b=1,res1;
        res1=quad.o8av(f,a,b,acc:1e-6,eps:1e-6);
        Write($"int_0 int_1 dx Log(x)/sqrt(x)={res1}\n");

        Func<double,double> g = (x) => Exp(-Pow(x,2));
        double minf = -inf, pinf = inf, res2;
        res2 = quad.o8av(g,minf,pinf,acc:1e-6,eps:1e-6);
        Write($"int_-inf int_+inf dx e(-x^2)={res2} sqrt(pi)={Sqrt(PI)}\n");

        for(double p=0.5;p<10;p+=0.5){
            Func<double,double> h = (x) => Pow(Log(1/x),p);
            double c=0,d=1,res3;
            res3 = quad.o8av(h,c,d,acc:1e-6,eps:1e-6);
            Write($"for p={p} the integral int_0 int_1 dx Log(1/x)^p={res3} and for gamma(p+1)={gamma(p+1)}\n");
        }


        return 0;

    }

}
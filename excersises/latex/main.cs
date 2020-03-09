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
    for(double x= -4.0+1.0/32;x<=6;x+=1.0/16){
        Write($"{x:f5} {gamma(x):f15}\n");
        }
    
    return 0;
    }

}
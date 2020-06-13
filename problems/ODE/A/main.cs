using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;
using System.Linq;
using System.IO;
class main{
    
    static Func<double,vector,vector> F=delegate(double x, vector y)
    {
        return new vector(y[1],-y[0]);
    };

    static int Main(){
        double a=0;
        vector ya=new vector(0,1);
        double b=2.25*PI;
        double h=0.1,acc=1e-3,eps=1e-3;
        int max = 999;
        var result = Ode.driver(F,a,ya,b,h,acc:acc,eps:eps,maxsteps:max);

        File.WriteAllLines("plotA.txt", result.xs
        .Select((x, i) => $"{x} {result.ys[i][0]} {result.ys[i][1]}"));
    
        return 0;
    }
}
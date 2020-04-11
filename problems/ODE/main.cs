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
    static Func<double,vector,vector> SIR_F(double N, double Tr, double Tc)
    {
        return (x,y) =>
        {
            vector result = new vector(3);
                var S = y[0]; 
                var I = y[1];
                result[0] = - I*S/(N*Tc);
                result[1] = I*S/(N*Tc) - I/Tr;
                result[3] = I/Tr;
                return result;
        };
    }

    static int Main(){
        double a=0;
        vector ya=new vector(0,1);
        double b=2.25*PI;
        double h=0.1,acc=1e-3,eps=1e-3;
        int max = 999;
        // var result = Ode.driver(F,a,ya,b,h,acc:acc,eps:eps,maxsteps:max);

        // File.WriteAllLines("plot.txt", result.xs
        // .Select((x, i) => $"{x} {result.ys[i][0]} {result.ys[i][1]}"));
    

        Write("Assignment B, Development of Covid-19 epidemic\n");
        double N = 5.8e+6; //population of dk
        double T_r = 0.5; //half day
        double T_c = 21; //recovery time for mild cases 2 weeks, severe is 3-6 weeks.
        double I_start = 100; // start with a 100 sick
        vector y_start = new vector(new double[] {N-I_start,I_start,0}); 
        double days = 30; //prediction a month ahead
        double hstep = 0.01;
        var SIR = Ode.driver(SIR_F(N,T_r,T_c),a,y_start,days,hstep,acc:acc,eps:eps,maxsteps:10000);
        return 0;
    }
}
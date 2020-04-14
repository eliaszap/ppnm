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
                result[0] = -Tc*I*S/(N);
                result[1] = Tc*I*S/(N) - I*Tr;
                result[2] = I*Tr;
                return result;
        };
    }
    

    static int Main(){
        double a=0;
        vector ya=new vector(0,1);
        double b=2.25*PI;
        double h=0.1,acc=1e-3,eps=1e-3;
        int max = 999;
        var result = Ode.driver(F,a,ya,b,h,acc:acc,eps:eps,maxsteps:max);

        File.WriteAllLines("plotA.txt", result.xs
        .Select((x, i) => $"{x} {result.ys[i][0]} {result.ys[i][1]}"));
    

        Write("Assignment B, Development of Covid-19 epidemic\n");
        double N = 500; //population of DK = S(0) 
        double T_c = 0.001; //time between contacts
        double T_r = 0.1; //recovery time for mild cases 2 weeks, severe is 3-6 weeks.
        double I0= 1; // I(0) = 100
        double R0 = 0; // R(0) = 0
        vector y_start = new vector(new double[] {N,I0,R0}); 
        double days = 60; //prediction a month ahead
        double hstep = 0.5;
        double accs=1e-4;
        double epss=1e-4;
        var SIR = Ode.driver(SIR_F(N,T_r,T_c),a,y_start,days,hstep,acc:accs,eps:epss,maxsteps:10000);
      

        File.WriteAllLines("plotB.txt", SIR.xs
        .Select((x, i) => $"{x} {SIR.ys[i][0]} {SIR.ys[i][1]} {SIR.ys[i][2]}"));

          return 0;
    }
}
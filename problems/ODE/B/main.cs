using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;
using System.Linq;
using System.IO;
class main{

    static Func<double,vector,vector> SIR_F(double N, double Tr, double Tc)
    {
        return (x,y) =>
        {
            vector result = new vector(3);
                var S = y[0]; 
                var I = y[1];
                result[0] = -I*S/(N*Tc);
                result[1] = I*S/(N*Tc) - I/Tr;
                result[2] = I/Tr;
                return result;
        };
    }
    

    static int Main(){
        Write("Assignment B, Development of Covid-19 epidemic\n");
         double a=0;
        double N = 6e6; //population of DK
        double T_c = 3.0; //time between contacts
        double T_r = 8; // Recovery time
        double R0 = 700; // R(0) = 700 
        double I0= 4000 - R0; // I(0) = 4000 people who brought the virus to DK
        double S0 = N - I0 - R0; // S(0), Whole population susceptible, except removed or infectious.
        vector y_start = new vector(new double[] {S0,I0,R0}); 
        double days = 120; //prediction for four months.
        double hstep = 0.2;
        double accs=1e-3;
        double epss=1e-3;
        var SIR = Ode.driver(SIR_F(N,T_r,T_c),a,y_start,days,hstep,acc:accs,eps:epss,maxsteps:1000);
      

        File.WriteAllLines("plotB.txt", SIR.xs
        .Select((x, i) => $"{x} {SIR.ys[i][0]} {SIR.ys[i][1]} {SIR.ys[i][2]}"));

        return 0;
    }
}
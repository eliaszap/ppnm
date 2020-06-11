using System;
using static System.Console;
using static System.Math;
public class main
{
    public static int Main()
    {
        int N = (int) 1e6;
        Func<vector,double> f1 = (x) =>
        {
            return Cos(x[0])*Cos(x[1]);
        };    
        var start = new vector(new double[]{0,0});
        var end = new vector(new double[]{PI/2,PI/2});
        var integration1 = montecarlo.mc_plain(f1,start,end,N);
        var mean1 = integration1.mean;
        var sigma1 = integration1.sigma;
        var accurate_int = 1;
        WriteLine("Interesting integral nr. 1:");
        WriteLine($"Plain Monte carlo integrator: int_0^(π/2) int_0^(π/2) dxdy cos(x)*cos(y) = {mean1}");
        WriteLine($"Integration with CAS: int_0^(π/2) int_0^(π/2) dxdy cos(x)*cos(y) = {accurate_int}");
        WriteLine($"Error on plain montecarlo: {sigma1}");
        WriteLine($"Actual Error to accurate solution: {accurate_int-mean1} ");
        WriteLine(" ");

        Func<vector,double> f2 = (x) =>
        {
            return 1.0/2.0*(x[0]*x[0] + x[1]*x[1]);
        };
        var start_2 = new vector(new double[]{0,0});
        var end_2 = new vector(new double[]{1,1});
        var integration2 = montecarlo.mc_plain(f2,start_2,end_2,N);
        var mean2 = integration2.mean;
        var sigma2 = integration2.sigma;
        var accurate_int2 = 1.0/3;
        WriteLine("Interesting integral nr. 2:");
        WriteLine($"Plain Monte carlo integrator: int_0^1 int_0^1 dxdy 1/2*(x^2+y^2) = {mean2}");
        WriteLine($"Integration with CAS: int_0^(π/2) int_0^(π/2) dxdy 1/2*(x^2+y^2) = {accurate_int2}");
        WriteLine($"Error on plain montecarlo: {sigma2}");
        WriteLine($"Actual Error to accurate solution: {accurate_int2-mean2} ");
        WriteLine(" ");

        Func<vector,double> f3 = (x) =>
        {
            return Exp(x[0])*Cos(x[1]);
        };
        var start_3 = new vector(new double[]{0,0});
        var end_3 = new vector(new double[]{PI,PI/2});
        var integration3 = montecarlo.mc_plain(f3,start_3,end_3,N);
        var mean3 = integration3.mean;
        var sigma3 = integration3.sigma;
        var accurate_int3 = 22.14069;
        WriteLine("Interesting integral nr. 3:");
        WriteLine($"Plain Monte carlo integrator: int_0^(π/2) int_0^(π) dxdy e^x*cos(y) = {mean3}");
        WriteLine($"Integration with CAS:int_0^(π/2) int_0^(π) dxdy e^x*cos(y) = e^π - 1 =  {accurate_int3}");
        WriteLine($"Error on plain montecarlo: {sigma3}");
        WriteLine($"Actual Error to accurate solution: {accurate_int3-mean3} ");
        WriteLine(" ");

        Func<vector,double> f = (x) =>
        {
            return 1.0/(PI*PI*PI)*1.0/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));
        };
        var a = new vector(new double[]{0,0,0});
        var b = new vector(new double[]{PI,PI,PI});
        var integration = montecarlo.mc_plain(f,a,b,N);
        var mean = integration.mean;
        var sigma = integration.sigma;
        var acc = 1.3932039296856768591842462603255;
        WriteLine("∫0π  dx/π ∫0π  dy/π ∫0π  dz/π [1-cos(x)cos(y)cos(z)]^-1 = Γ(1/4)4/(4π3) ≈ 1.3932039296856768591842462603255");
        WriteLine($"Plain Monte carlo integrator: ∫0π  dx/π ∫0π  dy/π ∫0π  dz/π [1-cos(x)cos(y)cos(z)]-1 = Γ(1/4)4/(4π3) ≈ {mean}");
        WriteLine($"Error on plain montecarlo: {sigma}");
        WriteLine($"Actual Error to accurate solution: {acc-mean} ");
        return 0;
    }
}
using System;
using static System.Console;
using static System.Math;
public class main
{
    public static int Main()
    {
        Func<vector,double> f1 = (x) =>
        {
            return Cos(x[0])*Cos(x[1]);
        };    
        int N = (int) 1e6;
        var eps = 1e-2;
        var acc = 1e-2;
        var reuse = new vector(new double[]{0,0,0});
        WriteLine("The two first functions of 'interesting functions' from A is now integrated with stratified sampling:");
        WriteLine("eps, acc = {0} because of runtime.",eps);
        WriteLine("The third function is greentexted in main.cs, but omitted because of runtime");
        var start = new vector(new double[]{0,0});
        var end = new vector(new double[]{PI/2,PI/2});
        var integration1_plain = montecarlo.mc_plain(f1,start,end,N);
        var mean1 = integration1_plain.mean;
        var sigma1 = integration1_plain.sigma;
        var accurate_int = 1;

        var integration1_stratified = montecarlo.stratified_sampling(f1,start, end,acc,eps,reuse);
        var integ = integration1_stratified[0];
        var error = integration1_stratified[1];
        
        WriteLine("Integral of int_0^(π/2) int_0^(π/2) dxdy cos(x)*cos(y):");
        WriteLine($"Plain Monte carlo integrator                    : {mean1}");
        WriteLine($"Stratified sampling integrator                  : {integ}");
        WriteLine($"Integration with CAS                            : {accurate_int}");
        WriteLine($"Error on plain montecarlo                       : {sigma1}");
        WriteLine($"Error on stratified sampling  montecarlo        : {error}");
        WriteLine($"Actual Error of stratified sampling to accurate : {accurate_int-integ} ");
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
        var integration2_stratified = montecarlo.stratified_sampling(f2,start_2, end_2,acc,eps,reuse);
        var integ2 = integration2_stratified[0];
        var error2 = integration2_stratified[1];
        
        WriteLine("Integral int_0^1 int_0^1 dxdy 1/2*(x^2+y^2):");
        WriteLine($"Plain Monte carlo integrator                    : {mean2}");
        WriteLine($"Stratified sampling integrator                  : {integ2}");
        WriteLine($"Integration with CAS                            : {accurate_int2}");
        WriteLine($"Error on plain montecarlo                       : {sigma2}");
        WriteLine($"Error on stratified sampling  montecarlo        : {error2}");
        WriteLine($"Actual Error of stratified sampling to accurate : {accurate_int2-integ2} ");
        WriteLine(" ");


        // Func<vector,double> f3 = (x) =>
        // {
        //     return Exp(x[0])*Cos(x[1]);
        // };
        // var start_3 = new vector(new double[]{0,0});
        // var end_3 = new vector(new double[]{PI,PI/2});
        // var integration3 = montecarlo.mc_plain(f3,start_3,end_3,N);
        // var mean3 = integration3.mean;
        // var sigma3 = integration3.sigma;
        // var accurate_int3 = 22.14069;
        // var integration3_stratified = montecarlo.stratified_sampling(f3,start_3, end_3,acc,eps,reuse);
        // var integ3 = integration3_stratified[0];
        // var error3 = integration3_stratified[1];

        // WriteLine("Integral of int_0^(π/2) int_0^(π) dxdy e^x*cos(y) :");
        // WriteLine($"Plain Monte carlo integrator: {mean3}");
        // WriteLine($"Stratified sampling integrator: {integ3}");
        // WriteLine($"Integration with CAS: {accurate_int3}");
        // WriteLine($"Error on plain montecarlo: {sigma3}");
        // WriteLine($"Error on stratified sampling  montecarlo: {error3}");
        // WriteLine($"Actual Error of stratified sampling to accurate solution: {accurate_int3-integ3} ");
        // WriteLine(" ");

        return 0;
    }
}
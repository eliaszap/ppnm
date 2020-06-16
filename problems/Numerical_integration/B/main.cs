using System;
using static System.Console;
using static System.Math;
class main{
    public static int calls = 0;
    public static int Main()
    {
        // Assigment B
        double a = 0, b= 1, accs = 1e-6, epss = 1e-6, acc = 1e-3, eps = 1e-3;
        WriteLine($"Assignment B");
         Func<double,double> f2 = (x) => 
        {
            calls +=1;
            return 4*Sqrt(1-x*x);
        };
        Func<double,double> f3 = (x) =>
        {   
            calls +=1;
            return 1/Sqrt(x);
        }; 
        var sqrt_1 = calc.clenshaw_curtis(f3,0,1,acc,eps);
        WriteLine($"int_^1_0 1/Sqrt(x) dx = {sqrt_1}, in {calls} evaluations, reference = {2}.");
        calls = 0;
        
        Func<double,double> f4 = (x) => 
        {
            calls +=1;
            return Log(x)/Sqrt(x);
        };
        var logsqrt = calc.clenshaw_curtis(f4,0,1,acc,eps);
        WriteLine($"int_^1_0 ln(x)/Sqrt(x) dx = {logsqrt}, in {calls} evaluations, reference = {-4}");
        calls = 0;
        Func<double,double> f5 = (x) =>
        {
            calls += 1;
            return 4*Sqrt(1-x*x);
        };
        var f2_cc = calc.clenshaw_curtis(f5,0,1,accs,epss);
        WriteLine($"With Clenshaw-curtis: int_^1_0 4*Sqrt(1-x^2) = {f2_cc}, in {calls} evaluations, reference={PI}");
        calls = 0;
        var o8av = quad.o8av(f5,0,1,accs,epss);
        WriteLine($"With o8av: int_^1_0 4*Sqrt(1-x^2) = {o8av}, in {calls} evaluations, reference={PI}");
        calls = 0;
        var int_f2_a = calc.adapt(f2,a,b,accs,epss);
        WriteLine($"From Assignment A: int_^1_0 4*Sqrt(1-x^2) = {int_f2_a}, in {calls} evaluations, reference={PI}");
        calls = 0;
        return 0;
    }
}
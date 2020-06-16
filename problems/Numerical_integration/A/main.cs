using System;
using static System.Console;
using static System.Math;
class main{
    public static int calls = 0;
    public static int Main()
    {
        // Assigment A
        WriteLine($"Assignment A");
        // var calc = new Integration_calc();
        Func<double,double> f1 = (x) => Sqrt(x);
        double a = 0, b= 1, acc=1e-3, eps=1e-3;
        var sqrt_x = calc.adapt(f1,a,b,acc,eps);
        WriteLine($"int_^1_0 Sqrt(x) dx = {sqrt_x}, reference= {2.0/3}");

        Func<double,double> f2 = (x) => 
        {
            calls +=1;
            return 4*Sqrt(1-x*x);
        };
        double accs = 1e-6, epss = 1e-6;
        var int_f2 = calc.adapt(f2,a,b,accs,epss);
        WriteLine($"int_^1_0 4*Sqrt(1-x^2) = {int_f2}, reference={PI}");

        return 0;
    }
}
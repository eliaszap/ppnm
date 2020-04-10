using System;
using static System.Math;
public class Integration_calc{
    
    public Integration_calc(){}
    public double integrate(Func<double, double> func,
                            double a,
                            double b,
                            double f2,
                            double f3,
                            double acc,
                            double rel)
    {   double f1 = func(a+(b-a)/6);
        
        double f4 = func(a+(b-a)*5.0/6);
        double Q = (b-a)*(2*f1+f2+f3+2*f4)/6; // Q = sum(wi*f(xi))
        double q = (b-a)*(f1+f2+f3+f4); // q = sum(vi*f(xi))
        double error = Abs(Q-q);
        if(error< acc+rel*Abs(Q))
        {
            return Q;
        }
        else
        {
            return integrate(func,a,(a+b)/2,f1,f2,acc/Sqrt(2),rel) + integrate(func,(a+b)/2,b,f3,f4,acc/Sqrt(2),rel);
        }
    }
    public double adapt(Func<double,double> func,double a, double b, double acc, double rel){
        double f2 = func(a+(b-a)*2.0/6);
        double f3 = func(a+(b-a)*4.0/6);
        return integrate(func,a,b,f2,f3,acc,rel);
    }
}
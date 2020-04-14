using System;
using static System.Console;
using static System.Math;
public static class calc{
    public static double integrate(Func<double, double> func,
                            double a,
                            double b,
                            double f2,
                            double f3,
                            double acc,
                            double rel,
                            int nrec)
    {  
        double f1 = func(a+(b-a)/6);
        double f4 = func(a+(b-a)*5.0/6);
        double Q = (b-a)*(2*f1+f2+f3+2*f4)/6; 
        double q = (b-a)*(f1+f2+f3+f4)/4; 
        double error = Abs(Q-q);
        if(error< acc+rel*Abs(Q))
        {
            var r= nrec;
            return Q;
        }
        else
        {
            return integrate(func,a,(a+b)/2,f1,f2,acc/Sqrt(2),rel,nrec+1) + integrate(func,(a+b)/2,b,f3,f4,acc/Sqrt(2),rel,nrec+1);
        }
    }
    public static double adapt(Func<double,double> func,double a, double b, double acc, double rel,int nrec=0){
        double f2 = func(a+(b-a)*2.0/6);
        double f3 = func(a+(b-a)*4.0/6);
        return integrate(func,a,b,f2,f3,acc,rel,nrec);
    }

    public static double clenshaw_curtis(Func<double,double> func, double a, double b, double acc, double rel,int nrec=0)
    {
        double trans_a=Acos(a), trans_b=Acos(b);
        Func<double,double> trans_f = (x) => -func(Cos(x))*Sin(x);
        double f2 = trans_f(trans_a+(trans_b-trans_a));
        double f3 = trans_f(trans_a+(trans_b-trans_a));
        return integrate(trans_f,trans_a,trans_b,f2,f3,acc,rel,nrec);
        
    }


}
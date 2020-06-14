using System;
using static System.Console;
using static System.Math;
public class main
{
    static System.Collections.Generic.List<double> energy,sigma,error;

    public static double breitWigner(double m, double gamma, double E)
    {
        return 1.0/((E-m)*(E-m)+(gamma*gamma)/4);
    }
    public static double D(vector x)
    {
        double m = x[0];
        double gam = x[1];
        double A = x[2];
        double sum = 0;
        for(int i = 0; i<energy.Count;i++)
        {
            sum += Pow((A*breitWigner(m,gam,energy[i])-sigma[i]),2)/(error[i]*error[i]);   
        }
        return sum;
    }


    public static int Main()
    { 
        double eps = 1e-3;
        energy = new System.Collections.Generic.List<double>();
        sigma = new System.Collections.Generic.List<double>();
        error  = new System.Collections.Generic.List<double>();
        System.IO.StreamReader data = new System.IO.StreamReader("higgs_data.txt");
        do
        {
            string s = data.ReadLine();
            if(s == null)
            {
                break;
            }
            char[] sep = new char[] {' '};
            string[] splitted = s.Split(sep,StringSplitOptions.RemoveEmptyEntries);
            energy.Add(double.Parse(splitted[0]));
            sigma.Add(double.Parse(splitted[1]));
            error.Add(double.Parse(splitted[2]));
        } while (true);

        
        vector parameters = new vector(new double []{125.0,4.0,5});
        var fit = minimization.qnewton  (D,ref parameters, eps);
        WriteLine($"Parameters from fit: mass, m = {parameters[0]}, widths of resonance, gamma = {parameters[1]}, and scale factor, A = {parameters[2]}");
        WriteLine($"Computed with {fit} steps.");
        for(double e = energy[0]; e<=energy[energy.Count-1]; e += 1.0/10)
        {
            
            Error.WriteLine("{0} {1}",e,parameters[2]*breitWigner(parameters[0],parameters[1],e));
        }
            
    
        return 0;
    }    
}
using System;
using static System.Console;
using static System.Math;
public class main{

    public static double f_exact(double r,double e0)
    {
        return r*Exp(-r);
    }

    public static int Main()
    {
        int counter = 0;
        double rmax = 8;
        double e0 = -1.0/2;

        Func<vector,vector> M = delegate(vector v)
        {
            counter++;
            var f_rmax = root.hydrogen_schrodinger(v[0],rmax);
            return new vector(f_rmax);
        }; 
        
        var epsilon = 1e-3;
        var v_start = new vector(-1.01);
        var r = root.newton(M,v_start);
        double energy = r[0];
        WriteLine("Finding the lowest root for rmax = {0} for the auxilliry function M(ε)=0",rmax);
        r.print("the root is: ");
        WriteLine("Function calls to find the root: {0}",counter);
        System.IO.StreamWriter data = new System.IO.StreamWriter("data.txt");
        for(double rs=0; rs<=rmax; rs+=rmax/64)
        {
            data.WriteLine("{0} {1} {2}",rs,root.hydrogen_schrodinger(energy,rs),f_exact(rs,e0));
        }
        data.Close();
        return 0;
    }
}
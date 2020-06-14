using System;
using static System.Console;
public class main{

    public static int Main()
    {    
        double epsilon = 1e-5;
        Func<vector,double> f_rosen = (x) =>
        {
            return (1-x[0])*(1-x[0])+ 100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
        };
        vector start = new vector(new double []{1.3,0.2});
        var min_rosen = minimization.qnewton(f_rosen,ref start,epsilon);
        vector x_rosen = new vector(new double[]{1.0,1.0});
        WriteLine("The Rosenbruck Valley function: f(x,y)=(1-x)^2+100(y-x^2)^2");
        start.print("Quasi newton minimum        : ");
        x_rosen.print($"The exact minimum           : ");
        WriteLine($"Number of steps             : {min_rosen} steps.");
        WriteLine("");


        Func<vector,double> f_himmel = (x) =>
        {
            return (x[0]*x[0]+x[1]-11)*(x[0]*x[0]+x[1]-11) + (x[0]-x[1]*x[1]-7)*(x[0]-x[1]*x[1]-7);
        };
        epsilon = 1e-4;
        vector start_h = new vector(new double []{-1,-1});
        vector x_himmel = new vector(new double []{3.0,2.0});
        var min_himmel = minimization.qnewton(f_himmel,ref start_h,epsilon);
        WriteLine("The Himmelblau function: f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2.");
        start_h.print("Quasi newton minimum        : ");
        x_himmel.print($"The exact minimum           : ");
        WriteLine($"Number of steps             : {min_himmel} steps.");
        
        return 0;
    }
    
}
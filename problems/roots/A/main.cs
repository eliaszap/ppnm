using System;
using static System.Console;
using static System.Math;
public class main{

    public static int Main()
    {
        //Test
        int counter = 0;
        Func<vector,vector> f_test = (z) =>
        {
            counter++;
            double x = 3*z[0]*z[0]-9;
            var res = new vector(new double[] {x} );
            return res;
        };
        var epsilon = 1e-5;
        var x_start = new vector(new double[] {1.0} );
        var r = root.newton(f_test,x_start,epsilon);
        WriteLine("Testing with the function f = 3x^2-9");
        r.print("The root of 3x^2-9 is: ");
        
        WriteLine("Anatically solved root: Sqrt(3) = {0}",Sqrt(3));
        WriteLine("Error: {0} ",r[0]-Sqrt(3));
        WriteLine("Number of function calls: {0}",counter);
        WriteLine("");

        // Rosenbrock's valley function
        counter = 0;
        WriteLine("Extremum(s) of the Rosenbrock's valley function: f(x,y) = (1-x)^2 + 100(y-x^2)^2");
        Func<vector,vector> f = (z) =>
        {
            counter++;
            var ddx = 2*(z[0]-1) + 400*z[0]*(z[0]*z[0] - z[1]); // d/dx f(x,y) = 2(x-1) + 400x(x^2 -y)
            var ddy = 200*(z[1]-z[0]*z[0]); // d/dy f(x,y) = 200(y-x^2)
		return new vector(ddx,ddy);
	    };
        var analytical_root = new vector(new double []{1.0,1.0});
        WriteLine("The exact root is: (x,y) = ({0},{1})",analytical_root[0],analytical_root[1]);
        WriteLine(" ");
        var eps = 1e-3;
        counter = 0;
        var start_1 = new vector(new double[] {0.5,0.5});
        var rosen_root = root.newton(f,start_1,eps);
        rosen_root.print($"The root of Rosenbruck: ");
        WriteLine("Number of functions calls: {0}",counter);
        // var start_2 = new vector(new double[] {1.1,0.5});
        // rosen_root = root.newton(f,start_2);
        // rosen_root.print("");
        
        return 0;
    }
}
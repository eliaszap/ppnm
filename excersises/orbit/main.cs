using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
class main{
    static int Main(){
        double x0 = 0;
        double x1 = 3;
        vector y0 = new vector(0.5);

        Func<double,vector, vector> y_diff = delegate(double x, vector y){
            return new vector(y[0]*(1-y[0]));
        };

        List<double> xs = new List<double>();
        List<vector> ys = new List<vector>();
        vector y1 = ode.rk23(y_diff,x0,y0,x1,xs,ys);

        double log = 0;
        for(int i=0;i<xs.Count; i++){
            log =1/(1+Exp(-xs[i]));
            Write($"{xs[i]} {ys[i][0]} {log}\n");    
        }


        return 0;
    }
}

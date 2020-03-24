using System;
using static System.Console;
using static System.Math;
class main{
    public static double exp_fit(double a, double k, double x){
            return a*Exp(k*x);
    }

    static int Main(){
        

        vector ts = new vector(new double[]{0,1,2,3,4,6,9,10,13,15});
        vector y = new vector(new double[]{100,117,100,88,72,53,29.5,25.2,15.2,11.1});
        vector dy = new vector(y/20);
        // WriteLine("Data and error:\n");
        System.IO.StreamWriter  data = new System.IO.StreamWriter("out-data.txt",append:false);
        for(int i = 0; i < dy.size;i++)
            data.WriteLine("{0} {1} {2}",ts[i],y[i],dy[i]);
        data.Close();
        var f = new Func<double,double>[]{t=>1,t=>t};
        var yexp = new vector(y.size);
        var dyexp = new vector(dy.size);
        for(int i = 0; i<ts.size;i++){
            yexp[i]=Log(y[i]);
            dyexp[i]= dy[i]/y[i];
        }
        var lsquare_fit = new lsquares();
        lsquare_fit.lsfit(f,ts,yexp,dyexp);
        var c = lsquare_fit.getC();
        var S = lsquare_fit.getS();
        double lam = c[1];
        double dlam = Sqrt(S[1,1]);
        double T = -Log(2)/lam;
        double dT = dlam/(lam*lam);
        WriteLine("The half-life time of Thx(224Ra) is: {0} +- {1} days",T,dT);
            c.print("c: ");
            S.print("S: ");
        
        System.IO.StreamWriter  efit = new System.IO.StreamWriter("out-expfit.txt",append:false);
        for(int i = 0; i<ts.size;i++){
            efit.WriteLine("{0} {1}",ts[i],exp_fit(Exp(c[0]),c[1],ts[i]));
        }
        efit.Close();
        
        
        return 0;
    }
}
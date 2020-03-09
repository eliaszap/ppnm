using static System.Console;
using static System.Math;
class main{
    
    static int Main(){
        double eps=1.0/32, dx = 1.0/16;
        for(double x=-4+eps  ; x <=6; x+=dx){
            WriteLine("{0,10:f3} {1,15:f8}",x,math.gamma(x));
        }
        double tg=1;
        for(double x=-4+eps; x <=100; x+=1){
            double gx=math.gamma(x);
            WriteLine("{0,10:f3} {1:g15} {2:g15}",x,gx,tg);
            tg*=x;
        }
        
        double d = 1.0/16;
        for(double x=-3; x<3; x+=d){
            Error.WriteLine("{0,10:f3} {1,15:f8}",x,math.erf(x));
        }
    return 0;
    }

}
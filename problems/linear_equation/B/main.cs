using System;
using static System.Math;
using static System.Console;

class main{

    public static int Main(){
        // int n=5;
        int m=4;
        var rand = new Random(1);
        // Assignment B
        matrix B = new matrix(m,m);
        for(int i = 0; i<m;i++){
            for(int j = 0; j<m;j++){
                B[i,j]=10*(rand.NextDouble());
            }
        }
        WriteLine("Assignment B: ");
        B.print($"Square matrix A with size  {m}x{m}, to do assigment B:");
        var qr_B = new qrdecompositionGS(B);
        var B_inv = qr_B.inverse();
        B_inv.print("The invers matrix of A, B=:");
        var bbinv = B*B_inv;
        bbinv.print("A*B=I"); 

    return 0;



    }
}
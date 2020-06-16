using System;
using static System.Console;
using static System.Math;
class main{

    static int Main(){
        var jacobi = new jacobi();
        var rand = new Random(1);
        int n=20, m=6;
        matrix A = new matrix(m,m);
        matrix A_V = new matrix(m,m);
        A_V.set_identity();
        for(int i =0; i<m;i++){
            for(int j = 0; j<m;j++){
                var value = 10*(rand.NextDouble()); 
                A[i,j] = value;
                A[j,i] = value;
            }
        }
        WriteLine("Assignment B:\n");
        WriteLine("1: Number of operations for matrix diagonalization of matrix size nxn:");
        // int x = 1000;
        // matrix B     = new matrix(x,x);
        // matrix   B_V = new matrix(x,x);
        // for(int i =0; i<x;i++){
        //     for(int j = 0; j<x;j++){
        //         var value = 10*(rand.NextDouble()); 
        //         B[i,j] = value;
        //         B[j,i] = value;
        //     }
        // }
        // B_V.set_identity();
        // var time1 = DateTime.Now;
        // var B_cs = jacobi.jac_cycsweep(B,B_V);
        // var time2 = DateTime.Now;
        // var timeop = time2-time1;
        WriteLine("Jacobi diagonalizing on a {100}x{100} matrix takes 0.05 seconds");
        WriteLine("Jacobi diagonalizing on a {1000}x{1000} matrix takes 111 seconds");
        WriteLine("The calculation has been omitted, but can be found in main.cs");
        return 0;
    }
}
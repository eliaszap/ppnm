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
        WriteLine("Assignment A:\n");
        matrix A_copy = A.copy();
        A.print($"Random symmetric {m}x{m} matrix: A=");
        var e = jacobi.jac_cycsweep(A,A_V);
        var new_A = A_V.transpose()*A_copy*A_V;
        new_A.print("Eigenvalue decomposition on A, D=V^TAV:");
        e.print("The eigenvalues:");
        WriteLine("\nD is a diagonal matrix with the eigenvalues in the diagonal.\n");
        double s=1.0/(n+1);
        matrix H = new matrix(n,n);
        for(int i=0;i<n-1;i++){
            H[i,i] = -2;
            H[i,i+1]=1; 
            H[i+1,i] = 1;
        }
        H[n-1,n-1] = -2;
        matrix.scale(H,-1/s/s);
        matrix H_V = new matrix(n,n);
        
        vector egenvals = jacobi.jac_cycsweep(H,H_V);

        for (int k=0; k < n/3; k++){
            double exact = PI*PI*(k+1)*(k+1);
            double calculated = egenvals[k];
            WriteLine($"{k} {calculated} {exact}");
        }   

        for(int k=0;k<3;k++){
            WriteLine($"{0} {0}");
            for(int i=0;i<n;i++){
                WriteLine($"{(i+1.0)/(n+1)} {H_V[i,k]}");
            }   
            WriteLine($"{1} {0}");
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
        WriteLine("The calculation has been omitted, but can be found in main.cs")
        return 0;
    }
}
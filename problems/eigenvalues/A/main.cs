using System;
using static System.Console;
using static System.Math;
class main{

    static int Main(){
        // var jacobi = new jacobi();
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

        WriteLine("Checking if energies are correct:");
        WriteLine("k    Calculated        Exact");
        for (int k=0; k < n/3; k++){
            double exact = PI*PI*(k+1)*(k+1);
            double calculated = egenvals[k];
            WriteLine($"{k} {calculated} {exact}");
        }   
        
        System.IO.StreamWriter[] datas = new System.IO.StreamWriter[3];
        for(int k=0;k<3;k++){
            datas[k] = new  System.IO.StreamWriter($"d{k+1}.txt");
            datas[k].WriteLine($"{0} {0}");
            for(int i=0;i<n;i++){
                datas[k].WriteLine($"{(i+1.0)/(n+1)} {H_V[i,k]}");
            }   
            datas[k].WriteLine($"{1} {0}");
            datas[k].Close();
        }
        // data.Close();
        return 0;
    }
}
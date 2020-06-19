using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;
class main{

    static int Main(){

        var rand = new Random(1);


        //Assignment B.1
        WriteLine("B1: See plot 1");
        System.IO.StreamWriter timedata = new System.IO.StreamWriter("timedata.txt",append:false);
        int Ns = 100;
        int n0 = 15;
        for(int n=n0;n<Ns;n+=2){
            Stopwatch sw = new Stopwatch();
            matrix v = new matrix(n,n);
            matrix A = new matrix(n,n);
            for(int i=0;i<n;i++)
            {
                for(int j=i;j<n;j++)
                {
                    A[i,j]=10*(rand.NextDouble()-0.5); 
                    A[j,i]=A[i,j];
                }
            }
            sw.Start();
            vector e = jacobi.jac_cycsweep(A,v);
            sw.Stop();
            timedata.WriteLine("{0} {1} {2}",n,sw.ElapsedMilliseconds,Pow(n/n0,3));
        }
        timedata.Close();

        //Assignment B2
        WriteLine("Assignment B(2,3,4):");
        int N = 5;
        matrix Ref = new matrix(N,N);
        matrix Ref_V = new matrix(N,N);
        matrix Ref_Vv = new matrix(N,N);
        Ref_V.set_identity();
        Ref_Vv.set_identity();
        for(int i =0; i<N;i++)
        {
            for(int j = 0; j<N;j++)
            {
                var value = 10*(rand.NextDouble()); 
                Ref[i,j] = value;
                Ref[j,i] = value;
            }
        }
        matrix J_cyc = Ref.copy();
        matrix J_val = Ref.copy();
        Ref.print($"A real symmetric matrix of size {N}x{N} A=");
        WriteLine("");
        WriteLine("Assignment B.3: compare number of sweeps/rotations to find the lowest eigenvalue with value-by-value to diagonalize with cyclic:");
        WriteLine("");
        int N_eigenvalues = 1;

        var J_cyced = jacobi.jac_cycsweep2(J_cyc,Ref_V);
        var Jc_rotations = J_cyced.rotations;
        var Jc_eigen = J_cyced.e_val;

        var J_valed = jacobi.jacobi_valbyval(J_val,Ref_Vv,N_eigenvalues);
        var Jv_rotations = J_valed.rotations;
        var Jv_eigen = J_valed.e_val;

        var D_cyc = Ref_V.transpose()*J_cyc*Ref_V;
        var D_val = Ref_Vv.transpose()*J_val*Ref_Vv;
        D_cyc.print("Diagonalized A with cyclic sweeps. D_cyc =");
        Jc_eigen.print($"The eignenvalues from the diagonalizing of A with cyclic sweeps:");
        WriteLine($"Number of rotations           : {Jc_rotations}");
        WriteLine("");
        D_val.print("First row and column of A Diagonalized with value by valye. D_val =");
        WriteLine($"Finding first eigenvalue of A with value by value: e_0 = {Jv_eigen[0]}");
        WriteLine($"Number of rotations         : {Jv_rotations}");
        WriteLine($"Thus value by value uses {Jv_rotations - Jc_rotations} more rotations to find the first eigenvalue. ");
        WriteLine("");
        WriteLine("Assignment B.4:");
        N_eigenvalues = N;
        matrix J_valmax = Ref.copy();
        matrix I_valmax = new matrix(N,N);
        I_valmax.set_identity();
        var J_valmaxed = jacobi.jacobi_valbyval(J_valmax,I_valmax,N_eigenvalues);
        var Jmax_rotations = J_valmaxed.rotations;
        var Jmax_eigen = J_valmaxed.e_val;
        var D_valmax = I_valmax.transpose()*J_valmax*I_valmax;

        D_valmax.print("Full Diagonalized A with value by valye. D_valmax =");
        Jmax_eigen.print("Finding all eigenvalues of A with value by value: es= ");
        WriteLine($"Number of rotations         : {Jmax_rotations}");
        WriteLine($"Thus value by value uses {Jmax_rotations - Jc_rotations} more rotations to find all the eigenvalues. ");
        WriteLine("");
        WriteLine("Assignment B.5:");

        matrix J_high = Ref.copy();
        matrix I_high = new matrix(N,N);
        I_high.set_identity();
        var J_highed = jacobi.jacobi_valbyval_highest(J_high,I_high,N_eigenvalues);
        var Jhigh_eigen = J_highed.e_val;
        var D_high = I_high.transpose()*J_high*I_high;

        D_high.print("Full Diagonalized A with value by valye with highest eigenvalues sorted first. D_high =");
        Jhigh_eigen.print($"Finding all eigenvalues of A with value by value sorted with highest first: e_high= ");
        Jmax_eigen.print($"Finding all eigenvalues of A with value by value sorted with loweest first: e_low= ");
        WriteLine("");
        return 0;
    }
}
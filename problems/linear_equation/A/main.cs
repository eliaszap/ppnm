using System;
using static System.Math;
using static System.Console;

class main{

    public static int Main(){
        int n=5;
        int m=4;
        matrix A = new matrix(n,m); 
        var rand = new Random(1);
        for(int i = 0; i<n;i++){
            for(int j = 0; j<m;j++){
                A[i,j]=10*(rand.NextDouble());
            }
        }
        

        // A.1
        WriteLine("Assignment A.1:");
        A.print($"Matrix A {n}x{m}:");
        var qr_A = new qrdecompositionGS(A);
        var Q = qr_A.Q;
        var R = qr_A.R;
        R.print($"The upper triangular matrix R:");
        var qq = Q.transpose()*Q;
        qq.print($"Q^T Q =1: ");
        var qr = Q*R;
        qr.print($"Q*R=A: ");
        if(A.approx(Q*R)){
            Write("Q*R=A, test passed\n");
        }
        else{ 
            Write("Q*R!=A, test failed\n");
        }
        WriteLine("");
        // A.2
        WriteLine("Assignment A.2:");
        matrix A2 = new matrix(n,n); 
        for(int i = 0; i<n;i++){
            for(int j = 0; j<n;j++){
                A2[i,j]=10*(rand.NextDouble());
            }
        }
        A2.print($"Matrix A {n}x{n}:");
        var qr_A2 = new qrdecompositionGS(A2);
        vector b = new vector(n);
       
        for(int i = 0; i<n;i++){
            b[i]=10*(rand.NextDouble());
        }
        b.print($"Vector b with size {n}: ");
        var qrxb= qr_A2.solve(qr_A2.Q,b);
        qrxb.print($"solve x for QRx=b:\nx = ");
        var ax = A2*qrxb;
        ax.print("Ax = "); 
        WriteLine("which is equal to b.\n");
    

        // // Assignment B
        // matrix B = new matrix(m,m);
        // for(int i = 0; i<m;i++){
        //     for(int j = 0; j<m;j++){
        //         B[i,j]=10*(rand.NextDouble());
        //     }
        // }
        // WriteLine("Assignment B: ");
        // B.print($"Square matrix A with size  {m}x{m}, to do assigment B:");
        // var qr_B = new qrdecompositionGS(B);
        // var B_inv = qr_B.inverse();
        // B_inv.print("The invers matrix of A, B=:");
        // var bbinv = B*B_inv;
        // bbinv.print("A*B=I"); 

    return 0;



    }
}
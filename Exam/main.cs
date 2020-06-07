using System;
using static System.Console;
class main
{
    static int Main()
    {
    
    var rand = new Random(1);
    int n = 10;
    matrix A = new matrix(n,n);
    for(int i = 0; i<n;i++)
    {
        for(int j = 0; j<n;j++)
        {
        var value = rand.NextDouble()*10;   
        A[i,j] = value;
        A[j,i] = value;
        }
    }
    A.print($"A real symmetric matrix of the size {n}x{n}, A=");
    WriteLine();
    var x = lanczos.lanczos_al(A);
    var T = x.T;
    var V = x.V;
    T.print("The tridiagonal matrix T=");
    WriteLine();
    V.print("The orthogonal matrix V=");
    WriteLine();
    var V_trans = V.transpose();
    var A_again =  V*T*V_trans;
    A_again.print("A = VTV^T =");
    WriteLine();
    (A-A_again).print("A test to see if A = VTV^T by subtraction: A - VTV^T = null matrix ");
    WriteLine();
    WriteLine("Thus the Lanczos tridiagonalization algorithm for real symmetric matrices has been implemented.");
    WriteLine("Note that the algorithm  only works for 2<=n<13, for n>14 the subtraction test fails. ");
    return 0;   
    }


}
using System;
using static System.Console;
public class qrdecompositionGS{
    public readonly matrix Q,R;

    // Assignment A.1
    public qrdecompositionGS(matrix A){
        Q = A.copy();
        int m = A.size2;
        R = new matrix(m,m);
        for(int i = 0; i<m;i++){
            R[i,i] = Q[i].norm();
            Q[i]/=R[i,i];
            for(int j = i+1;j<m;j++){
                R[i,j]=Q[i].dot(Q[j]);
                Q[j] -= Q[i]*R[i,j];
            }
        }
    }

    // Assignment A.2
    public vector backsubstitution(vector x){
        int n = x.size;
        for(int i = n-1; i>=0;i--){
            double sum = x[i];
            for(int j = i+1; j<n;j++){
                sum -= R[i,j]*x[j];
            }
            x[i] = sum/R[i,i];
        }
        return x;
    }

    public vector solve(vector b){
        var qtb = Q%b;
        return backsubstitution(qtb);
        
    }

    // Assignment B   
    public matrix inverse(){
        int n = Q.size1, m = Q.size2;
        matrix A_inv = new matrix(n,m);
        vector e = new vector(n);
        var qr_B = new qrdecompositionGS(Q*R);
        // var Q_inv = qr_B.Q;
        for(int i = 0; i<n;i++){
                e[i] = 1;
                A_inv[i]= qr_B.solve(e);
                e[i]=0;
        }
        return A_inv;
    }

}
using System;
using System.Collections.Generic;


public class lsquares{
    
    public  matrix S;
    public  vector c;
    public Func<double,double>[] f;

    public void setS(matrix m){
        S = m;
    }
    public matrix getS(){
        return S;
    }
    public void setC(vector p){
        c = p;
    }
    public vector getC(){
        return c;
    }

    public void lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
        int n = x.size, m = fs.Length;
        matrix A = new matrix(n,m);
        vector b = new vector(n);
        for(int i = 0; i<n;i++){
            b[i] = y[i]/dy[i];
            for(int k = 0; k<m;k++){
                A[i,k] = fs[k](x[i])/dy[i]; 
            }
        }
        var qr_A = new qrdecompositionGS(A);
        var c = qr_A.backsubstitution(qr_A.R,qr_A.Q.transpose()*b);
        setC(c);
        var R_inv = qr_A.inverse(qr_A.R);
        // var R_inv = qr_A.backsubstitution(qr_A.R*(qr_A.Q.transpose()*qr_A.Q));
        var S = R_inv*R_inv.transpose();
        setS(S);
        f = fs;
    }

    public double f_c(double x){
        double res = 0;
        for(int i=0; i<f.Length;i++){
            res += c[i]*f[i](x);
        }
        return res;
    }
}
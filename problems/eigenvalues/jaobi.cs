using System;
using static System.Math;
public class jacobi{
    public jacobi(){}
    public static vector jac_cycsweep(matrix A_arg, matrix V){
        var A = A_arg.copy();
        int sweeps=0;
        int n = A.size1;
        bool changed;
        vector e = new vector(n);
        for(int i=0; i<n;i++){
            e[i] =  A[i,i];
        }
        V.set_identity();
        do{
            changed=false; sweeps++; int p,q;
            for(p=0;p<n;p++){
                for(q=p+1;q<n;q++){
                    double app = e[p];
                    double aqq = e[q];
                    double apq = A[p,q];
                    double phi = 0.5*Atan2(2*apq,aqq-app);
                    double c = Cos(phi);
                    double s = Sin(phi);
                    double app1 = c * c * app - 2 * s * c * apq + s * s * aqq;
                    double aqq1 = s * s * app + 2 * s * c * apq + c * c * aqq;
                    if(app1 != app || aqq1 != aqq) {
                        changed = true;
                        e[p] = app1;
                        e[q] = aqq1;
                        A[p,q] = 0.0;
                        for(int i = 0; i<p;i++){
                            double aip = A[i,p];
                            double aiq = A[i,q];
                            A[i,p] = c * aip - s * aiq;
                            A[i,q] = c * aiq + s * aip;
                        }
                        for(int i = p+1; i<q; i++){
                            double api = A[p,i];
                            double aiq = A[i,q];
                            A[p,i] = c * api - s * aiq;
                            A[i,q] = c * aiq +  s * api;
                        }
                        for(int i = q+1; i<n; i++){
                            double api = A[p,i];
                            double aqi = A[q,i];
                            A[p,i] = c * api - s * aqi;
                            A[q,i] = c * aqi + s * api;
                        }
                        for(int i = 0; i<n;i++){
                            double vip = V[i,p];
                            double viq = V[i,q];
                            V[i,p] = c * vip - s * viq;
                            V[i,q] = c * viq + s *vip;
                        }
                    }
                }   
            }
        }
        while (changed!=false);
        return e;
    }
}
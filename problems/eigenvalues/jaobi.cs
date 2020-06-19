using System;
using static System.Math;
using static System.Console;

public static class jacobi
{
    
    public class Result{
		public int sweeps, rotations;
        public vector e_val;
		public Result(int s, int r, vector e)
			{
				sweeps = s; rotations = r; e_val = e;
			}
	}

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
            changed=false; sweeps++;
            for(int p=0;p<n;p++){
                for(int q=p+1;q<n;q++){
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

    public static Result jacobi_valbyval(matrix A_arg, matrix V,int N)
    {
        var A = A_arg.copy();
        int rotations=0;
        int sweeps = 0;
        int n = A.size1;
        bool changed;
        vector e = new vector(n);
        for(int i=0; i<n;i++)
        {
            e[i] =  A[i,i];
        }
        // WriteLine("1");
        V.set_identity();
        for(int p=0;p<N;p++)
        {   
            // WriteLine("her");
            do
            { changed = false; sweeps++;
                for(int q=p+1;q<n;q++)
                {
                    double app = e[p];
                    double aqq = e[q];
                    double apq = A[p,q];
                    double phi = 0.5*Atan2(2*apq,aqq-app);
                    double c = Cos(phi);
                    double s = Sin(phi);
                    double app1 = c * c * app - 2 * s * c * apq + s * s * aqq;
                    double aqq1 = s * s * app + 2 * s * c * apq + c * c * aqq;
                
                    if(app1 != app || aqq1 != aqq)
                    {
                        rotations++;
                        changed = true;
                        e[p] = app1;
                        e[q] = aqq1;
                        A[p,q] = 0.0;
                        for(int i = 0; i<p;i++)
                        {
                            double aip = A[i,p];
                            double aiq = A[i,q];
                            A[i,p] = c * aip - s * aiq;
                            A[i,q] = c * aiq + s * aip;
                        }

                        for(int i = p+1; i<q; i++)
                        {
                            double api = A[p,i];
                            double aiq = A[i,q];
                            A[p,i] = c * api - s * aiq;
                            A[i,q] = c * aiq +  s * api;
                        }


                        for(int i = q+1; i<n; i++)
                        {
                            double api = A[p,i];
                            double aqi = A[q,i];
                            A[p,i] = c * api - s * aqi;
                            A[q,i] = c * aqi + s * api;
                        }

                        if(V!=null)
                        {
                            for(int i = 0; i<n;i++)
                            {
                                double vip = V[i,p];
                                double viq = V[i,q];
                                V[i,p] = c * vip - s * viq;
                                V[i,q] = c * viq + s *vip;
                            }
                        }

                    }

                }
                // WriteLine("2");
            }while(changed);
        }
        Result res = new Result(sweeps,rotations,e);
        return res;
    }

    public static Result jacobi_valbyval_highest(matrix A_arg, matrix V,int N)
    {
        var A = A_arg.copy();
        int rotations=0;
        int sweeps = 0;
        int n = A.size1;
        bool changed;
        vector e = new vector(n);
        for(int i=0; i<n;i++)
        {
            e[i] =  A[i,i];
        }
        // WriteLine("1");
        V.set_identity();
        for(int p=0;p<N;p++)
        {   
            // WriteLine("her");
            do
            { changed = false; sweeps++;
                for(int q=p+1;q<n;q++)
                {
                    double app = e[p];
                    double aqq = e[q];
                    double apq = A[p,q];
                    double phi = 0.5*Atan2(-2*apq,-aqq+app);
                    double c = Cos(phi);
                    double s = Sin(phi);
                    double app1 = c * c * app - 2 * s * c * apq + s * s * aqq;
                    double aqq1 = s * s * app + 2 * s * c * apq + c * c * aqq;
                
                    if(app1 != app || aqq1 != aqq)
                    {
                        rotations++;
                        changed = true;
                        e[p] = app1;
                        e[q] = aqq1;
                        A[p,q] = 0.0;
                        for(int i = 0; i<p;i++)
                        {
                            double aip = A[i,p];
                            double aiq = A[i,q];
                            A[i,p] = c * aip - s * aiq;
                            A[i,q] = c * aiq + s * aip;
                        }

                        for(int i = p+1; i<q; i++)
                        {
                            double api = A[p,i];
                            double aiq = A[i,q];
                            A[p,i] = c * api - s * aiq;
                            A[i,q] = c * aiq +  s * api;
                        }


                        for(int i = q+1; i<n; i++)
                        {
                            double api = A[p,i];
                            double aqi = A[q,i];
                            A[p,i] = c * api - s * aqi;
                            A[q,i] = c * aqi + s * api;
                        }

                        if(V!=null)
                        {
                            for(int i = 0; i<n;i++)
                            {
                                double vip = V[i,p];
                                double viq = V[i,q];
                                V[i,p] = c * vip - s * viq;
                                V[i,q] = c * viq + s *vip;
                            }
                        }

                    }

                }
                // WriteLine("2");
            }while(changed);
        }
        Result res = new Result(sweeps,rotations,e);
        return res;
    }

    /*Made cyc again to return sweeps and e for assignment B and make V= null as default.
    I didn't want to rewrite mainA, so this solution was chosenn instead. */
    public static Result jac_cycsweep2(matrix A_arg, matrix V){
        var A = A_arg.copy();
        int sweeps=0;
        int rotations=0;
        int n = A.size1;
        bool changed;
        vector e = new vector(n);
        for(int i=0; i<n;i++){
            e[i] =  A[i,i];
        }
        V.set_identity();
        do{
            changed=false; sweeps++;
            for(int p=0;p<n;p++){
                for(int q=p+1;q<n;q++){
                    double app = e[p];
                    double aqq = e[q];
                    double apq = A[p,q];
                    double phi = 0.5*Atan2(2*apq,aqq-app);
                    double c = Cos(phi);
                    double s = Sin(phi);
                    double app1 = c * c * app - 2 * s * c * apq + s * s * aqq;
                    double aqq1 = s * s * app + 2 * s * c * apq + c * c * aqq;
                    if(app1 != app || aqq1 != aqq) {
                        changed = true; rotations++;
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
        Result res = new Result(sweeps,rotations,e);
        return res;
    }

    
}
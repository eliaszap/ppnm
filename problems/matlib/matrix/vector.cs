// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.
using System;
using static System.Math;
public partial class vector{

private double[] data;
public int size{ get{return data.Length;} }

public double this[int i]{
	get{return data[i];}
	set{data[i]=value;}
}

public vector(int n){data=new double[n];}
public vector(double[] a){data=a;}
public vector(double a, double b)
	{ data = new double[]{a,b}; }
public vector(double a){data = new double[] {a};}

public static implicit operator vector (double[] a){ return new vector(a); }
public static implicit operator double[] (vector v){ return v.data; }

public void print(string s=""){
	System.Console.Write(s);
	for(int i=0;i<size;i++) System.Console.Write("{0:f3} ",this[i]);
	System.Console.Write("\n");
}
public vector copy(){
	vector b=new vector(this.size);
	for(int i=0;i<this.size;i++)b[i]=this[i];
	return b;
}

public static vector operator+(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]+u[i];
	return r; }

public static vector operator-(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]-u[i];
	return r; }

public static vector operator*(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=a*v[i];
	return r; }

public static vector operator*(double a, vector v){
	return v*a; }

public static vector operator/(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=v[i]/a;
	return r; }
public static vector operator-(vector v, double a){
	vector r = new vector(v.size);
	for(int i =0; i<v.size;i++)
	{
		r[i] = v[i]-a;
	}
	return r;
}

public static bool approx(double x, double y, double eps=1e-9){
	if(Math.Abs(x-y)<eps)return true;
	if(Math.Abs(x-y)/(Math.Abs(x)+Math.Abs(y))<eps)return true;
	return false;
	}

public bool approx(vector o){
	for(int i=0;i<size;i++)
		if(!approx(this[i],o[i]))return false;
	return true;
	}

public double norm(){
	if(this[0] == 0 && size == 1){
		return (double) 1e-7;
	}
	double meanabs=0;
	for(int i=0;i<size;i++)meanabs+=Abs(this[i]);
	meanabs/=size;
	double sum=0;
	for(int i=0;i<size;i++)sum+=(this[i]/meanabs)*(this[i]/meanabs);
	return meanabs*Sqrt(sum);
	}

public double dot(vector o){
	double sum=0;
	for(int i=0;i<size;i++)sum+=this[i]*o[i];
	return sum;
	}

public static vector linspace(double z0, double zend, int N){
	var z = new vector(N);
	for(int i=0;i<N;i++){
        z[i] = z0+(zend-z0)/(N-1)*i;
	}
	return z;
}
public static double sum(vector x)
{
	double sum = 0;
	for(int i = 0; i<x.size;i++)
	{
		sum += x[i];
	}
	return sum;
}

}//vector

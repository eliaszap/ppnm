using System;
using static System.Console;
using static System.Math;
using static  complex;
using static cmath;
class main{
	static int Main(){
/*
		double x = 1;
		char c ='ø';
		string s = "hello";
		Write("sin{0}={1}\n",x,Sin(x));
		Write($"sin({x})={Sin(x)}\n");
		int i = 100;
		Write($"i={i}\n");
*/
		
		// complex i = new complex (complex.sqr(2),0);
		complex sqr_2 = sqrt(2);
		complex I = new complex(0,1);
		complex e = E;
		complex ei = e.pow(I);
		complex eipi = e.pow(I*PI);
		complex ipowi = I.pow(I);
		complex sipi = sin(I*PI);
		Write($"sqrt(2) ={sqr_2}\n ");
		Write($"i^i = {ipowi}\n ");
		Write($"sin(i*pi)={sipi}\n"); 
		Write($"e^i={ei}\n");
		Write($"e^(ipi)={eipi}\n");
		return 0;
	}
}

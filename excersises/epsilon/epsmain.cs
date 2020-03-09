using System;
using static System.Console;
using static System.Math;
using static epsilonD;


class Epsilonmain{
        static int Main(){
// Excersise A	

	int i = 1;
	while(i+1>i){i++;}
	Write("my max int ={0}\n",i);
	Write("int max value = {0}\n",int.MaxValue);
	i = 1;
	while(i-1<i){i--;}
	Write("my min int = {0}\n",i);
	Write("int min value = {0}\n", int.MinValue);	
// Excersise B
	double x = 1;
	while(1+x!=1){x/=2;} x*=2;
	float y = 1F; 
	while((float)(1F+y) != 1F){y/=2F;} y*=2;
	Write("x={0}\n",x);
	Write("y={0}\n",y);
	
// Excersise C
	int max=int.MaxValue/3;
	int j = 0;
	float float_sum_up=1F;
	for(j=2;j<max;j++){float_sum_up+=1F/j;}
	Write("float_sum_up={0}\n",float_sum_up);

	float float_sum_down=1F/max;
	for(j=max-1;j>0;j--){float_sum_down+=1F/j;}
	Write("float_sum_down={0}\n",float_sum_down);
	
	/* ii: Because we use floats, it cannot calculate  with enough precision when we divide with with MaxValue.
		If they were doubles instead sum_down and sum_up would show the same result.

  	iii: if Max kept on expanding, even doubles cannot write them with enough precision, so they would converge to zero.
	*/
	int k = 0;
	double double_sum_up=1.0;
	for(k=2;k<max;k++){double_sum_up+=1.0/k;}
	Write("double_sum_up={0}\n",double_sum_up);	

	double double_sum_down=1.0/max;
	for(k=max-1;k>0;k--){double_sum_down+=1.0/k;}

	Write("double_sum_down={0}\n",double_sum_down);

	/* iv: they have the same result: 20.96, and thats because it is now doubles, which can write the numbers with enough precision.

	*/
	
	
// Excersise D
	double f =666.0;
	double g = 666.01;
	double h = 666.00000000000000000000000000000001;
	Write("is f and g equal? {0}\n", approx(f,g));
	Write("is f and h equal? {0}\n", approx(f,h));

	return 0;
	}
}	

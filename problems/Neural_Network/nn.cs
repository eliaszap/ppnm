using System;
public class nn
{
    
    int n; /* number of hidden neurons */
	Func<double,double> f; /* activation function */
	vector params; /* network parameters */
	double feedforwad(double x); /* apply the network to input parameter x */
	void train(vector x,vector y); /* train to interpolate the given table {x,y} */
}
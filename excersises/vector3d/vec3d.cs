using System;
using static System.Math;
public struct vector3d{
    public static int Main(){return 0;}
    public double x,y,z;
    
    public vector3d(double a, double b, double c){x=a; y=b; z=c;}
    


    public static vector3d operator*(vector3d v, double c){return new vector3d(c*v.x,c*v.y,c*v.z);}
    public static vector3d operator*(double c, vector3d v){return v*c;}
    public static vector3d operator+(vector3d u, vector3d v){return new vector3d(v.x+u.x,v.y+u.y,v.z+v.x);}
    public static vector3d operator-(vector3d u, vector3d v){return new vector3d(v.x-u.x,v.y-u.y,v.z-v.x);}
    //methods
    public double dot_product(vector3d other){return (this.x * other.x +this.y * other.y +this.z * other.z);}
    public vector3d vector_product(vector3d other){return new vector3d(this.y*other.z-this.z*other.y,
                                                            this.z*other.x - this.x*other.z,
                                                            this.x*other.y - this.y*other.x);
                                            }
    public double magnitude(){
        if(x > y){
            if(z > x) { return z*System.Math.Sqrt(1+Pow((x/z),2)+Pow((y/z),2));} 
            else  return x*System.Math.Sqrt(1+Pow((y/x),2)+Pow((z/x),2));}
        else if(z > y){ return z*System.Math.Sqrt(1+Pow((x/z),2)+Pow((y/z),2)); }
        else return y*System.Math.Sqrt(1+Pow(x/y,2)+Pow((z/y),2));
        
    }

    public override string ToString(){
    return string.Format( "x= {0} y= {1} z= {2}",x,y,z);
    } 

    public void print(string s=" "){
            System.Console.Write(s);    
                System.Console.Write("{0:f3} ",this.x);
                System.Console.Write("{0:f3} ",this.y);
                System.Console.Write("{0:f3} ",this.z);    
                System.Console.Write("\n");
    }
}
class main{

    public static int Main(){
        
        vector3d v= new vector3d(1,2,3);
        vector3d u = new vector3d(7,5,8);
        v.print("v= ");
        u.print("u= ");
        vector3d w = u+v;
        w.print("w= ");
        (v*2).print("2*v= ");
        vector3d A = v.vector_product(u);
        A.print("v x u = ");
        double B = v.dot_product(u);
        System.Console.Write("v dot u ={0}\n",B);
        double C = v.magnitude();
        System.Console.Write("|v| ={0}\n",C);

        
        
        return 0;
    }

}
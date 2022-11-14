
using System;
using System.Globalization;

namespace Exercicio1{
    class Ex1{
        static void Main(string[] args){
            System.Console.WriteLine("Entre as medidas do triangulo 1 e 2(x1 x2 x3 y1 y2 y3):");
            string[] inp = Console.ReadLine().Split(' ');
            double x1=0, y1=0, x2=0, y2=0,x3=0, y3=0;
            double A1=0, A2=0;
            x1 = double.Parse(inp[0], CultureInfo.InvariantCulture);
            x2 = double.Parse(inp[1], CultureInfo.InvariantCulture);
            x3 = double.Parse(inp[2], CultureInfo.InvariantCulture);
            y1 = double.Parse(inp[3], CultureInfo.InvariantCulture);
            y2 = double.Parse(inp[4], CultureInfo.InvariantCulture);
            y3 = double.Parse(inp[5], CultureInfo.InvariantCulture);
            A1 = Area_Heron(x1,x2,x3);
            A2 = Area_Heron(y1,y2,y3);
            System.Console.WriteLine(A1);
            System.Console.WriteLine(A2);
            if (A1>=A2){
                System.Console.WriteLine($"Area Triangulo 1: {A1}");
            } else{
                System.Console.WriteLine($"Area Triangulo 2: {A2}");
            }


        }
        static double Area_Heron(double m1, double m2, double m3){
            double p = (m1+m2+m3)/2.0;
            return Math.Sqrt(p*(p-m1)*(p-m2)*(p-m3));
        }
    
    }
}

using System;
using System.Globalization;

namespace Exercicio1b{
    class Ex1b{
        static void Main(string[] args){
            System.Console.WriteLine("Entre as medidas do triangulo 1 e 2(x1 x2 x3 y1 y2 y3):");
            string[] inp = Console.ReadLine().Split(' ');
            Triangulo x, y;
            x = new Triangulo();
            y = new Triangulo();
            double A1=0; double A2;
            x.m1 = double.Parse(inp[0], CultureInfo.InvariantCulture);
            x.m2 = double.Parse(inp[1], CultureInfo.InvariantCulture);
            x.m3 = double.Parse(inp[2], CultureInfo.InvariantCulture);
            y.m1 = double.Parse(inp[3], CultureInfo.InvariantCulture);
            y.m2 = double.Parse(inp[4], CultureInfo.InvariantCulture);
            y.m3 = double.Parse(inp[5], CultureInfo.InvariantCulture);
            A1 = x.AreaHeron();
            A2 = y.AreaHeron();
            System.Console.WriteLine(A1);
            System.Console.WriteLine(A2);
            if (A1>=A2){
                System.Console.WriteLine($"Area Triangulo 1: {A1}");
            } else{
                System.Console.WriteLine($"Area Triangulo 2: {A2}");
            }


        }

    
    }
}
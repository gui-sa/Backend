using System;

namespace Funcoes{
    class funcao{
        static void Main(string[] args){
            //functions reduces unecessary repetitions.
            // might accept inputs and returns something.
            //funtions inside a class is named as methods.
            System.Console.Write("Please Enter 3 numbers like in example(10 20 30): ");
            string[] inp = Console.ReadLine().Split(' ');
            double n1 = 0; 
            double n2 = 0;
            double n3= 0;
            n1 = double.Parse(inp[0]);
            n2 = double.Parse(inp[1]);
            n3 = double.Parse(inp[2]);

            double res =  Maior(n1,n2,n3);

            System.Console.WriteLine(res);
            
        }
        static double Maior(double a, double b, double c){
            double res = 0.0;
            if ((a>=b)&&(a>c)){
                res = a;
            }
            if ((b>a)&&(b>=c)){
                res = b;
            }
            if ((c>b)&&(c>=a)){
                res = c;
            }
            return res;
        }
    }
}
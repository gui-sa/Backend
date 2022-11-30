using System;
using System.Collections.Generic;

namespace Teste
{
    class Teste
    {
        public static void Main(string[] args)
        {

            List<Teste2> tes = new List<Teste2>();
            tes.Add(new Teste2(10));
            tes.Add(new Teste2(0));
            try{
                tes.Add(new Teste2(-10));

            }catch{
                tes.Add(new Teste2(0));
            }
            foreach(var x in tes){
                System.Console.WriteLine(x.P);
            }            

        }
    }
    class Teste2{
        public int P { get; set; }
        public Teste2(int x){
            if (x<0){
                throw new Exception("Nao use valores negativos");
            }
            this.P = x;
        }
    }
}

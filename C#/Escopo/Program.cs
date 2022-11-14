
//Escopo eh a regiao do codigo onde a variavel eh valida ou assume tal valor.

using System;

namespace Escopos{
    class Escopo{
        static void Main(string[] args){
            //Voce nao pode usar uma variavel que ainda nao possui valor, que so foi iniciada.
            double preco = double.Parse(Console.ReadLine());
            double desconto = 0.0; //o C# olha pelas possibilidades, caso o exista.
            if (preco>90.00){
                //double desconto = preco*0.1; //uma var so existe dentro da estrutura, quando declarada dentro da funcao..
                desconto = preco*0.1;   
            }

            System.Console.WriteLine(desconto);
        }
    }
}
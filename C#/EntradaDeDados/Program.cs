using System;
using System.Globalization; //To guarantee that comma will be represented as point.

namespace EntradaDeDados{


    class EntradaDeDado{
        static void Main(string[] args){

            //Some warnings will happen because of possibilities.
            string frase = (string)Console.ReadLine();// Bloqueante... Recebe como string.
            System.Console.WriteLine($"Voce digitou: {frase}");
            string[] palavras = frase.Split(' '); //spliting da string e guardando em uma lista de string
            //System.Console.WriteLine(palavras[1]);// acessando segundo valor do vetor.
            //Para receber nome idade saldo... vamos ter que converter tipos
            string nome = palavras[0];
            int idade = int.Parse(palavras[1]); //int.parse converts from string to integer
            double saldo = double.Parse(palavras[2],CultureInfo.InvariantCulture);//double.parse converts from string to double and interpreting the decimals as point delimiter.

            System.Console.WriteLine(nome);
            System.Console.WriteLine(idade);
            System.Console.WriteLine(saldo.ToString("f2", CultureInfo.InvariantCulture));//printing with two decimals numbers and point to separate it.

            //System.Console.WriteLine($"You passed this argument {args[0]}"); // The first argument is at zero position! 
        }
    }
}

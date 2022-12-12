using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace CodingTank
{
    class Avaliacao
    {
        public static void Main(string[] args)
        {

            int valorSaque = default(int);
            System.Console.Write("Qual o valor do saque?\nValor: ");
            bool converted = int.TryParse(Console.ReadLine(), out valorSaque);
            while (!converted)
            {
                System.Console.Write("Qual o valor do saque?\nValor: ");
                converted = int.TryParse(Console.ReadLine(), out valorSaque);
            }
            int notas2 =default(int);
            int notas5 =default(int);
            int notas10 =default(int);
            int notas20 =default(int);
            int notas50 =default(int);
            int notas100 =default(int);
            int resto = valorSaque;

            string resultado = "";


            if(valorSaque/100>=1){
                notas100 = valorSaque/100;
                resto = valorSaque%100;
                if((resto==1)||(resto==3)){
                    notas100--;
                    resto +=100;
                }
                if(notas100>0){
                    resultado += $"{notas100} nota de 100 ";
                }

            }
            if(resto/50>=1){
                notas50 = resto/50;
                resto = resto%50;
                if((resto==1)||(resto==3)){
                    notas50--;
                    resto +=50;
                }
                if(notas50>0){
                resultado += $"{notas50} nota de 50 ";
                }
            }
            if(resto/20>=1){
                notas20 = resto/20;
                resto = resto%20;
                if((resto==1)||(resto==3)){
                    notas20--;
                    resto +=20;
                }
                if(notas20>0){
                resultado += $"{notas20} nota de 20 ";
                }
            }
            if(resto/10>=1){
                notas10 = resto/10;
                resto = resto%10;
                if((resto==1)||(resto==3)){
                    notas10--;
                    resto +=10;
                }
                if(notas10>0){
                resultado += $"{notas10} nota de 10 ";
                }
            }
            if(resto/5>=1){
                notas5 = resto/5;
                resto = resto%5;
                if((resto==1)||(resto==3)){
                    notas5--;
                    resto +=5;
                }
                if(notas5>0){
                resultado += $"{notas5} nota de 5 ";
                }
            }
            if(resto/2>=1){
                notas2 = resto/2;
                resto = resto%2;
                resultado += $"{notas2} nota de 2 ";
            }


            System.Console.WriteLine(resultado);

        }
    }
}
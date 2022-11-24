using System;
using System.Globalization;

namespace Classe
{
    public class ClassDiary{
        public static void Main(string[] args){
            System.Console.WriteLine("Bem vindo ao diario de classe!");

            decimal mediaFinal = 0;
            System.Console.WriteLine("Qual a nota da primeira prova? (Por favor, use o ponto como separador decimal, exemplo: 9.7)");
            decimal nota1 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            mediaFinal = nota1;
            System.Console.WriteLine($"Qual a nota da segunda prova? (Por favor, use o ponto como separador decimal, exemplo: 9.7)\nMédia atual: {mediaFinal.ToString("f2")} pontos");
            decimal nota2 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            mediaFinal = (nota1+nota2)/2.0F;
            System.Console.WriteLine($"Qual a nota da terceira prova? (Por favor, use o ponto como separador decimal, exemplo: 9.7)\nMédia atual: {mediaFinal.ToString("f2")} pontos");
            decimal nota3 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            mediaFinal = (nota1+nota2+nota3)/3.0F;
            System.Console.WriteLine($"Qual a nota da quarta prova? (Por favor, use o ponto como separador decimal, exemplo: 9.7)\nMédia atual: {mediaFinal.ToString("f2")} pontos");
            decimal nota4 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            mediaFinal =(nota1+nota2+nota3+nota4)/4.0F ;

            
            decimal notaMinimaRequerida = 7.0F;
            decimal notaRecuperacao = default(decimal);
            if (mediaFinal>=notaMinimaRequerida){
                System.Console.WriteLine($"É com prazer que informamos que o aluno foi aprovado!\nMédia final de {mediaFinal.ToString("f2")} pontos.");
                System.Environment.Exit(0);
            }else{
                System.Console.WriteLine($"\nO aluno tem direito a uma prova de recuperação! Média final atual: {mediaFinal.ToString("f2")} pontos.\nQual a nota da prova de recuperação? (Por favor, use o ponto como separador decimal, exemplo: 9.7)");
                notaRecuperacao = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                mediaFinal = (mediaFinal+notaRecuperacao)/2.0F;
            }

            if(mediaFinal>=notaMinimaRequerida){
                System.Console.WriteLine($"\n\nÉ com prazer que informamos que o aluno foi aprovado na recuperação!\nMédia final de {mediaFinal.ToString("f2")} pontos.");
            }else{
                System.Console.WriteLine($"\n\nO aluno infelizmente não foi aprovado na recuperação...\nMédia final de {mediaFinal.ToString("f2")} pontos...");
            }

        }

    }
}

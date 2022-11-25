using System;
using System.Globalization;

namespace ClasseDiario
{
    public class ClassDiary
    {
        public static void Main(string[] args)
        {

            System.Console.WriteLine("Bem vindo ao diario de classe!");

            decimal media = default(decimal);
            decimal nota1 = InputHandler.ReceberNota($"\nQual a primeira nota de prova?\nMédia atual: {media.ToString("f2")} pontos\nValor: ");
            media = Matematica.Media(nota1);

            decimal nota2 = InputHandler.ReceberNota($"\nQual a segunda nota de prova?\nMédia atual: {media.ToString("f2")} pontos\nValor: ");
            media = Matematica.Media(nota1, nota2);

            decimal nota3 = InputHandler.ReceberNota($"\nQual a terceira nota de prova?\nMédia atual: {media.ToString("f2")} pontos\nValor: ");
            media = Matematica.Media(nota1, nota2, nota3);

            decimal nota4 = InputHandler.ReceberNota($"\nQual a ultima nota de prova?\nMédia atual: {media.ToString("f2")} pontos\nValor: ");
            media = Matematica.Media(nota1, nota2, nota3, nota4);

            decimal notaMinimaNecessaria = 7.0M;
            if (media >= notaMinimaNecessaria)
            {
                System.Console.WriteLine($"\n\nParabéns, voce foi aprovado!\nMédia de {Math.Round(media, 2, MidpointRounding.ToPositiveInfinity)} pontos.");
                System.Environment.Exit(0);
            }

            decimal notaRecuperacao = InputHandler.ReceberNota($"\nAinda tem direito a recuperação!\nQual a nota de prova de recuperação? (utilize o ponto para dividir decimal)\nMédia atual: {media.ToString("f2")} pontos\nValor: ");
            media = Matematica.Media(media, notaRecuperacao);

            if (media >= notaMinimaNecessaria)
            {
                System.Console.WriteLine($"\n\nParabéns, voce foi aprovado na recuperação!\nMédia de {Math.Round(media, 2, MidpointRounding.ToPositiveInfinity)} pontos.");
            }
            else
            {
                System.Console.WriteLine($"\n\nInfelizmente, dessa vez voce não foi aprovado...\nMédia de {media.ToString("f2")} pontos.");
            }
        }
    }
    public class Matematica
    {
        public static decimal Media(params decimal[] values)
        {
            decimal soma = default(decimal);
            for (int i = 0; i < values.Length; i++)
            {
                soma += values[i];
            }
            return soma / values.Length;
        }
    }
    public class InputHandler
    {
        public static decimal ReceberNota(string textoApresentacao)
        {
            decimal nota = default(decimal);
            bool converted = default(bool);
            bool validValue = default(bool);

            System.Console.Write(textoApresentacao);

            converted = decimal.TryParse(Console.ReadLine(), out nota);
            validValue = (nota >= 0);

            while ((!converted) || (!validValue))
            {
                System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Exemplo: 9.7)\nValor: ");
                converted = decimal.TryParse(Console.ReadLine(), out nota);
                validValue = (nota >= 0);
            }
            return nota;
        }
    }
}

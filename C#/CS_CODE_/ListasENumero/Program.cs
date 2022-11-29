using System;
using System.Globalization;
using System.Collections.Generic;

namespace ListasENumeros
{
    public class ListasENumero
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            List<decimal> conjunto = new List<decimal>();
            decimal valor = InputHandler.ReceberValor("Bem vindo ao memorizador de numeros!\nDigite e confirme caso deseje inserir um valor, caso contrário digite -1\nValor(Use o ponto como divisor de decimal, exemplo: 1.89): ");
            decimal menor = valor;
            decimal maior = valor;
            while (valor >= 0)
            {
                if (valor>maior){
                    maior = valor;
                }
                if(valor < menor){
                    menor = valor;
                }
                conjunto.Add(valor);
                valor = InputHandler.ReceberValor($"\n\nValor ({valor}) Inserido!\nDigite e confirme caso deseje inserir um valor, caso contrário digite -1.\nValor(Use o ponto como divisor de decimal, exemplo: 1.89): ");
            }
            System.Console.WriteLine($"\n\nO menor valor inserido foi o {menor}\nO maior valor inserido foi o {maior}");
            
        }
    }
    public class InputHandler
    {
        public static decimal ReceberValor(string textoApresentacao)
        {
            decimal valor = default(decimal);
            bool converted = default(bool);

            System.Console.Write(textoApresentacao);
            converted = decimal.TryParse(Console.ReadLine(), out valor);

            while (!converted)
            {
                System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Utilize o ponto para divisor decimal.Exemplo: 1.89)\nValor: ");
                converted = decimal.TryParse(Console.ReadLine(), out valor);
            }
            return valor;
        }
    }
}

using System;
using System.Globalization;

namespace InputReceiver
{
    public class InputReceiverInt
    {
        public static void Main(string[] args)
        {

            int a = InputHandler.ReceberValor("Por favor, digite o primeiro valor: ");
            int b = InputHandler.ReceberValor("Por favor, digite o segundo valor: ");
            int c = InputHandler.ReceberValor("Por favor, digite o terceiro valor: ");
            int maior = a;
            int menor = a;
            if (maior<b){
                maior=b;
            }
            if (maior<c){
                maior=c;
            }
            if (menor>b){
                menor=b;
            }
            if (menor>c){
                menor=c;
            }
            
            decimal menorVezesMaior = (decimal)menor*maior;
            decimal maiorDivMenor = (decimal)maior/menor;            

            System.Console.WriteLine($"\n\nMenor multiplicado pelo Maior: {menorVezesMaior.ToString("f2")}\nMaior dividido pelo Menor: {maiorDivMenor.ToString("f2")}");
        }
    }
    public class InputHandler
    {
        public static int ReceberValor(string textoApresentacao)
        {
            int valor = default(int);
            bool converted = default(bool);
            bool validValue = default(bool);

            System.Console.Write(textoApresentacao);

            converted = int.TryParse(Console.ReadLine(), out valor);
            validValue = (valor > 0);

            while ((!converted) || (!validValue))
            {
                System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Exemplo: 1)\nValor: ");
                converted = int.TryParse(Console.ReadLine(), out valor);
                validValue = (valor > 0);
            }
            return valor;
        }
    }
}

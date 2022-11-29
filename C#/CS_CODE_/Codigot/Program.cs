using System;
using System.Globalization;

namespace Codigo{
    class Codigot{
        public static void Main(string[] args){
            int CODIGO = InputHandler.ReceberInt("Por favor, escreva um inteiro(Exemplo: 1): ");

            string mensagem = CODIGO switch{
                int cod when cod is 1 => "um",
                int cod when cod is 2 => "dois",
                int cod when cod is 3 => "tres",
                _ => "Código inválido"
            };
            System.Console.WriteLine(mensagem);

        }
    }
    public class InputHandler
    {
        public static int ReceberInt(string textoApresentacao)
        {
            int valor = default(int);
            bool converted = default(bool);

            System.Console.Write(textoApresentacao);
            converted = int.TryParse(Console.ReadLine(), out valor);

            if (!converted){
                return -1;
            }
            return valor;
        }
    }
}
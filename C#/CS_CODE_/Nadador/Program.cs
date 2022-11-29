using System;
using System.Globalization;
using System.Collections.Generic;

namespace Natacao
{
    public class Nadador
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            DateTime nascimento = new DateTime(1999,02,01);
            nascimento = InputHandler.DateReceiver("Por favor, digite a data de seu nascimento(Formato Dia/Mes/Ano com as barras): ");
            DateTime agora = DateTime.Now;

            TimeSpan diferenca = agora.Subtract(nascimento);
            int anos = Convert.ToInt32(Math.Floor(diferenca.TotalDays/365));
            string resultado = anos switch{
                >=5 and <=7 => "Infantil A",
                >=8 and <=11 => "Infantil B",
                >=12 and <=13 => "Juvenil A",
                >=14 and <=17 => "Juvenil B",
                >=18 => "Adulto",
                _ => "Não Apto"
            };
            System.Console.WriteLine($"\n\nPessoa participa do grupo natação {resultado}\n\n");

        }
    }
    public class InputHandler
    {
        public static DateTime DateReceiver(string textoApresentacao)
        {
            DateTime data = new DateTime(1999,02,01);
            bool converted = default(bool);

            System.Console.Write(textoApresentacao);
            converted = DateTime.TryParse(Console.ReadLine(), out data);

            while (!converted)
            {
                System.Console.Write("Desculpe, não compreendemos a data.\nPoderia digitar novamente?(Utilize data no formato Brasileiro com as barras: dia/Mes/ano)\nData: ");
                converted = DateTime.TryParse(Console.ReadLine(), out data);
            }
            return data;
        }

    }
}

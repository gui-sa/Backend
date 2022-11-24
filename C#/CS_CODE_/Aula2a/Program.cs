using System;

namespace Aula2a{
    class Aula2a{
        static void Main(string[] args){
            DateTime dateHoje = new DateTime(2022,11,23,19,11,00); //ano,mes,dia,hora,minuto,segundos 
            System.Console.WriteLine(dateHoje);
            DateTime dataAgora = DateTime.Now; //ja retorna novo agora, com a data do sistema
            System.Console.WriteLine(dataAgora);
            System.Console.WriteLine(dataAgora.Year);
            dateHoje = dateHoje.AddDays(2); // Como String é imutavel ele retorna a nova string
            System.Console.WriteLine(dateHoje);
            dateHoje = dateHoje.AddDays(-1);// Como String é imutavel ele retorna a nova string
            System.Console.WriteLine(dateHoje);
            //System.Console.Write("Digite seu nome: ");
            //string nome = Console.ReadLine();
            //System.Console.WriteLine(nome);
        }
    }
}
 
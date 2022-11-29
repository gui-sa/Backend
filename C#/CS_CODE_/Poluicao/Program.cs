using System;
using System.Globalization;
using System.Collections.Generic;

namespace SecretariaMeioAmbiente
{
    public class Poluicao
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            System.Console.WriteLine("Bem vindo ao programa de controle da Secretaria do meio Ambiente!!\n");
            string sair = " ";
            do{
                int grupo = InputHandler.Grupo($"\nQual o seu grupo de atuação?\nDigite 1 referente ao Grupo 1\nDigite 2 referente ao Grupo 2\nDigite 3 referente ao Grupo 3\nGrupo participante: ");
                
                decimal emissao = InputHandler.ReceberValorDecimal("Qual a emissão da indústria?\nValor(Use o ponto como divisor decimal, exemplo: 1.5): ");
                System.Console.WriteLine($"Valor digitado: {emissao}\n");

                if (emissao>=0.5M){
                    System.Console.WriteLine("Vossa empresa esta sendo entimada e precisa paralisar as atividades!\n\n");
                }else if((emissao>=0.4M)&&((grupo==1)||(grupo==2))){
                    System.Console.WriteLine("Vossa empresa esta sendo entimada e precisa paralisar as atividades!\n\n");
                }else if((emissao>=0.3M)&&(grupo==1)){
                    System.Console.WriteLine("Vossa empresa esta sendo entimada e precisa paralisar as atividades!\n\n");
                }else{
                    System.Console.WriteLine("Sua empresa pode continuar as atividades normalmente.\n\n");
                }


                System.Console.WriteLine("Deseja encerrar o programa?");
                string? option = Console.ReadLine();
                sair = (option??"N");
                sair = sair.ToUpper();
            }while(sair!="S");
            

        }
    }
    public class InputHandler
    {
        public static decimal ReceberValorDecimal(string textoApresentacao)
        {
            decimal valor = default(decimal);
            bool converted = default(bool);

            System.Console.Write(textoApresentacao);
            converted = decimal.TryParse(Console.ReadLine(), out valor);
            bool validValue = (valor>=0);

            while ((!converted)||(!validValue))
            {
                System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Utilize o ponto para divisor decimal.Exemplo: 1.89)\nValor: ");
                converted = decimal.TryParse(Console.ReadLine(), out valor);
                validValue = (valor>=0);

            }
            return valor;
        }
        public static int Grupo(string textoApresentacao)
        {
            int valor = default(int);
            bool converted = default(bool);

            System.Console.Write(textoApresentacao);
            converted = int.TryParse(Console.ReadLine(), out valor);
            bool validValue = ((valor>=1)&&(valor<=3));

            while ((!converted)||(!validValue))
            {
                System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?\nGrupo: ");
                converted = int.TryParse(Console.ReadLine(), out valor);
                validValue = ((valor>=1)&&(valor<=3));
            }
            return valor;
        }
    }
}

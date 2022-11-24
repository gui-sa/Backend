using System;
using System.Globalization;

namespace Classe
{
    public class ClassDiary{
        public static void Main(string[] args){
            float nota1 = default(float);
            float nota2 = default(float);
            float nota3 = default(float);
            float nota4 = default(float);
            float media = default(float);
            float notaSub = default(float);

            System.Console.WriteLine("Bem vindo ao diario de classe!");
            nota1 = ReceberNota("Qual a primeira nota de prova (entre 0 e 10)?");
            nota2 = ReceberNota("Qual a segunda nota de prova (entre 0 e 10)?");
            nota3 = ReceberNota("Qual a terceira nota de prova (entre 0 e 10)?");
            nota4 = ReceberNota("Qual a ultima nota de prova (entre 0 e 10)?");

            System.Console.WriteLine(Media(nota1,nota2,nota3,nota4));
        }
        public static float ReceberNota(string textoApresentacao){
                float nota = default(float);
                bool converted = default(bool);
                bool validValue = default(bool);

                System.Console.WriteLine(textoApresentacao);
                
                converted = float.TryParse(Console.ReadLine(), out nota);
                validValue=((nota>=0)&&(nota<=10));

                while ((!converted)||(!validValue)){
                    System.Console.WriteLine("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Exemplo: 9.7)");
                    converted = float.TryParse(Console.ReadLine(), out nota);
                    validValue=((nota>=0)&&(nota<=10));
                }
                return nota;
        }
        public static float Media(params float[] values){
            float soma = default(float);
            for (int i=0;i<values.Length;i++){
                soma += values[i];
            }
            return soma/values.Length;
        }
    }
}

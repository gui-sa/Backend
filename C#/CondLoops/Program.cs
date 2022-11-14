using System;
using System.Globalization;

namespace ConditionalsAndLoops{
    class CondLoops{
        static void Main(String[] args){
            //System.Console.Write("What time is it?: ");
            //double x = double.Parse(Console.ReadLine());
            //if (x < 12 ){
            //    System.Console.WriteLine("Bom dia!");
            //}else if (x<18){ //If it came to here, it already means it is larger then 12
            //    System.Console.WriteLine("Boa tarde!");
            //}else{
            //    System.Console.WriteLine("Boa noite!...");
            //}

            //while eh padrao ---------------------------------------------------------
            Console.Write("Digite um numero: ");
            double x = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            while (x>=0){
                double raiz = Math.Sqrt(x);
                System.Console.WriteLine($"A raiz de {x} eh : {raiz}"); 
                System.Console.Write("Digite outro numero valido para continuar: ");
                x = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            }
            System.Console.WriteLine("Obrigado por utilizar o nosso encontrador de raizes... Ate mais.");
            
            
            //FOR padraozera tambem----------------------------------------------------------------------

            //Geralmente quando voce conhece o numero de repeticoes... ou, que dependem de uma contagem.
            int limiar = 10;
            for(int i=0; i<limiar ; i++){
                System.Console.WriteLine(i); //Vai contar 10 vezes iniciando do zero.
                
            }


        }
    }
}
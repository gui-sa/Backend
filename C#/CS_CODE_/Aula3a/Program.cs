using System;

namespace Aula3a{
    class Aula3a{
        static void Main(string[] args){
            string testeFormat = string.Format("Formatando uma frase {0} e {1} e {1} e {0}",10,12); // O numero em si nao eh vinculado a ordem com que voce apresenta a ordem, porem, quando o numero se vicula, ele consegue ser repetido;
            System.Console.WriteLine(testeFormat);
            string testeConcatenar = "Estou testando Concatenar: " + 10 + " idade";
            System.Console.WriteLine(testeConcatenar);
            string testeInterpolar = $"Estou interpolando! Tenho {22} anos!!!";
            System.Console.WriteLine(testeInterpolar);
            System.Console.WriteLine($"{{ \""); //Para printar so a chave e so as aspas...
            //Interpolar é o mais utilizado.
            




        }
    }
}
 
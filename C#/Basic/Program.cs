using System;

namespace Basics
{
    class Basic
    {
        static void Main(string[] args)
        {

            //SByte x = 100; //1 byte len signed for numbers
            //byte n1 =  126; //1 byte unsigned
            //Console.WriteLine(x);
            //Console.WriteLine(n1);
            //
            //int n2 = 1000; //4 bytes signed
            //Console.WriteLine(n2);

            //
            //long n3 = 100000L; //8 bytes signed... o L no final eh para indicar que estamos trabalhando com numeros longos.
            //Console.WriteLine(n3);
            //
            //
            //bool completo = false;
            //Console.WriteLine(completo);
            //
            //char genero = 'f'; //entre aspas ou unicode table
            //Console.WriteLine(genero);
            //
            //char genero2 = '\u0041'; //'\u para mostrar que esta em unicode'
            //Console.WriteLine(genero2);
            //
            //genero2 = '\u2661';
            //Console.WriteLine(genero2);
            //
            //float n5 = 4.5f; //tem que finalizar com f para garantir que sera em float de 4 bytes
            //double n6 = 6.7;
            //Console.WriteLine(n5);
            //Console.WriteLine(n6);
            //
            //
            //string maria = "Mariazinha" ; //Obrigatoriamente com aspas duplas
            //Console.WriteLine(maria);
            //
            //maria = "Mariazinha Fedidona" ; //Obrigatoriamente com aspas duplas
            //Console.WriteLine(maria);
            //
            //object obj1 = "Alex browns";
            //Console.WriteLine(obj1); //aceita a parada toda... e muda de tipos livremente.
            //obj1 = "Testudo";
            //Console.WriteLine(obj1);
            //obj1 = 56;
            //Console.WriteLine(obj1);
            //object obj2 = 5.6f;
            //Console.WriteLine(obj2); //aceita a parada toda... e muda de tipos livremente.

            //--------------------------------------------------------

            //int idade = 32;
            //double saldo = 10.35784;
            //string nome = "Maria";
            //
            //System.Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2} reais", nome, idade, saldo.ToString("f2")); //Placeholder
            //System.Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2:f2} reais", nome, idade, saldo);
            //
            //System.Console.WriteLine($"{nome} tem {idade} anos e tem saldo igual a {saldo:f2} reais"); //Interpolacao
            //
            //System.Console.WriteLine(nome + " tem " + idade + " anos e tem saldo igual a " + saldo.ToString("f2") + " reais"); //Concatencao


            // ----------------------------------------------------------------------------------------------

            //int a = 10;
            //a += 1;
            //a -= 1;
            //a *=10;
            //a /= 10;
            //System.Console.WriteLine(a);
            //a %= 3;
            //System.Console.WriteLine(a);
            //string s = "abc";
            //s += "def";
            //System.Console.WriteLine(s);
            //a++;
            //System.Console.WriteLine(a);
            //a--;
            //System.Console.WriteLine(a);

            // -------------------------------------------------------------------------
            //int a = 10;
            //int b = a++;
            //System.Console.WriteLine(a);
            //System.Console.WriteLine(b);
            //a = 10;
            //b = ++a;
            //System.Console.WriteLine(a);
            //System.Console.WriteLine(b);
            // ---------------------------------------------------------------------------
            //float x = 4.5f;
            //double y = x; //Conversao implicita de tipos... float consegue entrar em double perfeitamente.
            //System.Console.WriteLine(x);
            //System.Console.WriteLine(y);
            // Se voce tentasse o contrario, daria erro... Mas, voce pode forcar a conversao usando CASTING
            //double a = 5.1;
            //float b = (float)a;
            //System.Console.WriteLine(a);
            //System.Console.WriteLine(b);
            // Nao posso converter o double para int
            //a = 5.9;
            //int c = (int)a;
            //System.Console.WriteLine(a);
            //System.Console.WriteLine(c);
            // float to int same len.. Still same problem.. you will have to force it.
            //c = (int)x;
            //System.Console.WriteLine(c);

            //And what if you try to create a double using two integers
            //c = 3;
            //int d = 5;
            //double res = c / d;
            //System.Console.WriteLine(res); //It will give you an integer forced result...
            //System.Console.WriteLine(c);
            //System.Console.WriteLine(d);
            //res = (double)c / (double)d; //You ned to CAST all the integers...
            //System.Console.WriteLine(res);

            //---------------------------------------------------------------------------
            // * / % tem mais prioridade... Para quebrar, use parenteses. Da esquerda para direita
            int n1 = 3+4*2;
            System.Console.WriteLine(n1);
            int n2 = (3+4)*2;
            System.Console.WriteLine(n2);
            int n3 = 17%3;
            System.Console.WriteLine(n3);
            double n4 = 10.0/8.0; //lembre se de fazer um casting ou colocar uma virgula
            System.Console.WriteLine(n4);

            double a = 1.0, b = -3.0, c = -4;
            double delta = Math.Pow(b,2.0) -4.0*a*c ;
            double res1 = (-b+Math.Sqrt(delta))/(2.0*a);
            double res2 = (-b-Math.Sqrt(delta))/(2.0*a);
            System.Console.WriteLine(res1);
            System.Console.WriteLine(res2);
        }
    }

}
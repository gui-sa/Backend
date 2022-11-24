using System;
using System.Globalization;

namespace Aula2c{
    public class Aula2c{
        static void Main(string[] args){
            // Cast Implicito
            //System.Console.Write("Digite o numero: ");
            //decimal teste = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //System.Console.WriteLine(teste);
//
            ////int numero = 12.6; //ele vai dar erro pq ele nao faz implecitamente sem perder dados.
            //int numero = (int)12.6; //para forcar convercao, voce usa o cast;
            //System.Console.WriteLine(numero);
            
            decimal numeroDecimal = 100000.123123M;
            int numeroInt = Convert.ToInt32(numeroDecimal);
            System.Console.WriteLine(numeroInt);
            double numeroDouble = default(double);


            CultureInfo culture = CultureInfo.CurrentCulture;

            numeroDouble = Convert.ToDouble("15,989", culture);
            System.Console.WriteLine(numeroDouble);

        }
    }
}
 
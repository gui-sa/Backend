using System;
using System.Globalization;

namespace UML{

    class ReceivingData{

        public static decimal ReceivingDecimal(string presentationText){
            System.Console.Write(presentationText);
            decimal value = default(decimal);
            bool converted = decimal.TryParse(Console.ReadLine(),out value);
            while(!converted){
                System.Console.Write("Não foi possível compreender o que foi digitado...\nPoderia digitar novamente?\nValor: ");
                converted = decimal.TryParse(Console.ReadLine(),out value);
            }
            return value;
            
        }

    }
}
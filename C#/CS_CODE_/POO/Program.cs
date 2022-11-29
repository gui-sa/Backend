using System;
using System.Globalization;
using System.Collections.Generic;

namespace POOExercise
{
    public class POO
    {
        public static void Main(string[] args)
        {

        }
    }
    public class Correntista{
        public decimal saldo { get; set; }
        public string cpf { get; set; }
        public List<despesa> despesas{ get; set; }

        public Correntista(string cpf){
            List<despesa> this.despesas = new List<despesa>();
            this.cpf = cpf;
        }

    }
    public class despesa{
        public string descricao { get; set; }
        public decimal valor { get; set; }
    }
}

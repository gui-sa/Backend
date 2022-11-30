using System;
using System.Collections.Generic;
using System.Linq;


namespace Testezinhos
{
    class ListasTeste
    {
        public static void Main(string[] args)
        {

            List<Funcionarios> colaboradores = new List<Funcionarios>();
            colaboradores.Add(new Funcionarios("Maicon", 1000.00M));
            colaboradores.Add(new Funcionarios("Joao", 1200.00M));
            colaboradores.Add(new Funcionarios("Pedro", 1030.00M));
            colaboradores.Add(new Funcionarios("Jose", 2000.00M));
            colaboradores.Add(new Gerente(1.3M,"Seu Paulo", 2000.00M));

            foreach (Funcionarios func in colaboradores)
            {
                System.Console.Write($"{func.GetType()} ");
                System.Console.WriteLine(func.ToString());
                
            }




            DateTime agora = DateTime.Now;

            Funcionarios.AdicionarDependente(colaboradores, "Maicon", new Familia("Maicon Jr", 2020, 01, 02));
            Funcionarios.AdicionarDependente(colaboradores, "Maicon", new Familia("Maicon Jr mais velho", 1999, 12, 04));
            Funcionarios.AdicionarDependente(colaboradores, "Mon", new Familia("asdasd", 1929, 12, 04));
            Funcionarios.AdicionarDependente(colaboradores, "Jose", new Familia("Assad", 2000, 11, 04));
            Funcionarios.AdicionarDependente(colaboradores, "Seu Paulo", new Familia("Primo", 2001, 11, 04));

            foreach (Familia fam in colaboradores[0].Dependentes)
            {
                System.Console.Write(fam.Nome + " Mes:");
                System.Console.WriteLine(fam.nascimento.Month);
            }
            System.Console.WriteLine();
            foreach (var col in colaboradores.Where(c => c.Dependentes.Any()).ToList())
            {
                foreach (var fam in col.Dependentes.OrderBy(f=>f.nascimento).ToList())
                {
                    System.Console.WriteLine(fam);
                }
            }

        }
    }
    class Funcionarios
    {
        public int Idade { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public List<Familia> Dependentes { get; set; }

        public Funcionarios(string nome, decimal salario)
        {
            this.Dependentes = new List<Familia>();
            this.Nome = nome;
            this.Salario = salario;
        }
        public Funcionarios(string nome, decimal salario, int idade)
        {
            this.Dependentes = new List<Familia>();
            this.Nome = nome;
            this.Salario = salario;
            this.Idade = idade;
        }
        public override string ToString()
        {
            return $"Nome: {this.Nome}, Idade: {this.Idade}, Salario {this.Salario}";
        }
        public static bool AdicionarDependente(List<Funcionarios> listaFuncionarios, string nomeFuncionario, Familia pessoa)
        {
            Funcionarios funcionario = listaFuncionarios.FirstOrDefault(f => f.Nome == nomeFuncionario);
            if (funcionario == null)
            {
                return false;
            }
            funcionario.Dependentes.Add(pessoa);
            return true;
        }

    }
    class Gerente : Funcionarios
    {

        public decimal bonus { get; set; }

        public Gerente(decimal bonus, string nome, decimal salario) : base(nome, salario)
        {
            this.bonus = bonus;
        }
    }
    class Familia
    {
        public string Nome { get; set; }
        public DateTime nascimento { get; set; }
        public Familia(string nome, int Ano, int Mes, int Dia)
        {
            this.Nome = nome;
            this.nascimento = new DateTime(Ano, Mes, Dia);
        }

        public override string ToString()
        {
            return $"{this.Nome} - {this.nascimento}";
        }
    }
}
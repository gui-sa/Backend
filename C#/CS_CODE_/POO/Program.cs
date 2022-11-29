using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace POOExercise
{
    public class POO
    {
        public static void Main(string[] args)
        {
            Correntista pessoa1 = new Correntista("999.999.999-99");
            Correntista pessoa2 = new Correntista("999.999.999-98");
            despesa energia = new despesa(130.00M,"Energia da Concessionaria");
            despesa esgoto = new despesa(80.00M,"Conta de agua");
            despesa club = new despesa(250.00M,"Laser");
            despesa bug = new despesa(-3000.0M,"Oi eu sou um bug");


            System.Console.WriteLine(pessoa1.buscaValorSaldo());
            bool sucess = pessoa1.adicionarSaldo(1000.00M);
            sucess = pessoa1.pagarConta(1000.00M);
            sucess = pessoa1.pagarConta(10.00M);

            sucess = pessoa1.inserirDespesa(energia);
            sucess = pessoa1.inserirDespesa(esgoto);
            sucess = pessoa1.inserirDespesa(club);
            sucess = pessoa1.inserirDespesa(bug);

            System.Console.WriteLine(pessoa1.somarDespesas());
        }
    }
    public class Correntista{
        private decimal saldo { get; set; }
        private string cpf { get; set; }
        private List<despesa> despesas { get; set; }

        public Correntista(string cpf){
            this.despesas = new List<despesa>();
            this.cpf = cpf;
        }
        public decimal buscaValorSaldo(){
            return this.saldo;
        }
        public bool adicionarSaldo(decimal saldoAdd){
            if (saldoAdd<=0){
                System.Console.WriteLine("Não é possível adicionar valores negativos e nulos");
                return false;
            }
            
            System.Console.WriteLine($"Valor {saldoAdd.ToString("c")} adicionado com sucesso!");
            this.saldo += saldoAdd;
            return true;
        }
        public bool pagarConta(decimal valorConta){
            if (valorConta<=0){
                System.Console.WriteLine("Não é possível pagar contas com valores negativos e nulos");
                return false;
            }
            decimal saldoAtual = buscaValorSaldo();
            if(saldoAtual>=valorConta){
                System.Console.WriteLine($"Conta no valor {valorConta.ToString("c")} paga com sucesso!");
                this.saldo -= valorConta;
                return true;
            }
            System.Console.WriteLine($"Saldo insuficiente. Não foi possível pagar a conta de valor {valorConta}");
            return false;
        }
        public static List<Correntista> encontraCorretista(){
            











            
            
            return null;
        }
        public bool inserirDespesa(despesa desp){
            if(desp.Valor>0){
                this.despesas.Add(desp);
                return true;
            }
            return false;
        }

        public decimal somarDespesas(){
            return this.despesas.Select(x=>x.Valor).Sum();
        }
    }
    public class despesa{
        public string descricao { get; set; }
        private decimal valor;
        public decimal Valor { 
            get{return this.valor;}
            set{
                if (value<0){
                    this.valor = 0;
                    System.Console.WriteLine("Atenção ao criar despesa! Nao é possível adicionar despesas com valores negativos");
                }else{
                    this.valor = value;
                }
            }
        }
        public despesa(decimal valor){
            this.Valor = valor;
            this.descricao = "Despesa default";
        }
        public despesa(decimal valor, string descricao){
            this.Valor = valor;
            this.descricao = descricao;
        }
    }
}

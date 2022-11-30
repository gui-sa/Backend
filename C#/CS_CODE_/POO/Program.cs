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
            
            List<Correntista> clientes = new List<Correntista>();
            clientes.Add(new Correntista("99999999999"));
            clientes.Add(new Correntista("99999999998"));
            clientes.Add(new Correntista("99999999997"));
            despesa energia = new despesa(130.00M,"Energia da Concessionaria");
            despesa esgoto = new despesa(80.00M,"Conta de agua");
            despesa club = new despesa(250.00M,"Laser");
            despesa bug = new despesa(-3000.0M,"Oi eu sou um bug");


            System.Console.WriteLine(clientes[0].buscaValorSaldo());
            bool sucess = clientes[0].adicionarSaldo(1000.00M);
            sucess = clientes[0].pagarConta(1000.00M);
            sucess = clientes[0].pagarConta(10.00M);

            sucess = clientes[0].inserirDespesa(energia);
            sucess = clientes[0].inserirDespesa(esgoto);
            sucess = clientes[0].inserirDespesa(club);
            sucess = clientes[0].inserirDespesa(bug);

            System.Console.WriteLine(Correntista.encontraCorretista(clientes,"99999999999").somarDespesas());            
        }
    }
    public class Correntista{
        private decimal saldo { get; set; }
        private string cpf;
        private string Cpf { 
            get{return this.cpf;} 
            set{
                this.cpf = value;
            } 
        }
        private List<despesa> despesas { get; set; }

        public Correntista(string cpf){
            //checar se cpf esta no formato adequado e seguindo regras de negocio.. Se nao, nao construir.
            this.despesas = new List<despesa>();
            this.Cpf = cpf;
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
            System.Console.WriteLine($"Saldo insuficiente. Não foi possível pagar a conta no valor de {valorConta.ToString("c")}");
            return false;
        }
        public static Correntista encontraCorretista(List<Correntista> correntistas,string cpf){
            Correntista correntista = correntistas.FirstOrDefault(cor => cor.Cpf==cpf);
            return correntista;         
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

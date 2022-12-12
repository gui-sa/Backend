using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace CodingTank
{
    class Avaliacao
    {
        public static void Main(string[] args)
        {
            Voo av1 = new Voo("GOL", 10, new DateTime(2022,12,1));
            av1.OcuparAssento(1);
            av1.OcuparAssento(3);
            System.Console.WriteLine(av1.AssentoDisponivel(5));
            av1.ExibirInformacoesVoo();
            av1.QuantidadeVagasDisponivel();
            System.Console.WriteLine(av1.ProximoLivre());
        }
    }
    class Voo{
        private string aeronave { get; set; }
        private long numeroDoVoo { get; }
        private DateTime data { get; set; }
        private List<int> poltronasOcupadas { get; set; }

        public Voo(string aeronave, long numeroDoVoo, DateTime data){
            this.poltronasOcupadas = new List<int>();
            this.aeronave = aeronave;
            this.numeroDoVoo = numeroDoVoo; 
            this.data = data;
        }

        public bool AssentoDisponivel(int assento){
            bool possui = poltronasOcupadas.Contains(assento);
            return !possui;
        }
        public bool OcuparAssento(int assento){

            if((assento>99)||(assento<0)||(!AssentoDisponivel(assento))){
                return false;
            }
            poltronasOcupadas.Add(assento);
            return true;
        }
        public int QuantidadeVagasDisponivel(){
            var numeroOcupadas = poltronasOcupadas.Count;
            return (100-numeroOcupadas);
        }
        public void ExibirInformacoesVoo(){
            System.Console.WriteLine($"Aeronave {this.aeronave} registrada sob voo de numero {this.numeroDoVoo} para o dia e hora {this.data}");
        }
        public int ProximoLivre(){
            int poltronaLivre = default(int);
            for(int i = 0;i<100;i++){
                if(AssentoDisponivel(i)){
                    poltronaLivre = i;
                    break;
                }
            }
            return poltronaLivre;
        }

    }
}
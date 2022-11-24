using System;
using System.Globalization;

namespace ComercianteVendas
{
    public class Comerciante{
        public static void Main(string[] args){
        
            decimal custoProduto = ReceberPreco("\nQual o preço de compra do produto?(Utilize ponto para separar decimal)\nPreço (R$): ");
            decimal precoVenda = default(decimal);
            if (custoProduto<20.0M){
                precoVenda = custoProduto*1.45M;
                System.Console.WriteLine($"Venda-o por R$: {Math.Round(precoVenda,2,MidpointRounding.ToPositiveInfinity)}\n");
            }else{
                precoVenda = custoProduto*1.30M;
                System.Console.WriteLine($"Venda-o por R$: {Math.Round(precoVenda,2,MidpointRounding.ToPositiveInfinity)}\n");
            }
        }
        public static decimal ReceberPreco(string textoApresentacao){
                decimal preco = default(decimal);
                bool converted = default(bool);
                bool validValue = default(bool);

                System.Console.Write(textoApresentacao);
                
                converted = decimal.TryParse(Console.ReadLine(), out preco);
                validValue=(preco>=0);

                while ((!converted)||(!validValue)){
                    System.Console.Write("Desculpe, não compreendemos o valor.\nPoderia digitar novamente?(Exemplo: 9.7)\nPreço: ");
                    converted = decimal.TryParse(Console.ReadLine(), out preco);
                    validValue=(preco>=0);
                }
                return preco;
        }
    }
}

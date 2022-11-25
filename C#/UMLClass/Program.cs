using System;
using System.Globalization;

namespace UML{
    internal class UMLClass{
        static void Main(string[] args){
            Produto prod1 = new Produto();

            System.Console.Write("Entre os dados do Produto:\nNome: ");
            prod1.Nome = Console.ReadLine();
            prod1.Preco = ReceivingData.ReceivingDecimal("Preço: ");
            prod1.Quantidade = Convert.ToInt32(ReceivingData.ReceivingDecimal("Quantidade no estoque: "));
            System.Console.WriteLine($"Dados do produto {prod1.Nome}, $ {prod1.Preco.ToString("f2")}, {prod1.Quantidade} unidades,Total: $ {(decimal)prod1.Quantidade*prod1.Preco}\n");
            int quantityAdd = Convert.ToInt32(ReceivingData.ReceivingDecimal("Digite o numero de produtos a ser adicionado no estoque: "));
            prod1.Quantidade += Math.Abs(quantityAdd);
            System.Console.WriteLine($"Dados do produto {prod1.Nome}, $ {prod1.Preco.ToString("f2")}, {prod1.Quantidade} unidades,Total: $ {(decimal)prod1.Quantidade*prod1.Preco}\n");
            int quantityRemove = Convert.ToInt32(ReceivingData.ReceivingDecimal("Digite o numero de produtos a ser removido do estoque: "));
            prod1.Quantidade += -Math.Abs(quantityRemove);
            System.Console.WriteLine($"Dados do produto {prod1.Nome}, $ {prod1.Preco.ToString("f2")}, {prod1.Quantidade} unidades,Total: $ {(decimal)prod1.Quantidade*prod1.Preco}\n");
        }
    }
}
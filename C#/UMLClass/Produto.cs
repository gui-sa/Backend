using System;

namespace UML{
    public class Produto
    {
        private string nome = " ";
        public String Nome{
            get{return nome;}
            set{nome = value;}
        }
        private decimal preco;
        public decimal Preco{
            get{return preco;}
            set{preco = value;}
        }


        private int quantidade;
        public int Quantidade{
            get{return quantidade;}
            set{quantidade=value;}
        }

    }
}
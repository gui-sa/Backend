using System; // Isso eh a importacao do namespace System!

namespace Exercicio1b{ // If namespace is diferent... It is going to break!
    class Triangulo{ //tipo Triangulo <object>
        public double m1; //para que eu possa acessar diretamente, tem que ser publico.
        public double m2; //propriedade | atributo
        public double m3;
        public double AreaHeron(){// Ela nao precisa de nenhum parametro extra
            double p = (m1+m2+m3)/2.0;
            return Math.Sqrt(p*(p-m1)*(p-m2)*(p-m3));
        }
    
    }
}
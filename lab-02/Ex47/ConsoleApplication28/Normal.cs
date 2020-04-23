using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class Normal : Ingresso
    {
        public Normal(double valorIngresso) : base(valorIngresso)
        {
            ValorIngresso = valorIngresso;
        }
        public override string ToString() // retornar informações sobre contriuinte
        {
            return "R$" + ValorIngresso.ToString("F2");
        }
    }
}

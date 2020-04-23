using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class CamaroteSuperior : VIP
    {
        public CamaroteSuperior(double valorIngresso) : base(valorIngresso)
        {
            ValorIngresso = valorIngresso + (valorIngresso * 0.10);
        }

        public override string ToString() // retornar informações sobre contriuinte
        {
            return "R$"+ValorIngresso.ToString("F2");
        }
    }
}

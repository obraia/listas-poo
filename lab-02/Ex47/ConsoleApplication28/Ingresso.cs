using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class Ingresso
    {
        private double valorIngresso;

        public double ValorIngresso
        {
            get
            {
                return valorIngresso;
            }

            set
            {
                valorIngresso = value;
            }
        }

        public Ingresso(double valoringresso)
        {
            ValorIngresso = valorIngresso;
        }
        public virtual void ImprimeValor()
        {

        }
    }
}

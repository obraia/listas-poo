using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class PortasLogicas
    {

    }

    public class NOT
    {
        public bool Not(bool A)
        {
            return (!A);
        }
    }

    public class AND
    {
        public bool And(bool A, bool B)
        {
            return (A & B);
        }
    }


    public class OR
    {
        public bool Or(bool A, bool B)
        {
            return (A | B);
        }
    }

    public class XOR
    {
        public bool Xor(bool A, bool B)
        {
            AND and = new AND();
            NOT not = new NOT();
            OR or = new OR();

            bool A_or_B = or.Or(A, B);
            bool A_and_B_negado = not.Not(and.And(A, B));
            bool saida = and.And(A_or_B, A_and_B_negado);

            return saida;
        }
    }

    public class NAND
    {
        public bool Nand(bool A, bool B)
        {
            NOT not = new NOT();
            AND and = new AND();

            return not.Not(and.And(A, B));
        }
    }

    public class NOR
    {
        public bool Nor(bool A, bool B)
        {
            NOT not = new NOT();
            OR or = new OR();

            return not.Not(or.Or(A, B));
        }
    }

    public class XNOR
    {
        public bool Xnor(bool A, bool B)
        {
            NOT not = new NOT();
            XOR xor = new XOR();

            return not.Not(xor.Xor(A, B));
        }
    }
}

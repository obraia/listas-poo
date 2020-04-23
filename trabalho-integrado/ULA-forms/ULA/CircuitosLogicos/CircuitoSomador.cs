using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class CircuitoSomador
    {
        public bool Somador(bool A, bool B, bool vem1, ref bool vai1)
        {
            NOT not = new NOT();
            AND and = new AND();  
            OR or = new OR();
            XOR xor = new XOR();

            bool A_xor_B = xor.Xor(A, B); // (A XOR B)
            bool A_and_B = and.And(A, B); // (A AND B)
            bool Vem1_xor_A_xor_B = xor.Xor(A_xor_B, vem1); // ((Vem1 XOR A) XOR B)
            bool Vem1_and_A_xor_B = and.And(A_xor_B, vem1); // (Vem1 AND (A XOR B))
            bool Vem1_and_A_xor_B_or_A_and_B = or.Or(Vem1_and_A_xor_B, A_and_B); // ((Vem1 AND (A XOR B)) OR (A AND B))

            bool Saida = Vem1_xor_A_xor_B;  // ((Vem1 XOR A) XOR B)
            vai1 = Vem1_and_A_xor_B_or_A_and_B; // ((Vem1 AND (A XOR B)) OR (A AND B))

            return Saida;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class CircuitoSubtrator
    {
        public bool Subtrator(bool A, bool B, bool Bi, ref bool Bo)
        {
            // Bi = Borrow in - Bo Borrow out

            NOT not = new NOT();
            AND and = new AND();
            OR or = new OR();
            XOR xor = new XOR();

            bool A_xor_B = xor.Xor(A, B); // (A XOR B)
            bool A_xor_B_xor_Bi = xor.Xor(A_xor_B, Bi); // ((A XOR B) XOR Bi)     
            bool notA_and_B = and.And(not.Not(A), B); // (NOT(A) AND B) 
            bool notA_and_Bi = and.And(not.Not(A), Bi);  // (NOT(A) AND Bi) 
            bool B_and_Bi = and.And(B, Bi); // (B AND Bi)
            bool notA_and_B_or_notA_and_Bi = or.Or(notA_and_B, notA_and_Bi);  // ((NOT(A) AND Bi) OR (NOT(A) AND Bi)) 
            bool notA_and_B_or_notA_and_Bi_or_B_and_Bi = or.Or(notA_and_B_or_notA_and_Bi, B_and_Bi); // ((NOT(A) AND B) OR (NOT(A) AND Bi) OR (B AND Bi))

            bool Saida = A_xor_B_xor_Bi;  // ((A XOR B) XOR Bi)
            Bo = notA_and_B_or_notA_and_Bi_or_B_and_Bi;  // ((NOT(A) AND B) OR (NOT(A) AND Bi) OR (B AND Bi))

            return Saida;
        }

    }
}

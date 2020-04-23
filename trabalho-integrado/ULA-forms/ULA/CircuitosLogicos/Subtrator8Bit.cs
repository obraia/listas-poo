using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA.CircuitosLogicos
{
    class Subtrator8Bit
    {
        CircuitoSubtrator subtrator1Bit = new CircuitoSubtrator();

        public bool[] Subtrator(bool[] A, bool[] B)
        {
            bool[] resultado = new bool[8];
            bool[] registrador = new bool[8];
            bool BIn = false;

            resultado[07] = subtrator1Bit.Subtrator(A[07], B[07], BIn, ref BIn);
            resultado[06] = subtrator1Bit.Subtrator(A[06], B[06], BIn, ref BIn);
            resultado[05] = subtrator1Bit.Subtrator(A[05], B[05], BIn, ref BIn);
            resultado[04] = subtrator1Bit.Subtrator(A[04], B[04], BIn, ref BIn);
            resultado[03] = subtrator1Bit.Subtrator(A[03], B[03], BIn, ref BIn);
            resultado[02] = subtrator1Bit.Subtrator(A[02], B[02], BIn, ref BIn);
            resultado[01] = subtrator1Bit.Subtrator(A[01], B[01], BIn, ref BIn);
            resultado[00] = subtrator1Bit.Subtrator(A[00], B[00], BIn, ref BIn);

            return resultado;
        }
    }
}

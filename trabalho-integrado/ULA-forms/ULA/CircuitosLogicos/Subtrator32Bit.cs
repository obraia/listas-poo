using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class Subtrator32Bit
    {
        public bool[] Subtrator(bool[] A, bool[] B)
        {
            CircuitoSubtrator subtrator1Bit = new CircuitoSubtrator();

            bool[] resultado = new bool[25];
            bool[] registrador = new bool[24];
            bool BIn = false;

            resultado[24] = subtrator1Bit.Subtrator(A[23], B[23], false, ref BIn);
            resultado[23] = subtrator1Bit.Subtrator(A[22], B[22], BIn, ref BIn);
            resultado[22] = subtrator1Bit.Subtrator(A[21], B[21], BIn, ref BIn);
            resultado[21] = subtrator1Bit.Subtrator(A[20], B[20], BIn, ref BIn);
            resultado[20] = subtrator1Bit.Subtrator(A[19], B[19], BIn, ref BIn);
            resultado[19] = subtrator1Bit.Subtrator(A[18], B[18], BIn, ref BIn);
            resultado[18] = subtrator1Bit.Subtrator(A[17], B[17], BIn, ref BIn);
            resultado[17] = subtrator1Bit.Subtrator(A[16], B[16], BIn, ref BIn);
            resultado[16] = subtrator1Bit.Subtrator(A[15], B[15], BIn, ref BIn);
            resultado[15] = subtrator1Bit.Subtrator(A[14], B[14], BIn, ref BIn);
            resultado[14] = subtrator1Bit.Subtrator(A[13], B[13], BIn, ref BIn);
            resultado[13] = subtrator1Bit.Subtrator(A[12], B[12], BIn, ref BIn);
            resultado[12] = subtrator1Bit.Subtrator(A[11], B[11], BIn, ref BIn);
            resultado[11] = subtrator1Bit.Subtrator(A[10], B[10], BIn, ref BIn);
            resultado[10] = subtrator1Bit.Subtrator(A[09], B[09], BIn, ref BIn);
            resultado[09] = subtrator1Bit.Subtrator(A[08], B[08], BIn, ref BIn);
            resultado[08] = subtrator1Bit.Subtrator(A[07], B[07], BIn, ref BIn);
            resultado[07] = subtrator1Bit.Subtrator(A[06], B[06], BIn, ref BIn);
            resultado[06] = subtrator1Bit.Subtrator(A[05], B[05], BIn, ref BIn);
            resultado[05] = subtrator1Bit.Subtrator(A[04], B[04], BIn, ref BIn);
            resultado[04] = subtrator1Bit.Subtrator(A[03], B[03], BIn, ref BIn);
            resultado[03] = subtrator1Bit.Subtrator(A[02], B[02], BIn, ref BIn);
            resultado[02] = subtrator1Bit.Subtrator(A[01], B[01], BIn, ref BIn);
            resultado[01] = subtrator1Bit.Subtrator(A[00], B[00], BIn, ref BIn);

            // tratamento de overflow
            if (BIn == true)
            {
                resultado[00] = true;

                for (int i = 0; i < 24; i++)
                {
                    registrador[i] = resultado[i];
                }
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    registrador[i] = resultado[i + 1];
                }
            }

            return registrador;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class Somador32Bit
    {
        public bool[] Somador(bool[] A, bool[] B, ref bool overflow, bool soma)
        {
            CircuitoSomador somador1Bit = new CircuitoSomador();

            bool[] resultado = new bool[25];
            bool[] registrador = new bool[24];
            bool vai1 = false;

            resultado[24] = somador1Bit.Somador(A[23], B[23], false, ref vai1);
            resultado[23] = somador1Bit.Somador(A[22], B[22], vai1, ref vai1);
            resultado[22] = somador1Bit.Somador(A[21], B[21], vai1, ref vai1);
            resultado[21] = somador1Bit.Somador(A[20], B[20], vai1, ref vai1);
            resultado[20] = somador1Bit.Somador(A[19], B[19], vai1, ref vai1);
            resultado[19] = somador1Bit.Somador(A[18], B[18], vai1, ref vai1);
            resultado[18] = somador1Bit.Somador(A[17], B[17], vai1, ref vai1);
            resultado[17] = somador1Bit.Somador(A[16], B[16], vai1, ref vai1);
            resultado[16] = somador1Bit.Somador(A[15], B[15], vai1, ref vai1);
            resultado[15] = somador1Bit.Somador(A[14], B[14], vai1, ref vai1);
            resultado[14] = somador1Bit.Somador(A[13], B[13], vai1, ref vai1);
            resultado[13] = somador1Bit.Somador(A[12], B[12], vai1, ref vai1);
            resultado[12] = somador1Bit.Somador(A[11], B[11], vai1, ref vai1);
            resultado[11] = somador1Bit.Somador(A[10], B[10], vai1, ref vai1);
            resultado[10] = somador1Bit.Somador(A[09], B[09], vai1, ref vai1);
            resultado[09] = somador1Bit.Somador(A[08], B[08], vai1, ref vai1);
            resultado[08] = somador1Bit.Somador(A[07], B[07], vai1, ref vai1);
            resultado[07] = somador1Bit.Somador(A[06], B[06], vai1, ref vai1);
            resultado[06] = somador1Bit.Somador(A[05], B[05], vai1, ref vai1);
            resultado[05] = somador1Bit.Somador(A[04], B[04], vai1, ref vai1);
            resultado[04] = somador1Bit.Somador(A[03], B[03], vai1, ref vai1);
            resultado[03] = somador1Bit.Somador(A[02], B[02], vai1, ref vai1);
            resultado[02] = somador1Bit.Somador(A[01], B[01], vai1, ref vai1);
            resultado[01] = somador1Bit.Somador(A[00], B[00], vai1, ref vai1);

            if (soma == true)
            {
                // tratamento de overflow
                if (vai1 == true)
                {
                    resultado[00] = true;

                    for (int i = 0; i < 24; i++)
                    {
                        registrador[i] = resultado[i];
                    }
                    overflow = true;
                }
                else
                {
                    for (int i = 0; i < 24; i++)
                    {
                        registrador[i] = resultado[i + 1];
                    }
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

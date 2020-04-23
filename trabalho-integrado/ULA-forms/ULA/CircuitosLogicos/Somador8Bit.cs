using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class Somador8Bit
    {
        public bool[] Somador(bool[] A, bool[] B, ref bool overflow)
        {
            CircuitoSomador somador1Bit = new CircuitoSomador();

            bool[] resultado = new bool[9];
            bool[] registrador = new bool[8];
            bool vai1 = false;

            resultado[08] = somador1Bit.Somador(A[07], B[07], vai1, ref vai1);
            resultado[07] = somador1Bit.Somador(A[06], B[06], vai1, ref vai1);
            resultado[06] = somador1Bit.Somador(A[05], B[05], vai1, ref vai1);
            resultado[05] = somador1Bit.Somador(A[04], B[04], vai1, ref vai1);
            resultado[04] = somador1Bit.Somador(A[03], B[03], vai1, ref vai1);
            resultado[03] = somador1Bit.Somador(A[02], B[02], vai1, ref vai1);
            resultado[02] = somador1Bit.Somador(A[01], B[01], vai1, ref vai1);
            resultado[01] = somador1Bit.Somador(A[00], B[00], vai1, ref vai1);

            // tratamento de overflow
            if (vai1 == true)
            {
                //Console.WriteLine("OVERFLOW");
                //Console.ReadKey();

                resultado[00] = true;

                for (int i = 0; i < 8; i++)
                {
                    registrador[i] = resultado[i];
                }
                overflow = true;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    registrador[i] = resultado[i+1];
                }
            }
            return registrador;
        }
    }
}

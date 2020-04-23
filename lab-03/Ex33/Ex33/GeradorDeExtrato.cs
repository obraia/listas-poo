using System;

namespace Ex33
{
    class GeradorDeExtrato
    {
        public void GeraExtrato(IConta c)
        {
            Console.WriteLine("\n EXTRATO ");
            Console.WriteLine(" SALDO : R$" + c.Saldo.ToString("F2"));
        }
    }
}

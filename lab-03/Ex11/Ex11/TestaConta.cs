using System;

namespace Ex11
{
    class TestaConta
    {
        static void Main(string[] args)
        {
            Conta c = new ContaPoupanca();
            c.Saldo = 1000;
            Console.WriteLine(c.Saldo);
            Console.WriteLine();
            c.ImprimeExtratoDetalhado();
            Console.WriteLine();
        }
    }
}

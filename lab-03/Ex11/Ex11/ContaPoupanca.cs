using System;

// 1.1.5 O que acontece com a classe ContaPoupanca? Erro, pede a implementação do novo método abstrato

namespace Ex11
{
    class ContaPoupanca : Conta
    {
        private int DiaDoAniversario = DateTime.Now.Day;
      
        public override void ImprimeExtratoDetalhado()
        {
            Console.WriteLine(" EXTRATO DETALHADO DE CONTA POUPANÇA ");
            DateTime agora = DateTime.Now;
            Console.WriteLine(" DATA : " + agora.ToString("D"));
            Console.WriteLine(" SALDO : " + this.Saldo);
            Console.WriteLine(" ANIVERSÁRIO : " + this.DiaDoAniversario);
        }  
    }
}

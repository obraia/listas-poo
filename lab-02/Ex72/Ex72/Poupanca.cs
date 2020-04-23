using System;
namespace Ex72
{
    class Poupanca : Conta
    {
        public float TaxaJuros { get; private set; } // taxa de juros mensal da poupança 

        public Poupanca(float taxaJuros, string titular, int numConta, int tipoConta, int agencia, double saldo, DateTime data, bool contaStatus) : base(titular, numConta, tipoConta, agencia, saldo, data, contaStatus)
        {
            TaxaJuros = taxaJuros;
            RendimentoFinal();
        }

        public override void RendimentoFinal() // método para calcular rendimento após juros
        {
            int meses = Conta.DiffMeses(Data);
            for (int i = 0; i < meses; i++)
            {
                Saldo = (Saldo * TaxaJuros) + Saldo;
            }
        }
    }
}

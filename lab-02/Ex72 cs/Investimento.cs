namespace Ex72
{
    class Investimento : Conta
    {
        public float Rendimento { get; private set; } // taxa de rendimento mensal do investimento
        public float Imposto { get; private set; } // taxa de imposto mensal do investimento

        public Investimento(float rendimento, float imposto, string titular, int numConta, int tipoConta, int agencia, double saldo, string data, bool contaStatus) : base (titular, numConta, tipoConta, agencia, saldo, data, contaStatus)
        {
            Rendimento = rendimento;
            Imposto = imposto;
            RendimentoFinal();
        }

        public override void RendimentoFinal() // método para calcular rendimento após juros e imposto
        {
            int meses = Conta.DiffMeses(Data);
            for (int i = 0; i < meses; i++)
            {
                Saldo = (Saldo * Rendimento) + Saldo; 
            }

            Saldo =  Saldo - (Saldo * Imposto);
        }
    }
}

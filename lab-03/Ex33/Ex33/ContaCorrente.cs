
namespace Ex33
{
    class ContaCorrente : IConta
    {
        private static double TaxaPorOperacao = 0.45;

        public string Titular { get; set; }
        public int NumConta { get; set; }
        public int TipoConta { get; set; }
        public int NumAgencia { get; set; }
        public double Saldo { get; set; }
        public bool ContaAtiva { get; set; }

        public ContaCorrente(string titular, int numAgencia, int numConta, int tipoConta, double saldo, bool contaAtiva)
        {
            Titular = titular;
            NumConta = numConta;
            TipoConta = tipoConta;
            NumAgencia = numAgencia;
            Saldo = saldo;
            ContaAtiva = contaAtiva;
        }

        public bool Deposita(double valor)
        {
            if(valor > 0)
            {
                this.Saldo += valor - TaxaPorOperacao;
                return true;
            }
            else { return false; }

        }

        public bool Saca(double valor)
        {
            if (valor > 0)
            {
                this.Saldo -= valor + TaxaPorOperacao;
                return true;
            }
            else { return false; }
        }

        public string InfoConta()
        {
            return " Titular: " + Titular + "\n Agência: " + NumAgencia + "\n Número: " + NumConta.ToString("D4") + "\n Tipo da conta: Corrente";
        }

        public string EscreverArquivo()
        {
            return Titular + ";" + NumAgencia + ";" + NumConta + ";" + TipoConta + ";" + Saldo + ";" + ContaAtiva;
        }

    }
}

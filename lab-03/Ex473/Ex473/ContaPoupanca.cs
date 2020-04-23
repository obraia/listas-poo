using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex473
{
    class ContaPoupanca : IConta
    {
        public string Titular { get; private set; }
        public int NumConta { get; private set; }
        public int TipoConta { get; private set; }
        public int NumAgencia { get; private set; }
        public double Saldo { get; private set; }
        public bool ContaAtiva { get; private set; }
        public DateTime DataDeCriacao { get; private set; }

        public ContaPoupanca(string titular, int numAgencia, int numConta, double saldo, bool contaAtiva, DateTime dataDeCriacao)
        {
            Titular = titular;
            NumConta = numConta;
            TipoConta = 2;
            NumAgencia = numAgencia;
            Saldo = saldo;
            ContaAtiva = contaAtiva;
            DataDeCriacao = dataDeCriacao;
        }

        public bool Deposito(double valor)
        {
            if (valor > 0)
            {
                this.Saldo += valor; ;
                return true;
            }
            else { return false; }

        }

        public bool Saque(double valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                this.Saldo -= valor;
                return true;
            }
            else { return false; }
        }

        public string InfoConta()
        {
            return " Titular: " + Titular + "\n Agência: " + NumAgencia + "\n Número: " + NumConta.ToString("D4") + "\n Tipo da conta: Corrente";
        }

        public void DesativarConta()
        {
            ContaAtiva = false;
        }

        public string EscreverArquivo()
        {
            return Titular + ";" + NumAgencia.ToString("D3") + ";" + NumConta.ToString("D4") + ";" + TipoConta + ";" + Saldo + ";" + ContaAtiva + ";" + DataDeCriacao;
        }
    }
}

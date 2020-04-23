using System;

namespace Ex72
{
    class Conta
    {
        public bool ContaStatus { get; set; } // armazenar estado da conta true = ativa - false = desativada
        public String Titular { get; private set; } // nome do titular da conta
        public int NumConta { get; private set; } // número da conta
        public int TipoConta { get; private set; } // indica o tipo da conta: corrente, poupança ou investimento
        public int Agencia { get; private set; } // número da agência da conta
        public double Saldo { get; protected set; } // saldo atual da conta
        public String Data { get; private set; } // data de abertura da conta

        public static int DiffMeses(string dataS) // diferença de meses entre duas datas para calcular, juros, impostos etc
        {
            //dataS = DateTime.Now.ToShortDateString(); // simplificar data para formato dd/mm/aaaa
            DateTime dataAgora = DateTime.Now; // obter data do momento
            DateTime data = Convert.ToDateTime(dataS); // convertendo string dataS para objeto do tipo data

            var diff = (dataAgora - data).TotalDays; // diferença em dias da data de criação da conta até a data do momento
            int meses = (int)diff / 30; // diferença em meses entre as duas datas

            return meses;
        }

        public Conta(string titular, int numConta, int tipoConta, int agencia, double saldo, string data, bool contaStatus)
        {
            Titular = titular;
            NumConta = numConta;
            TipoConta = tipoConta;
            Agencia = agencia;
            Saldo = saldo;
            Data = data;
            ContaStatus = contaStatus;
        }

        public bool Deposita(double valor) // método para realizar depósitos
        {
            if (valor > 0)
            {
                Saldo += valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Retira(double valor) // método para realizar saques
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        virtual public void RendimentoFinal() // método a ser sobrescrito
        {

        }

        public string InfoConta() // exibe informações sobre uma conta
        {
            return " Titular: " + Titular + "\n" +
                   " Número da conta: " + NumConta.ToString("D4") + "\n" +
                   " Agência: " + Agencia + "\n" +
                   " Tipo da conta: " + TipoConta + "\n";
        }

        public override string ToString()
        {
            return "\n Titular: " + Titular + "\n" +
                   " Número da conta: " + NumConta.ToString("D4") + "\n" +
                   " Tipo da conta: " + TipoConta + "\n";
        }

    }
}

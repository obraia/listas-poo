using System;

namespace Ex12
{
    class PFisica : Contribuinte
    {
        protected String CPF;
        protected double Salario;

        public PFisica(String nome, String cpf, String endereco, double salario, bool pfisica, bool contribuinteStatus) : base(nome, endereco, pfisica, contribuinteStatus)
        {
            CPF = cpf;
            Salario = salario;
        }

        public override double CalcImposto() // método para calcular e retornar imposto
        {
            double imposto = 0;

            if (Salario <= 1400.00)
            {
                imposto = 0;
            }
            else if (Salario >= 1400.01 && Salario <= 2100.00)
            {
                imposto = Salario * 0.1;
            }
            else if (Salario >= 2100.01 && Salario <= 2800.00)
            {
                imposto = Salario * 0.15;
            }
            else if (Salario >= 2800.01 && Salario <= 3600.00)
            {
                imposto = Salario * 0.25;
            }
            else
            {
                imposto = Salario * 0.3;
            } 
            return imposto;
        }

        public override string EscreverArquivo()
        {
            return "PF," + CPF + "," + Nome + "," + Endereco + "," + ContribuinteStatus + "," + Salario.ToString("F2");
        }

        public override string MostrarInformacoes() // retornar todos os dados sobre o contriuinte
        {
            return "\n CPF: " + CPF + "\n"
                + " Nome: " + Nome + "\n"
                + " Endereço: " + Endereco + "\n"
                + " Salário: R$" + Salario.ToString("F2") + "\n"
                + " Número de inscrição: " + NumeroInscricao.ToString("D3") + "\n";
        }

        public override string ToString() // retornar algumas informações sobre contriuinte
        {
            return "\n CPF: " + CPF + "\n"
                + " Nome: " + Nome + "\n"
                + " Endereço: " + Endereco + "\n"
                + " Número de inscrição: " + NumeroInscricao.ToString("D3") + "\n";
        }
    }
}


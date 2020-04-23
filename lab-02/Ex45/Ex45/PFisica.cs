using System;

namespace Ex45
{
    class PFisica : Contribuinte
    {
        protected String CPF;
        protected double Salario;

        public PFisica(String nome, String cpf, String endereco, double salario, bool pfisica) : base(nome, endereco, pfisica)
        {
            CPF = cpf;
            Salario = salario;
        }

        public override double CalcImposto() // método para calcular e retornar imposto
        {
            double imposto = 0;

            if (Salario <= 1903.98)
            {
                imposto = 0;
            }
            else if (Salario >= 1903.99 && Salario <= 2826.65)
            {
                imposto = Salario * 0.075;
            }
            else if (Salario >= 2826.66 && Salario <= 3751.05)
            {
                imposto = Salario * 0.15;
            }
            else if (Salario >= 3751.06 && Salario <= 4664.68)
            {
                imposto = Salario * 0.225;
            }
            else
            {
                imposto = Salario * 0.275;
            }
  
            return imposto;
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


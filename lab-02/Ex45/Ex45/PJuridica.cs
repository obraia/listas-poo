using System;

namespace Ex45
{
    class PJuridica: Contribuinte
    {
        protected String CNPJ;
        protected double Faturamento;

        public PJuridica(String nome, String cnpj, String endereco, double faturamento, bool pfisica) : base(nome, endereco, pfisica)
        {
            CNPJ = cnpj;
            Faturamento = faturamento;
        }

        public override double CalcImposto() // método para calcular e retornar imposto
        {
            return Faturamento * 0.10;
        }

        public override string MostrarInformacoes() // retornar todos os dados sobre o contriuinte
        {
            return "\n CNPJ: " + CNPJ + "\n"
                + " Nome: " + Nome + "\n"
                + " Endereço: " + Endereco + "\n"
                + " Faturamento: R$" + Faturamento.ToString("F2") + "\n"
                + " Número de inscrição: " + NumeroInscricao.ToString("D3") + "\n";
        }

        public override string ToString() // retornar algumas informações sobre contriuinte
        {
            return "\n CNPJ: " + CNPJ + "\n"
                + " Nome: " + Nome + "\n"
                + " Endereço: " + Endereco + "\n"
                + " Número de inscrição: " + NumeroInscricao.ToString("D3") + "\n";
        }

    }
}

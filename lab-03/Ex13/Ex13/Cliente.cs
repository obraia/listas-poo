using System;

namespace Ex13
{
    class Cliente : Pessoa
    {
        private int Cartao;
        private int Debito;

        public Cliente(string nome, string endereco, int cartao, int debito)
        {
            Nome = nome;
            Endereco = endereco;
            Cartao = cartao;
            Debito = debito;
        }

        public int InformarCartao()
        {
            return Cartao;
        }

        public int InformarDebito()
        {
            return Debito;
        }
    }
}

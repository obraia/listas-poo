using System;

namespace Ex13
{
    abstract class Pessoa
    {
        protected string Nome;
        protected string Endereco;
        protected DateTime Nasc;

        public string InformaNome()
        {
            return Nome;
        }
    }
}

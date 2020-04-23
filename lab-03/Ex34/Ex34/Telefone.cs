using System;

namespace Ex34
{
    class Telefone
    {
        protected string TipoDoTelefone { get; set; }

        public void Ring()
        {
            Console.WriteLine("\n Tocando telefone {0} \n", TipoDoTelefone);
        }
    }
}

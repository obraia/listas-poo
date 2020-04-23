using System;

namespace Ex31
{
    class ControlePonto
    {
        public string Entrada(Funcionario f)
        {
            DateTime entrada = DateTime.Now;
            return " Data de entrada do funcionário " + f.Nome + ", código " + f.Codigo + ", foi: " + entrada;
        }

        public string Saida(Funcionario f)
        {
            DateTime saida = DateTime.Now;
            return " Data de saída do funcionário " + f.Nome + ", código " + f.Codigo + ", foi: " + saida;
        }
    }
}

using System;

namespace Ex13
{
    class Funcionario : Pessoa
    {
        private double Salario;

        public Funcionario(string nome, string endereco, DateTime dataNasc, double salario)
        {
            Nome = nome;
            Endereco = endereco;
            Nasc = dataNasc;
            Salario = salario;
        }

        public double InformarSalario()
        {
            return Salario;
        }

        public int CalcularIdade()
        {
            return DateTime.Now.Year - Nasc.Year;
        }
    }
}

using System;

namespace Ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciando Cliente
            Cliente cliente = new Cliente("Carlos", "Rua A", 10000,20000);
            Console.WriteLine("\n Nome do cliente: " + cliente.InformaNome());
            Console.WriteLine(" Cartão do cliente: " + cliente.InformarCartao());
            Console.WriteLine(" Debito do cliente: " + cliente.InformarDebito() + " \n");

            // Instanciando Funcinário
            DateTime dataNasc = DateTime.Parse("10/08/1953");
            Funcionario funcionario = new Funcionario("Alberto", "Rua B", dataNasc, 3800);
            Console.WriteLine("\n Nome do funcinário: " + funcionario.InformaNome());
            Console.WriteLine(" Salário do funcinário: " + funcionario.InformarSalario());
            Console.WriteLine(" Idade do funcinário: " + funcionario.CalcularIdade() + " \n");
        }
    }
}

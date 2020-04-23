//
// nome do programa: Ex32.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 21/10/2019
// entrada(s): não tem entrada
// saida(s): Extrato simples de duas contas
// para executar  e testar: basta compilar e executar o programa
// descricao: Um programa exibe a data e hora do extrato de duas contas
//

using System;

namespace Ex32
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n CONTA CORRENTE \n");
  
            Corrente corrente = new Corrente();
            corrente.Limite = 10000;
            corrente.Saldo = 3800;
            GeradorDeExtrato extratoCorrente = new GeradorDeExtrato();
            extratoCorrente.ImprimeExtratoBasico(corrente);

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("\n CONTA POUPANÇA \n");
            Poupanca poupanca = new Poupanca();
            poupanca.DiaDoAniversario = 25;
            poupanca.Saldo = 28000;
            GeradorDeExtrato extratoPoupanca = new GeradorDeExtrato();
            extratoCorrente.ImprimeExtratoBasico(poupanca);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

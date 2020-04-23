//
// nome do programa: Ex31.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 21/10/2019
// entrada(s): não tem entrada
// saida(s): informação da momento do ponto de entrada e saida de um funcionário
// para executar  e testar: basta compilar e executar o programa
// descricao: Um programa que simula o registro de pontos por um funcionário em uma empresa
// registrando datas e horas do momento em que o ponto de entrada e saída foi feito
//

using System;

namespace Ex31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Gerente gerente = new Gerente("Jubileu", 534215);
            ControlePonto pontoGerente = new ControlePonto();
            Console.WriteLine(pontoGerente.Entrada(gerente));
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine(pontoGerente.Saida(gerente));

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine();
            Telefonista telefonista = new Telefonista("Alberto", 382117);
            ControlePonto pontoTelefonista = new ControlePonto();
            Console.WriteLine(pontoTelefonista.Entrada(telefonista));
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine(pontoTelefonista.Saida(telefonista));

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

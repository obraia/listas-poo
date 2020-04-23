//
// nome do programa: Ex34.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 31/10/2019
// entrada(s): Não tem entrada de dados
// saida(s): Impressão do método Ring da classe Telefone
// para executar  e testar: basta executar o programa
// descricao: Um programa simples para realaizar testes de heranças
// onde envolve uma classe principal Telefone que é herdada pela classe TelefoneEletronico
//

using System;

namespace Ex34
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes();

            TelefoneEletronico tE = new TelefoneEletronico();
            System.Threading.Thread.Sleep(300);
            tE.Ring();
        }

        static void ImprimirNomes()
        {
            Console.Clear();
            Console.WriteLine("\n Integrantes: \n");
            Console.WriteLine(" 652813 - Bryan Diniz Rodrigues");
            Console.WriteLine(" 664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine(" 668579 - Thais Barcelos Lorentz");
            Console.Write("\n Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

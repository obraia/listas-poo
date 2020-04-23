//
// nome do programa: Ex21.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 21/10/2019
// entrada(s): não tem entrada
// saida(s): informação sobre estado da TV e um DVD
// para executar  e testar: basta compilar e executar o programa
// descricao: Um programa que simula operações básicas de uma TV junto a um DVD
//

using System;

namespace Ex21
{
    class Program
    {

        static public void Tela(TV tv1, DVD dvd1)
        {
            Console.Clear();
            Console.WriteLine();

            if (tv1.Ligada)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" TV LIGADA\n ");
                Console.ResetColor();

                Console.WriteLine(" Canal = {0:00} ", tv1.Canal);
                Console.WriteLine(" Volume = {0:00}", tv1.Vol);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" TV DESLIGADA ");
                Console.ResetColor();
            }
            Console.WriteLine();
            if (dvd1.Ligado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" DVD LIGADO\n ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" DVD DESLIGADO ");
                Console.ResetColor();
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            ImprimirNomes();

            TV tv = new TV();
            DVD dvd = new DVD();

            char opcao;

            do
            {
                Tela(tv, dvd);

                Console.WriteLine(" Opcoes TV: \n");
                Console.WriteLine(" Canal: - e +");
                Console.WriteLine(" Volume: < e >");
                Console.WriteLine(" Power: P");
                Console.WriteLine();
                Console.WriteLine("\n Opcoes DVD: \n");
                Console.WriteLine(" Power: O");
                Console.WriteLine();
                Console.WriteLine("\n Sair: X");

                opcao = Console.ReadKey().KeyChar;

                switch (opcao)
                {
                    case '=':
                    case '+':
                        tv.sCanal();
                        break;

                    case '-':
                    case '_':
                        tv.bCanal();
                        break;

                    case '.':
                    case '>':
                        tv.sVol();
                        break;

                    case ',':
                    case '<':
                        tv.bVol();
                        break;

                    case 'P':
                    case 'p':
                        if (tv.Ligada == false) { tv.Ligar(); }
                        else { tv.Desligar(); }
                        break;
                    case 'o':
                    case 'O':
                        if(dvd.Ligado == false) { dvd.Ligar(); }
                        else { dvd.Desligar(); }
                        break;
                }
            } while (opcao.ToString().ToUpper() != "X");
        }

        static void ImprimirNomes()
        {
            Console.Clear();
            Console.WriteLine("\n Integrantes:\n");
            Console.WriteLine(" 652813 - Bryan Diniz Rodrigues");
            Console.WriteLine(" 664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine(" 668579 - Thais Barcelos Lorentz");
            Console.Write("\n Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

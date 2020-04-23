//
// nome do programa: Ex22.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 21/10/2019
// entrada(s): valores de medidas em cm para diversas formas geométricas
// saida(s): medidas e resultados de calculos para área e perímetro
// para executar  e testar: basta compilar e executar o programa e seguir as solicitações
// descricao: Um programa que calcula área e perímetro de algumas formas geométricas, como:
// quadrado, ratângulo e circulo
//

using System;

namespace Ex22
{
    class Program
    {
        static void Main(string[] args)
        {
            // Medidas para todas as formas em centímetros

            ImprimirNomes();

            Console.Write("\n Digite quantas formas geométricas deseja criar: ");
            int numFormas = int.Parse(Console.ReadLine());

            IForma[] vetFormas = new IForma[numFormas];

            for (int i = 0; i < numFormas; i++)
            {
                Console.Clear();
                Console.WriteLine("\n {0}° Forma", (i+1));
                Console.WriteLine("\n Qual forma geométrica deseja criar?");
                Console.WriteLine("\n 1. Quadrado \n 2. Retângulo \n 3. Circulo");
                Console.Write("\n Escolha uma opção: ");

                byte opc = byte.Parse(Console.ReadLine());
                Console.Clear();

                switch (opc)
                {
                    case 1:
                        Console.Write("\n Quadrado \n\n Digite a medida do lado do quadrado em cm: ");
                        int lado = int.Parse(Console.ReadLine());
                        Quadrado quadrado = new Quadrado(lado);
                        vetFormas[i] = quadrado;
                        break;

                    case 2:
                        Console.Write("\n Retângulo \n\n Digite a medida da base do retângulo em cm: ");
                        int baseX = int.Parse(Console.ReadLine());
                        Console.Write("\n Digite a medida da altura do retângulo em cm: ");
                        int alturaY = int.Parse(Console.ReadLine());
                        Retangulo retangulo = new Retangulo(baseX, alturaY);
                        vetFormas[i] = retangulo;
                        break;

                    case 3:
                        Console.Write("\n Circulo \n\n Digite a medida do raio do circulo em cm: ");
                        int raio = int.Parse(Console.ReadLine());
                        Circulo circulo = new Circulo(raio);
                        vetFormas[i] = circulo;
                        break;

                    default:
                        Console.WriteLine("\n Opção inválida! \n");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < vetFormas.Length; i++)
            {
                Console.WriteLine(vetFormas[i]);
            }

            Console.ReadKey();

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

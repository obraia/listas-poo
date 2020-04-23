//
// nome do programa: 
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 15/08/2019
// entrada(s): 1 1 0 1 1 h 1 0 0 1 1
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): Distância de Hamming: 1
// para executar  e testar digite: Ex33.exe 1 1 0 1 1 h 1 0 0 1 1
// descricao: o usuário entrará com duas sequências de inteiros separados por um "h" e o programa
// retornará a distância de hamming entre esses dois vetores
//

using System;

namespace HammingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho

            int cont = 0;
            int tam = (args.Length - 1) / 2; // tamanho dos vetores individuais

            if (args.Length % 2 == 0) // em caso de tamanhos diferentes entre os vetores
            {
                Console.WriteLine("Os dois vetores devem ter o mesmo tamanho");
                Environment.Exit(0);
            }

            try
            {
                int[] vetA = new int[(tam)]; // vetor que armazenará a primeira sequência de inteiros
                int[] vetB = new int[(tam)]; // vetor que armazenará a segunda sequência de inteiros

                for (int i = 0; i < args.Length; i++) // adicionando elementos ao primeiro vetor
                {
                    if (args[i] != "h")
                    {
                        vetA[i] = int.Parse(args[i]);
                        Console.Write(vetA[i] + " ");
                        cont++;
                    }
                    else break;
                }

                Console.WriteLine();

                cont++; // conta para continuar contagem a partir de onde terminou o for anterior

                for (int i = 0; i < vetB.Length; i++) // adicionando elementos ao segundo vetor
                {
                    vetB[i] = int.Parse(args[cont]);
                    Console.Write(vetB[i] + " ");
                    cont++;
                }

                Console.WriteLine("\nDistância de Hamming: " + HammingDistance(vetA, vetB));
            }
            catch
            {
                Console.WriteLine("\nParâmetros inválidos, para execultar o programa digite: Program.exe 1 0 0 h 1 0 1");
            }
        }

        static int HammingDistance(int[] vetA, int[] vetB) // metodo para calcular a distância de Hamming
        {
            int distance = 0;

            for (int i = 0; i < vetA.Length; i++)
            {
                if (vetA[i] != vetB[i]) // verificando diferenças entre os elemtos dos dois vetores
                {
                    distance++;
                }
            }
            return distance;
        }

        static void ImprimirNomes()
        {
			Console.Clear();	
            Console.WriteLine("Integrantes:");
            Console.WriteLine("652813 - Bryan Diniz Rodrigues");
            Console.WriteLine("664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine("668579 - Thais Barcelos Lorentz");
            Console.Write("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
			Console.Clear();			
        }
		
    }
}


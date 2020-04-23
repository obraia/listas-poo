//
// nome do programa: Ex32.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 05/08/2019
// entrada(s): n numeros inteiros através da linha de comando 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): imprime o vetor de números ordenado, o maior, e o menor
// para executar  e testar digite: 
// Ex32.exe 9 3 8 5 
// descricao: recebe n numeros inteiros através da linha de comando,
// armazena em um vetor e chama um método estático que receba estes
// números inteiros (armazenados no vetor),  e retorna   o maior
// deles e a média de seus valores.
//

using System;
using System.Linq;
using System.Text;

namespace Ex32
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho
			
           	try  // try usado para previnir erros ao receber parametros invalidos pelo args
			{

            int maior = 0, media = 0, menor = 0; // inicializacao de variaveis para calculo 
            int i, j; // inicializacao de variaveis contadoras
            j = args.Length; // numero de parametros recebidos na LC
            int[] vetor = new int[j]; // alocacao de vetor para receber numeros inteiros

            Console.WriteLine("\nPrograma Ex32.exe com " + j + " parametros:\n");
            for (i = 0; i < j; i++)
            { // mostra e converte parametros recebidos na LC
                vetor[i] = int.Parse(args[i]); // converte parametro recebidos na LC de string para inteiro e armazena no vetor
                Console.Write(" args[{0}] = {1}", i, args[i]);               
				Console.WriteLine(" vetor[{0}] = {1}", i, vetor[i]); // mostra vetor
            }
            Operar_valores(vetor, ref maior, ref media, ref menor); // chama metodo para fazer as operacoes solicitadas
            Console.WriteLine("\nMaior : " + maior); // mostra maior valor
            Console.WriteLine("Media : " + media); // mostra media dos valores
            Console.WriteLine("\nMenor : " + menor); // falta implementar
            Console.WriteLine("Vetor : " + String.Join(" ", vetor)); // mostrar vetor ordenado	     
			}
			catch
			{
				Console.WriteLine("Parâmetros inválidos, para executar o programa digite Ex32.exe 9 3 8 5");
			}
        }

        static void Operar_valores(int[] vet, ref int maior, ref int media, ref int menor)
        {
            int soma = 0;
            media = 0;
            maior = vet[0];
            menor = vet[0];
            for (int i = 0; i < vet.Length; i++)
            {
                soma += vet[i]; // acumular valores
                if (vet[i] > maior) // atualizar maior valor
                {
                    maior = vet[i];
                }
                if (vet[i] < menor) // atualizar menor valor
                {
                    menor = vet[i];
                }
            }

            Array.Sort(vet); // ordenar vetor

            media = soma / vet.Length; // calcular media dos valores
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
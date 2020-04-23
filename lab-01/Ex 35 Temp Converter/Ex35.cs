//
// nome do programa: Ex35.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 07/08/2019
// entrada(s): um valor para temperatura em °C ou em °F, exemplo 75 C 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): valor convertido para outra medida
// para executar  e testar digite: 
// Ex35.exe 75 C  
// descricao: Recebe uma temperatura em °c e converte para °f ou o oposto.
//

using System;
using System.Globalization;

namespace Ex35
{
    class Program
    {

        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho

            try  // try usado para previnir erros ao receber parametros invalidos pelo args
            {
                float minC = (-273.15f), minF = (-459.67f); // limite minimo de conversao		  
                float graus = float.Parse(args[0]); // recebendo valor numerico para medida
                string medida = args[1].ToLower(); // recebendo medida para indicar a conversao

                if (((medida == "°c") || (medida == "c") || (medida == "celsius")) && (graus >= minC))
                {
                    Console.WriteLine("{0} graus Fahrenheit", CtoF(graus).ToString("F2"));
                }
                else if (((medida == "°f") || (medida == "f") || (medida == "fahrenheit")) && (graus >= minF))
                {
                    Console.WriteLine("{0} graus Celsius", FtoC(graus).ToString("F2"));
                }
                else Console.WriteLine("Medida inválida");

            }
            catch
            {
                Console.WriteLine("Parâmetros inválidos, tente algo como: 43 f ou 32 °C");
            }

        }

        static double FtoC(double graus)
        { // metodo de convesao de Fahrenheit para Celsius
            return (graus - 32) * 5 / 9;
        }
        static double CtoF(double graus)
        { // metodo de convesao de Celsius para Fahrenheit
            return (graus * 1.8f) + 32;
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
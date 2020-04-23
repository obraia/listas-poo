//
// nome do programa: Ex31.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 09/08/2019
// entrada(s): Operandos e operadores matematicos 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): imprime o a operacao e o resultado
// para executar  e testar digite: 
// Ex31.exe 9 x 7 
// descricao: Recebe dois numeros e um operador matematico (+, -, x ou *, /), e retorna essa operacao
//com seu respectivo resultado.
//


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex31
{
    class Program
    {

        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho

            try // try usado para previnir erros ao receber parametros invalidos pelo args
            { 
                double numA = double.Parse(args[0].ToString(CultureInfo.InvariantCulture));
                char operador = char.Parse(args[1]);
                double numB = double.Parse(args[2].ToString(CultureInfo.InvariantCulture));

                if ((numB == 0) && ((operador == '/') || (operador == '÷'))) // impedir a entrada de divisao por zero
                {
                    Console.WriteLine("Impossível divisão por zero");
                    System.Environment.Exit(0);
                }
				
				Console.Write("{0} {1} {2} = ", numA, operador, numB); // imprimir base para exibir operacao				

                if (operador == '+') // chamando metodo somar
                {
                    Console.Write(Soma(ref numA, ref numB));
                }
                else if (operador == '-') // chamando metodo subtrair
                {
                    Console.Write(Sub(ref numA, ref numB));
                }
                else if ((operador == 'x') || (operador == '*')) // chamando metodo multiplicar
                {
                    Console.Write(Mult(ref numA, ref numB));
                }
                else if ((operador == '/') || (operador == '÷')) // chamando metodo divisao
                {
                    Console.Write(Div(ref numA, ref numB));
                }
                else Console.WriteLine("Operador Inválido");

                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Valores inseridos inválidos, tente algo como: 4 x 3");
            }
        }

        static double Soma(ref double numA, ref double numB) // metodo somar
        {
            return (numA + numB);
        }
        static double Sub(ref double numA, ref double numB) // metodo subtrair
        {
            return (numA - numB);
        }
        static double Mult(ref double numA, ref double numB) // metodo multiplicar
        {
            return (numA * numB);
        }
        static double Div(ref double numA, ref double numB) // metodo divisao
        {
            return (numA / numB);
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


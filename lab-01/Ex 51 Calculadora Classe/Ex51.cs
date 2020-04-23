//
// nome do programa: Ex51.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 07/08/2019
// entrada(s): Operandos e operadores matematicos 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): imprime o a operacao e o resultado
// para executar  e testar digite: 
// Ex51.exe 9 x 7 
// descricao: Recebe dois numeros e um operador matematico (+, -, x ou *, /), e retorna essa operacao
//com seu respectivo resultado.
//

using System;
using System.Globalization;

namespace Ex51
{
    class Program
    {

        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho
			
			Calc c = new Calc(); // instanciando objeto da calculadora

            try // try usado para previnir erros ao receber parametros invalidos pelo args
            { 
                double numA = double.Parse(args[0].ToString(CultureInfo.InvariantCulture)); // variável para armazenar primeiro operando
                char operador = char.Parse(args[1]); // variável para armazenar operador
				

                if (operador == '!') // chamada para fatorial
                {
					Console.Write("{0} {1} = ", numA, operador); // imprimir base para exibir operacao
                    Console.Write(c.Fat(numA));
                }
                else
                {
					double numB = double.Parse(args[2].ToString(CultureInfo.InvariantCulture)); // variável para armazenar segundo operando
					
					Console.Write("{0} {1} {2} = ", numA, operador, numB); // imprimir base para exibir operacao
                    
					if ((numB == 0) && (operador == '/')) // impossibilitar divisao por zero
                    {
                        Console.WriteLine("Impossível divisão por zero");
                        System.Environment.Exit(0);
                    }

                    if (operador == '+')
                    {
                        Console.Write(c.Soma(numA, numB));
                    }
                    else if (operador == '-')
                    {
                        Console.Write(c.Sub(numA, numB));
                    }
                    else if ((operador == 'x') || (operador == '*'))
                    {
                        Console.Write(c.Mult(numA, numB));
                    }
                    else if ((operador == '/') || (operador == '÷'))
                    {
                        Console.Write(c.Div(numA, numB));
                    }
                    else Console.WriteLine("Operador Inválido");
                }
            }
            catch
            {
                Console.WriteLine("Valores inseridos inválidos, tente algo como: 4 x 3");
            }
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
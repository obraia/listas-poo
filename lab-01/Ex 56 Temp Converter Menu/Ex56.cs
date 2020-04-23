//
// nome do programa: 
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 08/08/2019
// entrada(s): um valor para temperatura em °C ou em °F, exemplo 75 C 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): valor convertido para outra medida
// para executar  e testar digite: Ex56.exe
// descricao: recebe uma temperatura em °c e converte para °f ou o oposto.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex56
{
    class Program
    {

        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho

            while (10 > 5)
            {
                Menu();
            }
        }

        static void opcMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar\n");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1. Converter de Celsius para Fahrenheit");
            Console.WriteLine("2. Converter de Fahrenheit para Celsius");
            Console.WriteLine("3. Sair do programa");
        }

        static void Menu()
        {
            float minC = (-273.15f), maxC = (6000f); //define um  limite minimo e máximo de conversao
            float graus; // variavel para armazenar valor em graus digitado pelo usuário

            Conversor c = new Conversor(); // instanciando objeto conversor

            opcMenu(); // chamada de metodo com opcoes do menu

            try
            {
                Console.Write("\nInsira uma opção: ");
                byte opc = byte.Parse(Console.ReadLine()); //obter valor digitado pelo usuario
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        Console.Write("Digite um valor em °C para converter em °F: ");
                        graus = float.Parse(Console.ReadLine());
                        Console.Clear();
                        if (graus >= minC && graus <= maxC)
                        {
                            Console.WriteLine("{0} graus Celsius é igual a {1} graus Fahrenheit", graus.ToString("F2"), c.CtoF(graus).ToString("F2")); // exibir valor convertido em °F
                        }
                        else if (graus < minC)
                        {
                            Console.WriteLine("O Zero Absoluto em Celsius é {0} graus", minC.ToString("F2"));
                        }
                        else if (graus > maxC)
                        {
                            Console.WriteLine("A temperatura máxima suportada para conversão é {0}°C", maxC.ToString("F2"));
                        }
                        break;

                    case 2:
                        Console.Write("Digite um valor em °F para converter em °C: ");
                        graus = float.Parse(Console.ReadLine());
                        Console.Clear();

                        if (graus >= c.CtoF(minC) && graus <= c.CtoF(maxC))
                        {
                            Console.WriteLine("{0} graus Fahrenheit é igual a {1} graus Celsius", graus.ToString("F2"), c.FtoC(graus).ToString("F2")); // exibir valor convertido em °C
                        }
                        else if (graus < c.FtoC(minC))
                        {
                            Console.WriteLine("O Zero Absoluto em Fahrenheit é {0} graus", c.CtoF(minC).ToString("F2"));
                        }
                        else if (graus > c.FtoC(maxC))
                        {
                            Console.WriteLine("A temperatura máxima suportada para conversão é {0}°F", c.CtoF(maxC).ToString("F2"));
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        System.Threading.Thread.Sleep(200);
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, ou valor inválido");
                System.Threading.Thread.Sleep(200);
            }
        }


        static void ImprimirNomes()
        {
            Console.Clear();
            Console.WriteLine("Integrantes:");
            Console.WriteLine("652813 - Bryan Diniz Rodrigues");
            Console.WriteLine("664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine("668579 - Thais Barcelos Lorentz");
        }

    }

}

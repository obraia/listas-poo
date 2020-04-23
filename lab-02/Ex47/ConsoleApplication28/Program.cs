using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class Program
    {
        static double valorIngresso = 100;
        static void Main(string[] args)
        {
            bool loop = true;

            while (loop == true)
            {
                try
                {


                    int opcao;
                    Console.WriteLine("\tINGRESSOS\t");
                    Console.WriteLine("\n1.Normal\n2.VIP");
                    Console.Write("\nDigite a opção desejada: ");
                    opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("\tINGRESSO NORMAL\n");
                        Normal ingresso = new Normal(valorIngresso);
                        Console.WriteLine(ingresso);
                        loop = false;
                    }
                    else if (opcao == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("\tINGRESSOS VIP\n");
                        Console.WriteLine("\n1)Camarote Superior\n2)Camarote Inferior");
                        Console.Write("\nDigite a opção desejada: ");
                        opcao = int.Parse(Console.ReadLine());

                        if (opcao == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("\tCAMAROTE SUPERIOR\n");
                            CamaroteSuperior ingresso = new CamaroteSuperior(valorIngresso);
                            Console.WriteLine(ingresso);
                            loop = false;
                        }
                        else if (opcao == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("\tCAMAROTE INFERIOR\n");
                            CamaroteInferior ingresso = new CamaroteInferior(valorIngresso);
                            Console.WriteLine(ingresso);
                            loop = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Opção inválida");
                            Console.ResetColor();
                            loop = true;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Opção inválida");
                        Console.ResetColor();
                        loop = true;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Opção inválida");
                    Console.ResetColor();
                    loop = true;
                }
            }
            Console.ReadKey();
        }
    }
}



using System;

namespace Ex35
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes();

            IOperacaoMatematica op; // objeto polimorfo
            int opc = 0;
            int a = 0;
            int b = 0;
            bool aux;
            bool loop = true;

            do
            {
                Console.WriteLine("\n OPRAÇÕES MATEMÁTICAS + - x ÷ (a ? b = ?)\n");

                Console.Write("\n 1. Somar \n 2. Subtrair \n 3. Multiplicar \n 4. Dividir \n 5. Sair \n\n Digite uma opção: ");
                aux = int.TryParse(Console.ReadLine(), out opc);
                Console.Clear();

                try
                {
                    switch (opc)
                    {
                        case 1:
                            PedirNumeros(ref a, ref b);
                            op = new Soma();
                            Console.WriteLine("\n Resultado: {0} + {1} = {2}", a, b, op.Calcula(a, b));
                            break;

                        case 2:
                            PedirNumeros(ref a, ref b);
                            op = new Subtracao();
                            Console.WriteLine("\n Resultado: {0} - {1} = {2} \n", a, b, op.Calcula(a, b));
                            break;

                        case 3:
                            PedirNumeros(ref a, ref b);
                            op = new Multiplicacao();
                            Console.WriteLine("\n Resultado: {0} * {1} = {2} \n", a, b, op.Calcula(a, b));
                            break;

                        case 4:
                            PedirNumeros(ref a, ref b);
                            if (b != 0)
                            {
                                op = new Divisao();
                                Console.WriteLine("\n Resultado: {0} / {1} = {2} \n", a, b, op.Calcula(a, b));
                            }
                            else { Console.WriteLine("\n Divisão por zero inderterminada \n"); }
                            break;

                        case 5:
                            loop = false;
                            break;

                        default: Console.WriteLine("\n Opção inválida! \n"); break;
                    }
                }
                catch { Console.WriteLine("\n Operadores inválidos! "); }

                Console.Write("\n Pressione qualquer tecla para continuar: ");
                Console.ReadKey();
                Console.Clear();

            } while (loop == true);

        }

        static void PedirNumeros(ref int a, ref int b)
        {
            Console.Write("\n Digite o valor de a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("\n Digite o valor de b: ");
            b = int.Parse(Console.ReadLine());
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

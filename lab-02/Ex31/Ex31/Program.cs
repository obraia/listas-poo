using System;

namespace Ex31
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Loop infinito até usuário sair do programa ao digitar 4
            {
                Menu();
            }
        }

        public static void MenuOpcs() // Mostrar opções do menu
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\t Teste de datas\t\t\n");

            Console.ResetColor();

            Console.WriteLine(" 1 - Próximos dias");
            Console.WriteLine(" 2 - Comparar data");
            Console.WriteLine(" 3 - Dia do ano 1 a 365/366");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" 4 - Sair do programa");

            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\t\t\t\t\n");

            Console.ResetColor();
        }

        public static void Menu() // Chamar opções do menu
        {
            try
            {
                MenuOpcs();

                Console.Write("Digite uma opção: ");

                Console.ForegroundColor = ConsoleColor.Gray;

                byte opc = byte.Parse(Console.ReadLine()); // Armazenar opção do usuário

                Console.ResetColor();

                Console.Clear();

                switch (opc) // Chamar métodos de acordo com a opção do usuário
                {
                    case 1:
                        ProximosDias();
                        break;

                    case 2:
                        CompararDatas();
                        break;

                    case 3:
                        DiaDoAno();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        System.Threading.Thread.Sleep(100);

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Opção inválida, tente novamente\n");

                        Console.ResetColor();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                System.Threading.Thread.Sleep(100);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Opção inválida, tente novamente\n");

                Console.ResetColor();
            }
        }

        static void ProximosDias() // Percorrer n dias a partir de uma data
        {
            int dias = 0; // Variável para armazenar número de dias que será percorridos

            Date5 dataNext;

            InserirData(out dataNext); // Chamando método para inserir uma data

            Console.Clear();

            bool loop = true; // Boolean para definir se o loop continuará ou não

            while (loop == true)
            {
                try // Tratamento de exceções
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write("Digite quantos dias quer percorrer da data {0}: ", dataNext);

                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Gray;

                    dias = int.Parse(Console.ReadLine());

                    Console.ResetColor();

                    Console.WriteLine();

                    loop = false;
                }
                catch
                {
                    Console.Clear();
                    System.Threading.Thread.Sleep(100);

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Valor inválido, tente novamente\n");

                    Console.ResetColor();
                    loop = true;
                }
            }

            Console.Clear();

            Console.WriteLine("\n" + dataNext);

            for (int i = 0; i < dias; i++) // Avançando os n dias da data
            {
                dataNext.ProximoDia();
                Console.WriteLine(dataNext);
            }

            Console.WriteLine("\n" + dataNext.MostrarData()); // Mostrar ao usuário a data final

            Console.ReadKey();
            Console.Clear();
        }

        public static void DiaDoAno() // Método para mostrar dia do ano de uma data
        {
            Date5 data3;

            InserirData(out data3); // Chamando método para inserir uma data

            Console.WriteLine("\n{0} corresponde ao dia {1}° desse ano\n", data3.MostrarData(), data3.DiaDoAno()); // Mostrar a data

            Console.ReadKey();
            Console.Clear();

        }

        public static void CompararDatas() // Método para chamar compararador entre duas datas
        {
            Console.Clear();
            Date5 data1, data2;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nPara comparar datas, digite duas datas:");

            Console.ResetColor();

            System.Threading.Thread.Sleep(500);

            InserirData(out data1); // Chamando método para inserir a primeira data
            InserirData(out data2); // Chamando método para inserir a segunda data

            Console.Clear();

            // Chamando método de instância e exibindo a a diferênças entre as duas datas 
            Console.Write("\nAs datas {0} e {1} tem uma diferença de ", data1, data2);
            Console.Write(Date5.DiffDias(data1, data2) + " dias\n");
            Console.ReadKey();
            Console.Clear();
        }

        public static void InserirData(out Date5 data) // Método para inserir uma data
        {

            int dia = 0, mes = 0, ano = 0; // Variáveis para salvar parâmetros para a data

            bool loop = true; // Boolean para definir se o loop continuará ou não

            while (loop == true) // Repetição em caso de parâmetros inválidos
            {
                try // Tratamento de exceções
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nEntre com a data");
                    Console.ResetColor();

                    Console.Write("\nDia: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    dia = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    Console.Write("Mês: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    mes = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    Console.Write("Ano: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ano = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch // Em caso de valores inválidos (caracteres não numéricos) dia, mes e ano receberá 0, que será interpretado como datá inválida
                {
                    dia = 0;
                    mes = 0;
                    ano = 0;
                }

                data = new Date5(dia, mes, ano); // Instânciando data através do contrutor

                if (data.DataValida() == false) // Verificar validade da data
                {
                    Console.Clear();
                    System.Threading.Thread.Sleep(100);

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Data inválida, tente novamente");
                    Console.ResetColor();

                    loop = true;
                }
                else
                {
                    loop = false;
                }
            }

            data = new Date5(dia, mes, ano); // Instânciando a data válida
        }

    }
}

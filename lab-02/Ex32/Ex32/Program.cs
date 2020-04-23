using System;

namespace Ex32
{
    class Program
    {
        static int cont = 1; // contador de número de contas

        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }

        static void OpcsMenu(bool contaCriada, bool contaSelecionada)
        {
            if (contaSelecionada == false)
            {
                Console.WriteLine(" 1. Criar uma nova conta");
            }

            if (contaCriada == true && contaSelecionada == false)
            {
                Console.WriteLine(" 2. Selecionar uma conta");

            }

            if (contaCriada == true && contaSelecionada == true)
            {
                Console.WriteLine(" 3. Excluir conta");
                Console.WriteLine(" 4. Depositar");
                Console.WriteLine(" 5. Sacar");
                Console.WriteLine(" 6. Mostrar saldo");
                Console.WriteLine(" 7. Sair da conta");
            }

            if (contaCriada == true && contaSelecionada == false)
            {
                Console.WriteLine(" 8. Mostrar contas cadastradas");
                Console.WriteLine(" 9. Buscar conta e mostrar informações");
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n 0. Sair do programa");

            Console.ResetColor();

        }

        static void Menu()
        {
            int contaSelecionada = 0;
            bool contaCriada = false;
            bool contaSelec = false;

            while (true)
            {

                contaSelec = Conta.EntrarConta(contaSelecionada);

                OpcsMenu(contaCriada, contaSelec);

                Console.Write("\n Digite uma opção: ");

                try
                {
                    byte opc = byte.Parse(Console.ReadLine());

                    if (contaSelec == false && contaCriada == false)
                    {

                        switch (opc)
                        {

                            case 1:
                                Console.Clear();
                                contaCriada = NovaConta();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 0:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine(" Opção inválida! \n");

                                Console.ResetColor();

                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                break;
                        }

                    }

                    else if (contaCriada == true && contaSelec == false)
                    {

                        switch (opc)
                        {
                            case 1:
                                Console.Clear();
                                contaCriada = NovaConta();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 2:
                                contaSelecionada = EntrarConta();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 8:
                                Console.Clear();
                                Conta.ExibirContas();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 9:
                                Console.Clear();
                                BuscarConta();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 0:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine(" Opção inválida! \n");

                                Console.ResetColor();

                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                break;
                        }

                    }

                    else if (contaCriada == true && contaSelec == true)
                    {

                        switch (opc)
                        {
                            case 3:
                                Console.Clear();
                                Conta.ExcluirConta(contaSelecionada);
                                contaSelecionada = 0;
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 4:
                                Console.Clear();
                                Depositar(contaSelecionada);
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 5:
                                Console.Clear();
                                Sacar(contaSelecionada);
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 6:
                                Console.Clear();
                                Conta.VerSaldo(contaSelecionada);
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 7:
                                Console.Clear();
                                contaSelecionada = 0;
                                break;

                            case 0:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine(" Opção inválida! \n");

                                Console.ResetColor();

                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                break;
                        }
                    }

                    else if (contaCriada == true && contaSelec == false)
                    {

                        switch (opc)
                        {

                            case 8:
                                Console.Clear();
                                Conta.ExibirContas();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 9:
                                Console.Clear();
                                BuscarConta();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 0:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine(" Opção inválida! \n");

                                Console.ResetColor();

                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                break;
                        }

                    }
                }
                catch
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(" Opção inválida! \n");

                    Console.ResetColor();

                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                }

            }
        }

        static bool NovaConta()
        {

            Console.Write("\n Digite seu nome completo: ");
            string nome = Console.ReadLine();

            Console.Clear();

            int agencia = Agencias();

            Console.WriteLine();

            Conta conta = new Conta(nome, agencia, cont);

            Conta.AddConta(conta);

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\tConta criada com sucesso!\t\n");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(conta + "\n");
            Console.ResetColor();

            cont++;

            return true;

        }

        static int Agencias()
        {

            int[] agencias = new int[] { 10, 20, 30, 40 };
            bool loop = true;
            byte opc = 0;

            while (loop == true)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine(" Escolha uma agência \n");

                Console.ResetColor();

                for (int i = 0; i < agencias.Length; i++)
                {
                    Console.WriteLine(" {0}. Agência: {1}", i + 1, agencias[i].ToString("D4"));
                }

                Console.Write("\n Digite uma opção: ");

                try
                {
                    opc = byte.Parse(Console.ReadLine());

                    if (opc > 0 && opc <= agencias.Length)
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.Clear();
                        System.Threading.Thread.Sleep(100);

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Opção inválida, tente novamente\n");

                        Console.ResetColor();

                        loop = true;
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

                    loop = true;
                }

            }

            return agencias[opc - 1];

        }

        static int EntrarConta()
        {
            int numConta = 0;
            int conta = 0;

            Console.Clear();
            Console.Write("\n Para acessar digite o número da conta: ");

            try
            {
                numConta = int.Parse(Console.ReadLine());

                if (Conta.EntrarConta(numConta) == true)
                {
                    conta = numConta;
                }
                else
                {
                    Console.Clear();


                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(" Número de conta inválido! ");

                    Console.ResetColor();

                }
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Número de conta inválido! ");

                Console.ResetColor();

            }

            return conta;
        }


        static void Depositar(int numConta)
        {

            double valor = 0;

            try
            {
                Console.Write("\n Digite o valor de depoósito: R$");
                valor = Double.Parse(Console.ReadLine());

                Console.Clear();

                Conta.DepositarConta(numConta, valor);
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Valor inválido, digite apenas números. ");

                Console.ResetColor();

            }
        }

        static void Sacar(int numConta)
        {
            double valor = 0;

            try
            {
                Console.Write("\n Digite o valor de para o saque: R$");
                valor = Double.Parse(Console.ReadLine());

                Console.Clear();

                Conta.SacarConta(numConta, valor);
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Valor inválido, digite apenas números. ");

                Console.ResetColor();

            }
        }


        static void BuscarConta()
        {
            int numConta = 0;

            try
            {
                Console.Write("\n Digite o número da conta: ");
                numConta = int.Parse(Console.ReadLine());

                Console.Clear();

                Conta.BuscarConta(numConta);
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Número de conta inválido! ");

                Console.ResetColor();

            }

        }

    }
}

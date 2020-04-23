using System;
using System.IO;

namespace Ex33
{
    class Program
    {
        static int Cont = 0;
        static int MaxContas = 100;
        static IConta[] vetContas = new IConta[MaxContas];

        static void CriarArquivos()
        {
            if (!Directory.Exists("Files/Agencias"))
            {
                Directory.CreateDirectory("Files/Agencias");
                StreamWriter sr = new StreamWriter("Files/Agencias.txt");
                sr.WriteLine("10;20;30;40;50");
                sr.Close();
            }
        }

        static void LerArquivo(ref int agencia)
        {
            string caminhoArq = @"Files/Agencias/" + agencia + ".txt";

            try
            {
                if (File.Exists(caminhoArq))
                {
                    using (StreamReader sr = new StreamReader(caminhoArq))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            string[] aux = linha.Split(';');
                            string titular = aux[0];
                            int numAgencia = int.Parse(aux[1]);
                            int numConta = int.Parse(aux[2]);
                            int tipoConta = int.Parse(aux[3]);
                            double saldo = double.Parse(aux[4]);
                            bool contaAtiva = bool.Parse(aux[5]);

                            if (tipoConta == 1)
                            {
                                ContaCorrente cc = new ContaCorrente(titular, numAgencia, numConta, tipoConta, saldo, contaAtiva);
                                vetContas[Cont] = cc;
                                Cont++;
                            }
                            else if (tipoConta == 2)
                            {
                                ContaCorrente cp = new ContaCorrente(titular, numAgencia, numConta, tipoConta, saldo, contaAtiva);
                                vetContas[Cont] = cp;
                                Cont++;
                            }

                            Console.WriteLine("\n Contas carregadas: " + Cont);
                        }
                    }
                }
                else { Console.WriteLine("\n Arquivo não encontrado! "); }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static int SelecionarAgencia()
        {
            string ArqAgencias = @"Files/Agencias.txt";
            string[] agencias = null;
            int agenciaSelecionada = 0;
            bool loop = false;

            if (File.Exists(ArqAgencias))
            {
                StreamReader sr = new StreamReader(ArqAgencias);
                string linha = sr.ReadLine();
                agencias = linha.Split(';');
            }
            else
            {
                Console.WriteLine("\n Arquivo das agências não encontrado! ");
                return 0;
            }

            do
            {
                try
                {
                    Console.WriteLine("\n Escolha uma agência \n");

                    for (int i = 0; i < agencias.Length; i++)
                    {
                        Console.WriteLine(" " + (i + 1) + ". Agência: " + agencias[i]);
                    }

                    Console.Write("\n Digite uma opção: ");
                    int opc = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (opc > 0 && opc <= agencias.Length)
                    {
                        agenciaSelecionada = int.Parse(agencias[opc - 1]);
                        loop = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n Opção inválida! \n");
                        loop = true;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Opção inválida! \n");
                    loop = true;
                }
            } while (loop);

            Console.WriteLine("\n Agência selecionada: " + agenciaSelecionada);

            return agenciaSelecionada;
        }

        static void Main(string[] args)
        {
            ImprimirNomes();
            CriarArquivos();
            int agencia = SelecionarAgencia();
            LerArquivo(ref agencia);
            Menu(ref agencia);
        }

        static void OpcMenu()
        {
            Console.WriteLine("\n\t\t CONTAS BANCARIAS    \t\t\n");

            Console.WriteLine(" 1. Criar uma nova conta");
            Console.WriteLine(" 2. Excluir conta");
            Console.WriteLine(" 3. Depositar");
            Console.WriteLine(" 4. Sacar");
            Console.WriteLine(" 5. Imprimir o extrato de uma conta ");
            Console.WriteLine(" 6. Mostrar contas cadastradas");
            Console.WriteLine(" 7. Sair do programa e salvar alterações \n");

            Console.Write(" Escolha uma opcção: ");
        }

        static void Menu(ref int agencia)
        {
            bool loop = true;

            do
            {
                try
                {
                    Console.Clear();
                    OpcMenu();
                    int opc = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (opc)
                    {
                        case 1: CriarConta(ref agencia); break;
                        case 2: ExcluirConta(); break;
                        case 3: DepositarConta(); break;
                        case 4: SacarConta(); break;
                        case 5: ExtradoConta(); break;
                        case 6: ContasCadastradas(); break;
                        case 7: SalvarArquivo(ref agencia); loop = false; break;
                        default: Console.WriteLine("\n Opção inválida! \n"); System.Threading.Thread.Sleep(300); break;
                    }
                }
                catch { Console.WriteLine("\n Opção inválida! \n"); System.Threading.Thread.Sleep(300); }
            } while (loop == true);
        }

        static void CriarConta(ref int agencia)
        {
            bool loop = false;
            byte tipoConta = 0;
            do
            {
                Console.WriteLine("\n Selecione o tipo de conta");
                Console.Write("\n 1. Conta Corrente \n 2. Conta Poupança \n\n Escolha uma opção: ");
                tipoConta = byte.Parse(Console.ReadLine());
                Console.Clear();

                switch (tipoConta)
                {
                    case 1:
                        Console.WriteLine("\n CONTA CORRENTE");
                        loop = false;
                        break;
                    case 2:
                        Console.WriteLine("\n CONTA POUPANÇA");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("\n Opção inválida! ");
                        loop = true;
                        break;
                }

            } while (loop);

            Console.Write("\n Titular da conta: ");
            string titular = Console.ReadLine();

            switch (tipoConta)
            {
                case 1:
                    ContaCorrente contaC = new ContaCorrente(titular, agencia, Cont + 1, tipoConta, 0, true);
                    vetContas[Cont] = contaC;
                    break;
                case 2:
                    ContaPoupanca contaP = new ContaPoupanca(titular, agencia, Cont + 1, tipoConta, 0, true);
                    vetContas[Cont] = contaP;
                    break;
            }

            Cont++;
            Console.Write("\n Conta Criada com sucesso! \n\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void ExcluirConta()
        {
            try
            {
                Console.Write("\n Digite o número da conta que deseja deletar: ");
                int conta = int.Parse(Console.ReadLine());

                if (conta > 0 && conta <= Cont)
                {
                    if (vetContas[conta - 1].ContaAtiva == true)
                    {
                        vetContas[conta - 1].ContaAtiva = false;
                        Console.WriteLine("\n Conta excluida com sucesso! ");
                    }
                    else { Console.WriteLine("\n Conta não encontrada"); }
                }
                else { Console.WriteLine("\n Conta não encontrada"); }
            }
            catch { Console.WriteLine("\n Digite um número de conta válido "); }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void DepositarConta()
        {
            try
            {
                Console.Write("\n Digite o número da conta para o depósito: ");
                int conta = int.Parse(Console.ReadLine());

                if (conta > 0 && conta <= Cont)
                {
                    if (vetContas[conta - 1].ContaAtiva == true)
                    {
                        Console.Write("\n Valor do depósito: ");
                        double valor = double.Parse(Console.ReadLine());

                        if (vetContas[conta - 1].Deposita(valor))
                        {
                            Console.WriteLine("\n Depósito realizado com sucesso! ");
                        }
                        else { Console.WriteLine("\n Digite um valor válido para o depósito! "); }
                    }
                    else { Console.WriteLine("\n Conta não encontrada"); }
                }
                else { Console.WriteLine("\n Conta não encontrada"); }
            }
            catch { Console.WriteLine("\n Digite um número de conta válido "); }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void SacarConta()
        {
            try
            {
                Console.Write("\n Digite o número da conta para o saque: ");
                int conta = int.Parse(Console.ReadLine());

                if (conta > 0 && conta <= Cont)
                {
                    if (vetContas[conta - 1].ContaAtiva == true)
                    {
                        Console.Write("\n Valor do saque: ");
                        double valor = double.Parse(Console.ReadLine());

                        if (vetContas[conta - 1].Saca(valor))
                        {
                            Console.WriteLine("\n Saque realizado com sucesso! ");
                        }
                        else { Console.WriteLine("\n Digite um valor válido para o saque! "); }
                    }
                    else { Console.WriteLine("\n Conta não encontrada"); }
                }
                else { Console.WriteLine("\n Conta não encontrada"); }
            }
            catch { Console.WriteLine("\n Digite um número de conta válido "); }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void ExtradoConta()
        {
            try
            {
                Console.Write("\n Digite o número da conta para imprimir o extrato: ");
                int conta = int.Parse(Console.ReadLine());

                if (conta > 0 && conta <= Cont)
                {
                    if (vetContas[conta - 1].ContaAtiva == true)
                    {
                        GeradorDeExtrato extrato = new GeradorDeExtrato();
                        extrato.GeraExtrato(vetContas[conta - 1]);
                    }
                    else { Console.WriteLine("\n Conta não encontrada"); }
                }
                else { Console.WriteLine("\n Conta não encontrada"); }
            }
            catch { Console.WriteLine("\n Digite um número de conta válido "); }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void ContasCadastradas()
        {
            Console.WriteLine();

            for (int i = 0; i < Cont; i++)
            {
                if (vetContas[i].ContaAtiva == true)
                {
                    Console.WriteLine(vetContas[i].InfoConta() + "\n");
                }
            }

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }

        static void SalvarArquivo(ref int agencia)
        {
            string caminhoArq = @"Files/Agencias/" + agencia + ".txt";

            using (StreamWriter sw = new StreamWriter(caminhoArq))
            {
                for (int i = 0; i < Cont; i++)
                {
                    sw.WriteLine(vetContas[i].EscreverArquivo());
                }
            }
            Console.WriteLine("\n Arquivo salvo com sucesso! ");

            Console.Write("\n Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
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

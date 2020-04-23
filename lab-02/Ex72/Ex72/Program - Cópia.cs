using System;
using System.IO;

namespace Ex72
{
    class Program
    {
        static float JurosP = 0.005f; // taxa de juros poupança ao mês em porcentagem
        static float Rendimento = 0.0065f; // taxa de rendimento mensal do investimento
        static float Imposto = 0.15f; // taxa de imposto mensal do investimento

        static int Cont = 0; // contador de contas cadastradas 
        static int ContAgencias = 0;  // contador de contas cadastradas em cada agência
        const int MaxContas = 100; // número máximo de contas suportado
        static Conta[] VetContas = new Conta[MaxContas]; // vetor de contas

        static int LerTodasAgencias(int[] agencias) // ler e contar número de contas de todas as agências
        {
            for (int i = 0; i < agencias.Length; i++)
            {
                string arquivoAgencias = @"Agencias\" + agencias[i] + ".txt"; // percorrer todas as agências cadastradas

                if (File.Exists(arquivoAgencias)) // verificar existência do arquivo
                {
                    using (StreamReader sr = File.OpenText(arquivoAgencias)) // instânciando StreamReader e já pasando o caminho
                    {
                        while (!sr.EndOfStream)
                        {
                            string linhas = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                            Cont++;
                        }
                    }
                }
            }

            return 0;
        }

        static void CarregarContasArquivo(int agencia) // método para ler arquivo e caregar arquivo de uma agência na memória
        {
            int contErros = 0; // contador de linhas corrompidas
            Console.WriteLine("\n Carregando dados para a memória... \n");

            string arquivoContas = @"Agencias\" + agencia + ".txt"; // nome do arquivo irá mudar de acordo com a agência selecionada

            if (File.Exists(arquivoContas)) // verificar existência do arquivo
            {
                using (StreamReader sr = File.OpenText(arquivoContas)) // instânciando StreamReader e já pasando o caminho
                {
                    while (!sr.EndOfStream)
                    {
                        string linhas = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                        var dados = linhas.Split(';'); // separar dados entre ';'
                                                       // formato dos dados Bryan Diniz;0001;1;010;3500;14/09/2019;true
                        try
                        {
                            string titular = dados[0]; // armazenando titular da conta
                            int numConta = int.Parse(dados[1]); // convertendo e armazenando número da conta
                            int tipoConta = int.Parse(dados[2]); // convertendo e armazenando o tipo da conta
                            int numAgencia = int.Parse(dados[3]); // convertendo e armazenando número da agência
                            double saldo = double.Parse(dados[4]); // convertendo e armazenando saldo da conta
                            string data = dados[5]; // armazenando data de criação da conta
                            bool contaStatus = bool.Parse(dados[6]); // convertendo e armazenando status da conta

                            if (tipoConta == 1)
                            {
                                Conta conta = new Conta(titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[Cont] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // após a adição é incrementado +1 ao contador
                            }
                            else if (tipoConta == 2)
                            {
                                Poupanca conta = new Poupanca(JurosP, titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[Cont] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // após a adição é incrementado +1 ao contador
                            }
                            else
                            {
                                Investimento conta = new Investimento(Rendimento, Imposto, titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[Cont] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // após a adição é incrementado +1 ao contador
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e);
                            contErros++;
                        }
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Arquivo não encontrado \n");
                Console.ResetColor();
            }

            Console.WriteLine(" " + ContAgencias + " contas foram carregadas ");
            Console.WriteLine(" " + contErros + " contas não foram carregadas ");
            System.Threading.Thread.Sleep(1300);
            Console.Clear();
        }

        static void AtualizarContasArquivo(int agencia)
        {
            string arquivoAgencia = @"Agencias\" + agencia + ".txt";
            StreamWriter limparArquivo = new StreamWriter(arquivoAgencia); // limpar arquivo antes de reescrever dados
            limparArquivo.Close();

            for (int i = 0; i < Cont; i++)
            {
                // armazenando todos os dados do objeto em nossa string auxiliar
                string linha = VetContas[i].Titular + ";" + VetContas[i].NumConta.ToString("D4") + ";" + VetContas[i].TipoConta + ";" + VetContas[i].Agencia.ToString("D3") + ";" + VetContas[i].Saldo.ToString("F2") + ";" + VetContas[i].Data + ";" + VetContas[i].ContaStatus;

                using (StreamWriter sw = File.AppendText(arquivoAgencia))
                {
                    sw.WriteLine(linha); // escrevendo linha a linha no arquivo de texto
                }
            }
        }

        static void Main(string[] args)
        {
            /*int[] vetor = { 10, 20, 30 };
            LerTodasAgencias(vetor);
            Console.WriteLine(Cont);
            Console.ReadKey();*/
            Menu();
        }

        static void opcsMenu() // exibir opções do menu
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\t\t CONTAS BANCARIAS    \t\t\n");
            Console.ResetColor();

            Console.WriteLine(" 1. Criar uma nova conta");
            Console.WriteLine(" 2. Excluir conta");
            Console.WriteLine(" 3. Depositar");
            Console.WriteLine(" 4. Sacar");
            Console.WriteLine(" 5. Mostrar saldo");
            Console.WriteLine(" 6. Mostrar contas cadastradas");
            Console.WriteLine(" 7. Buscar conta e mostrar informações");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n 8. Sair do programa e salvar alterações \n");
            Console.ResetColor();

            Console.Write(" Escolha uma opcção: ");
        }

        static void Menu() // método principal para chamada dos demais métodos
        {
            int agencia = Agencias();
            Console.Clear();

            CarregarContasArquivo(agencia);

            bool sair = false;

            do
            {
                Console.WriteLine("\n Agência seleionada: {0} \n", agencia);
                opcsMenu();
                char opc = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (opc)
                {
                    case '1':
                        CriarConta(agencia);
                        break;

                    case '2':
                        ExcluirConta();
                        break;

                    case '3':
                        DepositarConta();
                        break;

                    case '4':
                        SacarConta();
                        break;

                    case '5':
                        VerSaldo();
                        break;

                    case '6':
                        MostrarContas();
                        break;

                    case '7':
                        InfoConta();
                        break;

                    case '8':
                        AtualizarContasArquivo(agencia);
                        sair = true;
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Opção inválida! \n");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        break;
                }
            } while (sair == false);
        }

        static int Agencias() // método para exibir e escolher uma agência
        {
            Console.Clear();

            string arquivoAgencias = @"Agencias\AgenciasCadastradas.txt";
            int novaAgencia = 0;
            bool loop = true;
            byte opc = 0;
            int contLinhas = 0;
            string[] dados = null;

            if (File.Exists(arquivoAgencias) == false) // caso o arquivo não exista seria criado com agências pre-definidas
            {
                StreamWriter criarAgências = new StreamWriter(arquivoAgencias);
                criarAgências.Write("10");
                criarAgências.Close();
            }

            while (loop == true)
            {
                using (StreamReader sr = File.OpenText(arquivoAgencias)) // instânciando StreamReader e já pasando o caminho
                {
                    while (!sr.EndOfStream)
                    {
                        string linhas = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                        dados = linhas.Split(';');
                        contLinhas = dados.Length; // quantidade de agências presentes no arquivo
                    }
                }

                int[] agencias = new int[contLinhas]; // vetor de agências

                for (int i = 0; i < agencias.Length; i++) // salvando agências no vetor
                {
                    agencias[i] = int.Parse(dados[i]);
                }

                LerTodasAgencias(agencias); // chamar método para ler e contar todas as contas cadastradas

                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n Escolha uma agência \n");
                Console.ResetColor();

                for (int i = 0; i < dados.Length; i++)
                {
                    Console.WriteLine(" {0}. Agência: {1}", i + 1, agencias[i]);
                }

                Console.Write("\n Digite uma opção, ou 0 para cadastrar uma nova agência: ");

                try
                {
                    opc = byte.Parse(Console.ReadLine());

                    if (opc == 0)
                    {
                        Console.Write("\n Digite o número da agência para cadastra-la no sistema: ");
                        novaAgencia = int.Parse(Console.ReadLine());

                        using (StreamWriter sw = File.AppendText(arquivoAgencias))
                        {
                            sw.Write(";" + novaAgencia); // salvando agência no arquivo de texto
                        }
                    }
                    else if (opc > 0 && opc <= agencias.Length)
                    {
                        loop = false;
                        return agencias[opc - 1];
                    }
                    else
                    {
                        Console.Clear();
                        System.Threading.Thread.Sleep(100);

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Opção inválida, tente novamente\n");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(400);
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
                    System.Threading.Thread.Sleep(400);
                    loop = true;
                }
            }
            return 0;
        }

        static void CriarConta(int agencia) // método para criar uma nova conta
        {
            string Titular = "";
            string DataAtual = DateTime.Now.ToString();
            bool loop = true;
            char opc;

            do
            {
                Console.WriteLine("\n Escolha o tipo de conta \n");
                Console.WriteLine(" 1. Conta Corrente");
                Console.WriteLine(" 2. Conta Poupança");
                Console.WriteLine(" 3. Conta Investimento");
                Console.Write("\n Escolha uma opcção: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case '1':
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\t\t\tCriar Conta Corrente\t\t\t\t");
                        Console.ResetColor();

                        loop = false;
                        break;

                    case '2':
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\t\t\tCriar Conta Poupança\t\t\t\t");
                        Console.ResetColor();

                        loop = false;
                        break;

                    case '3':
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\t\t\tCriar Conta Investimento\t\t\t");
                        Console.ResetColor();

                        loop = false;
                        break;

                    default:
                        Console.Clear();
                        System.Threading.Thread.Sleep(100);

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Opção inválida, tente novamente\n");
                        Console.ResetColor();
                        loop = true;
                        break;
                }
            } while (loop == true);

            do
            {
                Console.Write("\n Digite o nome completo do titular da conta: ");
                Titular = Console.ReadLine();

                if (ValidarNome(Titular) == false)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Digite um nome válido! \n");
                    Console.ResetColor();
                    loop = true;
                }
                else
                {
                    loop = false;
                }

            } while (loop == true);

            switch (opc)
            {
                case '1':
                    Conta contaC = new Conta(Titular, Cont + 1, 1, agencia, 0, DataAtual, true);
                    VetContas[ContAgencias] = contaC;
                    ContAgencias++;
                    Cont++;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Conta Corrente criada com sucesso! \n");
                    Console.ResetColor();
                    break;

                case '2':
                    Poupanca contaP = new Poupanca(JurosP, Titular, Cont + 1, 2, agencia, 0, DataAtual, true);
                    VetContas[ContAgencias] = contaP;
                    ContAgencias++;
                    Cont++;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Conta Poupança criada com sucesso! \n");
                    Console.ResetColor();
                    break;

                case '3':
                    Investimento contaI = new Investimento(Rendimento, Imposto, Titular, Cont + 1, 3, agencia, 0, DataAtual, true);
                    VetContas[ContAgencias] = contaI;
                    ContAgencias++;
                    Cont++;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Conta Investimento criada com sucesso! \n");
                    Console.ResetColor();
                    break;
            }
            System.Threading.Thread.Sleep(600);
            Console.Clear();
        }

        static bool ValidarNome(string nome) // método para validar nome
        {
            bool nomeValido = true;

            if (nome.Length > 3)
            {
                for (int i = 0; i < nome.Length; i++)
                {
                    // A = 65 Z = 90 | a = 97 z = 122 | espaço em branco = 32;
                    if (((nome[i] >= 65 && nome[i] <= 90) || (nome[i] >= 97 && nome[i] <= 122)) || (nome[i] == 32))
                    {
                        nomeValido = true;
                    }
                    else
                    {
                        nomeValido = false;
                        break;
                    }
                }
            }
            else
            {
                nomeValido = false;
            }

            return nomeValido;

        }

        public static int ValidarNumConta() // método para validar um número de uma pessoa
        {
            int numero = 0;
            Console.Write("\n Digite o número da conta: ");

            try
            {
                numero = int.Parse(Console.ReadLine());
            }
            catch
            {
                numero = 0;
            }

            if (numero > 0 && numero <= Cont)
            {
                if (VetContas[numero - 1].ContaStatus == false)
                {
                    numero = 0;
                }
            }
            else
            {
                numero = 0;
            }

            return numero;
        }

        static void ExcluirConta()// excluir uma conta específica
        {
            int numero = ValidarNumConta();

            if (numero != 0)
            {
                VetContas[numero - 1].ContaStatus = false;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n A conta de número {0} do titular {1} foi excluída com sucesso \n", VetContas[numero - 1].NumConta.ToString("D4"), VetContas[numero - 1].Titular);
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Conta não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DepositarConta() // fazer depósito em uma conta específica
        {
            int numero = ValidarNumConta();
            Console.Clear();

            double valor = 0;

            if (numero != 0)
            {
                Console.WriteLine("\n CONTA SELECIONADA \n");
                Console.WriteLine(VetContas[numero - 1]);

                Console.Write(" Digite um valor para o depóito: R$");
                try
                {
                    valor = double.Parse(Console.ReadLine());
                }
                catch
                {
                    valor = 0;
                }

                if (VetContas[numero - 1].Deposita(valor) == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Depósito realizado com sucesso ! \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Valor de depósito inválido! \n");
                    Console.ResetColor();
                }

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Conta não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void SacarConta() // fazer saque em uma conta específica
        {
            int numero = ValidarNumConta();
            Console.Clear();

            double valor = 0;

            if (numero != 0)
            {
                Console.WriteLine("\n CONTA SELECIONADA \n");
                Console.WriteLine(VetContas[numero - 1]);

                Console.Write(" Digite um valor para o saque: R$");
                try
                {
                    valor = double.Parse(Console.ReadLine());
                }
                catch
                {
                    valor = 0;
                }

                if (VetContas[numero - 1].Retira(valor) == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Saque realizado com sucesso ! \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Valor de saque inválido, ou saldo insuficiênte! \n");
                    Console.ResetColor();
                }

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Conta não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void VerSaldo() // mostrar saldo de uma conta específica
        {
            int numero = ValidarNumConta();
            Console.Clear();

            if (numero != 0)
            {
                Console.Write("\n O saldo da conta {0} do titular {1} é: R${2}", VetContas[numero - 1].NumConta, VetContas[numero - 1].Titular, VetContas[numero - 1].Saldo.ToString("F2"));
                Console.WriteLine();

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Conta não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void MostrarContas() // mostrar informaões de todas as contas cadastradas
        {
            Console.WriteLine("\n CONTAS ATIVAS \n");
            for (int i = 0; i < Cont; i++)
            {
                if (VetContas[i].ContaStatus == true)
                {
                    Console.WriteLine(" " + (i + 1) + "°\n" + VetContas[i]);
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void InfoConta() // mostrar informações de uma conta específica
        {
            int numero = ValidarNumConta();
            Console.Clear();

            if (numero != 0)
            {
                Console.Write(VetContas[numero - 1]);
                Console.WriteLine();

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Conta não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}

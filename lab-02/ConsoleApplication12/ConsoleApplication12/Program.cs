using System;
using System.IO;

namespace Ex72
{
    class Program
    {
        const float JurosP = 0.005f; // taxa de juros mensal poupança
        const float Rendimento = 0.0065f; // taxa de rendimento mensal do investimento
        const float Imposto = 0.15f; // taxa de imposto mensal do investimento

        static int Cont = ContarContas(); // contador de contas cadastradas 
        static int ContAgencias = 0;  // contador de contas cadastradas na agência selecionada
        const int MaxContas = 100; // número máximo de contas suportado
        static Conta[] VetContas = new Conta[MaxContas]; // vetor de contas

        static int ContarContas() // método para contar e retornar número de contas cadastradas
        {
            // diretório do arquivo para armazenar número de contas cadastradas
            string arquivoContador = @"ContadorDeContas.txt";
            int contador = 0;

            if (File.Exists(arquivoContador)) // verificar existência do arquivo
            {
                using (StreamReader sr = File.OpenText(arquivoContador)) // instânciando StreamReader e abrindo arquivoContador
                {
                    string linha = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                    contador = int.Parse(linha);
                }
            }
            else // caso o arquivo não existir
            {
                using (StreamWriter criarArquivoCont = new StreamWriter(arquivoContador))
                {
                    criarArquivoCont.WriteLine(0); // cria um arquivo e escrever 0
                }
                return 0; // retorna 0 por que não encontrou arquivo
            }
            return contador;
        }

        static void CarregarContasArquivo(int agencia) // método para ler arquivo e caregar arquivo de uma agência na memória
        {
            int contErros = 0; // contador de linhas corrompidas
            string arquivoContas = @"Agencias\" + agencia + ".txt"; // nome do arquivo irá mudar de acordo com a agência selecionada

            Console.WriteLine("\n Carregando dados para a memória... \n");
            if (File.Exists(arquivoContas)) // verificar existência do arquivo
            {
                using (StreamReader sr = File.OpenText(arquivoContas)) // instânciando StreamReader e já pasando o caminho
                {
                    while (!sr.EndOfStream)
                    {
                        string linhas = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                        var dados = linhas.Split(';'); // separar dados entre ';'
                                                       // formato dos dados Bryan Diniz;0001;1;010;3500;14/09/2019;true
                                                       // 1. Titular 2. Num conta 3. Tipo 4. Agência 5. Saldo 6. Data de criação 7. Status da conta (estar ou não ativa)
                                                       //
                        try
                        {
                            string titular = dados[0]; // armazenando titular da conta
                            int numConta = int.Parse(dados[1]); // convertendo e armazenando número da conta
                            int tipoConta = int.Parse(dados[2]); // convertendo e armazenando o tipo da conta
                            int numAgencia = int.Parse(dados[3]); // convertendo e armazenando número da agência
                            double saldo = double.Parse(dados[4]); // convertendo e armazenando saldo da conta
                            DateTime data = Convert.ToDateTime(dados[5]); // armazenando data de criação da conta
                            bool contaStatus = bool.Parse(dados[6]); // convertendo e armazenando status da conta

                            if (tipoConta == 1) // se a conta for do tipo 1 = corrente
                            {
                                Conta conta = new Conta(titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[ContAgencias] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // incrementado +1 ao contador de contas da agência atual
                            }
                            else if (tipoConta == 2) // se a conta for do tipo 2 = Poupança
                            {
                                Poupanca conta = new Poupanca(JurosP, titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[ContAgencias] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // incrementado +1 ao contador de contas da agência atual
                            }
                            else  // se a conta for do tipo 3 = Investimento
                            {
                                Investimento conta = new Investimento(Rendimento, Imposto, titular, numConta, tipoConta, numAgencia, saldo, data, contaStatus); // instânciar objeto pessoa
                                VetContas[ContAgencias] = conta; // adicionando pessoa a vetor
                                ContAgencias++; // incrementado +1 ao contador de contas da agência atual
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

        static void AtualizarArquivos(int agencia) // método para atualizar arquivos antes de sair do programa
        {
            string arquivoContador = @"ContadorDeContas.txt"; // aqruivo para fazer contagem de contas
            string arquivoAgencia = @"Agencias\" + agencia + ".txt"; // arquivo específico de uma agência

            using (StreamWriter sw = new StreamWriter(arquivoContador))  // atualizar arquivo contador de contas
            {
                sw.WriteLine(Cont);
            }

            StreamWriter limparArquivo = new StreamWriter(arquivoAgencia); // limpar arquivo antes de reescrever dados
            limparArquivo.Close();

            for (int i = 0; i < ContAgencias; i++) // reescrever todos os dados do VetContas
            {
                // armazenando todos os dados do objeto em nossa string auxiliar
                string linha = VetContas[i].Titular + ";" + VetContas[i].NumConta.ToString("D4") + ";" + VetContas[i].TipoConta + ";" + VetContas[i].Agencia.ToString("D3") + ";" + VetContas[i].Saldo.ToString("F2") + ";" + VetContas[i].Data + ";" + VetContas[i].ContaStatus + ";";

                using (StreamWriter sw = File.AppendText(arquivoAgencia))
                {
                    sw.WriteLine(linha); // escrevendo linha a linha no arquivo de texto
                }
            }
        }

        static void Main(string[] args)
        {
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
            bool sair = false; // boolean para definir encerramento ou não do programa
            int agencia = Agencias(); // obter número de agência selecionada pelo usuário
            Console.Clear();
            CarregarContasArquivo(agencia); // ao receber número de agência escolhido pelo usuário será carregado os dados para a memória

            do
            {
                Console.WriteLine("\n Agência seleionada: {0} \n", agencia); // exibir agência selecionada
                opcsMenu(); // método para printar opções do menu
                char opc = Console.ReadKey().KeyChar; // armazenar opção do usuário
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
                        AtualizarArquivos(agencia);
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

        /* static int Agencias() // método para exibir e escolher uma agência
         {
             Console.Clear();

             string pastaAgencias = "Agencias"; //nome do diretorio a ser criado

             //Se o diretório não existir...

             if (!Directory.Exists(pastaAgencias))
             {
                 //Criamos um com o nome Agencias
                 Directory.CreateDirectory(pastaAgencias);

             }

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

                 // LerTodasAgencias(agencias); // chamar método para ler e contar todas as contas cadastradas

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
         */
        static int Agencias() // método para exibir e escolher uma agência
        {
            Console.Clear();

            int quantAgencias = 0; // armazenar quantidade de agências
            string[] dados = null;

            string pastaAgencias = "Agencias"; //nome do diretorio a ser criado

            if (!Directory.Exists("Agencias")) //Se o diretório não existir...
            {
                //Criamos um com o nome Agencias
                Directory.CreateDirectory(pastaAgencias);
            }

            string arquivoAgencias = @"Agencias\AgenciasCadastradas.txt";

            // caso o arquivo não exista será criado um com a agência 10 como padrão
            if (File.Exists(arquivoAgencias) == false)
            {
                using (StreamWriter criarAgências = new StreamWriter(arquivoAgencias))
                {
                    criarAgências.Write("10");
                }
            }

            bool loop = true; // manter ou não loop
            while (loop == true)
            {
                try
                {
                    // StreamReader para ler arquivo com número das agências
                    using (StreamReader sr = File.OpenText(arquivoAgencias))
                    {
                        while (!sr.EndOfStream) // enaqunto não chegar ao fim do arquivo
                        {
                            string linhas = sr.ReadLine(); // armazenando conteúdo lido de cada linha do arquivo
                            dados = linhas.Split(';');
                            quantAgencias = dados.Length; // quantidade de agências presentes no arquivo
                        }
                    }


                    int[] agencias = new int[quantAgencias]; // vetor de agências

                    for (int i = 0; i < agencias.Length; i++) // salvando agências no vetor
                    {
                        agencias[i] = int.Parse(dados[i]);
                    }


                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n Escolha uma agência \n");
                    Console.ResetColor();

                    for (int i = 0; i < dados.Length; i++) // exibir agências cadastradas
                    {
                        Console.WriteLine(" {0}. Agência: {1}", i + 1, agencias[i]);
                    }

                    Console.Write("\n Digite uma opção, -1 para apagar, ou 0 para cadastrar uma nova agência: ");
                    int opc = int.Parse(Console.ReadLine());

                    if (opc > 0 && opc <= agencias.Length) // se opção for igual a alguma agência
                    {
                        return agencias[opc - 1]; // retornar número da agência selecionada
                    }
                    else if (opc == 0) // cadastrar uma nova agência no sistema
                    {
                        Console.Write("\n Digite o número da agência para cadastra-la no sistema: ");
                        int novaAgencia = int.Parse(Console.ReadLine());

                        using (StreamWriter sw = File.AppendText(arquivoAgencias))
                        {
                            sw.Write(";" + novaAgencia); // salvando número da agência no arquivo de texto
                        }
                    }
                    else if(opc == -1)
                    {
                        Console.Clear();
                        for (int i = 0; i < dados.Length; i++) // exibir agências cadastradas
                        {
                            Console.WriteLine(" {0}. Agência: {1}", i + 1, agencias[i]);
                        }
                        Console.Write("Digite um número para apagar: ");
                        byte apagar = byte.Parse(Console.ReadLine());
                        int[] novaAgencias = new int[agencias.Length];
                        for (int i = 0; i < agencias.Length; i++)
                        {
                            if (agencias[i] != apagar)
                            {
                                novaAgencias[i] = agencias[i];
                            }
                        }
                        using (StreamWriter criarAgências = new StreamWriter(arquivoAgencias))
                        {
                            criarAgências.Write("");
                        }
                        for (int i = 0; i < novaAgencias.Length; i++)
                        {

                            using (StreamWriter sw = File.AppendText(arquivoAgencias))
                            {
                                sw.Write(";" + novaAgencias[i]); // salvando número da agência no arquivo de texto
                            }
                        }
                        
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
            string Titular = ""; // armazenar nome do titular da conta
            DateTime DataAtual = DateTime.Now; // pegar data do momento da criação da conta
            bool loop = true;
            char opc; // armazenar opção escolhida pelo usuário

            do
            {
                Console.WriteLine("\n Escolha o tipo de conta \n");
                Console.WriteLine(" 1. Conta Corrente");
                Console.WriteLine(" 2. Conta Poupança");
                Console.WriteLine(" 3. Conta Investimento");
                Console.Write("\n Escolha uma opcção: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc) // exibir opção escolhida pelo usuário
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

            switch (opc) // de acordo com a opção escolhida acima os dados serão destinados a um objeto específico
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

        static bool ValidarNome(string nome) // método para validar um nome
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

        public static int ValidarNumConta() // método para validar um número de uma pessoa retornando 0 se não encontrar conta
        {
            int numero = 0;
            int retorno = 0;
            try
            {
                Console.Write("\n Digite o número da conta: ");
                numero = int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }

            if (numero > 0) // se o número estiver entre a quantidade de contas cadastradas
            {
                for (int i = 0; i < ContAgencias; i++)
                {
                    if ((VetContas[i].NumConta == numero) && (VetContas[i].ContaStatus == true))
                    {
                        return i + 1; // retornar a posição +1 para evitar ser = 0
                    }
                    else
                    {
                        retorno = 0;
                    }
                }
            }
            else
            {
                return 0;
            }
            return retorno;
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
            double valor = 0;

            if (numero != 0)
            {
                Console.WriteLine("\n CONTA SELECIONADA \n");
                Console.WriteLine(VetContas[numero - 1]);

                try
                {
                    Console.Write(" Digite um valor para o depóito: R$");
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
            Console.WriteLine("\n CONTAS ATIVAS NA AGÊNCIA ATUAL \n");
            for (int i = 0; i < ContAgencias; i++)
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

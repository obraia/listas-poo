//
// nome do programa: Ex12 Impsoto de Renda
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 20/10/2019
// entrada(s): 
// saida(s): 
// para executar  e testar digite: Ex12.exe
// descricao: adicionar e remover contribuintes a um sistema que irá calcular o imposto de renda
// de acorodo com a classificação do contribuinte, pessoa física ou jurídica, e irá salvar todas
// as informações em um arquivo de texto
//

using System;
using System.IO;

namespace Ex12
{
    class Program
    {
        static string pathContribuintes = @"Files/Contribuintes.txt";

        static void CarregarArquivo()
        {
            if (File.Exists(pathContribuintes))
            {
                using (StreamReader sr = new StreamReader(pathContribuintes))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] aux = linha.Split(',');
                        string tipo = aux[0]; // PF/PJ
                        string id = aux[1]; // CPF/CNPJ
                        string nome = aux[2];
                        string endereco = aux[3];
                        bool contribuinteStatus = bool.Parse(aux[4]);
                        double faturamento = double.Parse(aux[5]);

                        if (tipo == "PF")
                        {
                            PFisica pFisica = new PFisica(nome, id, endereco, faturamento, true, contribuinteStatus);
                            Contribuinte.AddContribuinte(pFisica);
                        }
                        else
                        {
                            PJuridica pJuridica = new PJuridica(nome, id, endereco, faturamento, false, contribuinteStatus);
                            Contribuinte.AddContribuinte(pJuridica);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Arquivo " + pathContribuintes + " não encontrado! \n");
                Directory.CreateDirectory("Files");
                File.Open(pathContribuintes, FileMode.Create);
                System.Threading.Thread.Sleep(800);
                Console.Clear();
            }

            Console.WriteLine("\n Contribuintes carregados: " + Contribuinte.Cont + " \n");
            System.Threading.Thread.Sleep(800);
            Console.Clear();
        }

        static void AtualizarArquivo()
        {
            if (File.Exists(pathContribuintes))
            {
                StreamWriter limpar = new StreamWriter(pathContribuintes);
                limpar.Close();

                for (int i = 0; i < Contribuinte.Cont; i++)
                {
                    using (StreamWriter sr = File.AppendText(pathContribuintes))
                    {
                        sr.WriteLine(Contribuinte.VetContribuintes[i].EscreverArquivo());
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Arquivo " + pathContribuintes + " não encontrado! \n");
            }
        }

        static void Main(string[] args)
        {
            ImprimirNomes();
            CarregarArquivo();
            Menu();
        }

        static void OpcMenu() // método para imprimir opções do menu
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\n \tCADASTRO DE CONTRIBUINTES IMPOSTO DE RENDA\t \n");

            Console.ResetColor();

            Console.WriteLine(" 1. Incluir um contribuinte ");
            Console.WriteLine(" 2. Excluir um contribuinte ");
            Console.WriteLine(" 3. Exibir os dados de um contribuinte ");
            Console.WriteLine(" 4. Exibir o imposto a ser pago por um contribuinte ");
            Console.WriteLine(" 5. Mostrar dados Pessoa Física ");
            Console.WriteLine(" 6. Mostrar dados Pessoa Jurídica ");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n 7. Sair do programa e salvar alterações ");

            Console.ResetColor();

            Console.Write("\n Digite uma opção: ");
        }

        static void Menu()
        {
            bool sair = false; // boolean para definir fechamento do programa

            do
            {
                sair = false;
                try
                {
                    Console.Clear();

                    OpcMenu(); // chamar método para imprimir opções do menu
                    byte opc = byte.Parse(Console.ReadLine()); // obter opção do usuário

                    Console.Clear();

                    switch (opc)
                    {
                        case 1:
                            CadastrarContribuinte();
                            break;

                        case 2:
                            ExcluirContribuinte();
                            break;

                        case 3:
                            ExibirDadosContribuinte();
                            break;

                        case 4:
                            ImpostoContribuinte();
                            break;

                        case 5:
                            Console.WriteLine("\n Contribuintes Pessoa Física \n");
                            Contribuinte.InfoTodosContribuintes(true); // método static classe Contribuinte, true para parâmetro pessoa física
                            Console.ReadKey();

                            break;

                        case 6:
                            Console.WriteLine("\n Contribuintes Pessoa Jurídica \n");
                            Contribuinte.InfoTodosContribuintes(false); // método static classe Contribuinte, false para parâmetro pessoa física
                            Console.ReadKey();
                            break;

                        case 7:
                            AtualizarArquivo();
                            sair = true;
                            break;

                        default:
                            System.Threading.Thread.Sleep(100);

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("\n Opção inválida! \n");

                            Console.ResetColor();

                            System.Threading.Thread.Sleep(600);
                            sair = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    System.Threading.Thread.Sleep(100);

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Opção inválida! \n");

                    Console.ResetColor();

                    System.Threading.Thread.Sleep(600);
                    sair = false;
                }

            } while (sair == false);
        }// iniciar operações de acordo com escolha do usuário

        static void CadastrarContribuinte() // método para cadastrar um contribuinte
        {
            PJuridica pjuridica; // objeto para pessoa jurídica
            PFisica pfisica; // objeto para pessoa física

            bool loop = true;
            string nome = ""; // armazenar nome do contribuinte
            string id = ""; // armazenar CPF/CNPJ do contribuinte
            string endereco = ""; // armazenar endereço do contribuinte
            double renda = 0; // armazenar salário/faturamento do contribuinte
            byte opc = 0; // armazenar opção digitada pelo usuário

            while (loop == true)
            {
                Console.Clear();

                try // tratar exeção da opção do usuário
                {
                    Console.WriteLine("\n O contribuinte é: \n");
                    Console.WriteLine(" 1. Pessoa física ");
                    Console.WriteLine(" 2. Pessoa Jurídica ");

                    Console.Write("\n Digite uma opção: ");
                    opc = byte.Parse(Console.ReadLine()); // obter opção do usuário

                    Console.Clear();

                    Console.WriteLine("\n Para cadastrar um contribuinte: ");

                    if (opc == 1) // cadastrar pessoa física
                    {
                        Console.Write("\n Digite o CPF do contribuinte: ");
                        id = Console.ReadLine(); // obter CPF do contribuinte digitado pelo usuário
                        loop = false;
                    }
                    else if (opc == 2) // cadastrar pessoa jurídica
                    {
                        Console.Write("\n Digite o CNPJ do contribuinte: ");
                        id = Console.ReadLine(); // obter CNPJ do contribuinte digitado pelo usuário
                        loop = false;
                    }
                    else
                    {
                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\n Opção inválida! \n");

                        Console.ResetColor();

                        System.Threading.Thread.Sleep(280);
                        loop = true;
                    }
                }
                catch
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Opção inválida! \n");

                    Console.ResetColor();

                    System.Threading.Thread.Sleep(280);
                    loop = true;
                }
            }

            loop = true; // voltar a valor padrão para próximo while

            Console.Write("\n Digite o nome do contribuinte: ");
            nome = Console.ReadLine(); // obter nome do contribuinte digitado pelo usuário (sem tratamentos)

            while (loop == true)
            {
                try
                {
                    Console.Write("\n Digite a renda do contribuinte: ");
                    renda = double.Parse(Console.ReadLine()); // obter renda do contribuinte digitado pelo usuário
                    loop = false;

                    if (renda < 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\n Valor de renda inválida, digite valores não negativos ");

                        Console.ResetColor();

                        loop = true;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Valor de renda inválida, digite apenas números ");

                    Console.ResetColor();

                    loop = true;
                }
            }

            Console.Write("\n Digite o endereço do contribuinte: ");
            endereco = Console.ReadLine(); // obter endereço do contribuinte digitado pelo usuário (sem tratamentos)

            Console.Clear();

            if (opc == 1) // cadastrar pessoa física
            {
                pfisica = new PFisica(nome, id, endereco, renda, true, true); // instânciando objeto com parâmetros digitados acima

                if (Contribuinte.AddContribuinte(pfisica) == true) // método para adicionar objeto pfisica ao vetor
                {

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\n Pessoa física cadastrada com sucesso! ");

                    Console.ResetColor();

                }
                else // caso o número máximo de cadastros for atingido
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Número máximo de contribuintes atingido! \n");

                    Console.ResetColor();
                }
            }
            else if (opc == 2) // cadastrar pessoa jurídica
            {
                pjuridica = new PJuridica(nome, id, endereco, renda, false, true); // instânciando objeto com parâmetros digitados acima

                if (Contribuinte.AddContribuinte(pjuridica) == true)
                {

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\n Pessoa jurídica cadastrada com sucesso! ");

                    Console.ResetColor();

                }
                else // caso o número máximo de cadastros for atingido
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Número máximo de contribuintes atingido! \n");

                    Console.ResetColor();
                }
            }

            Console.ReadKey();
        }

        static void ExcluirContribuinte() // inserir dados para deletar um contribuinte
        {
            int numInscricao = 0;

            try
            {
                Console.WriteLine("\n Para deletar um contribuinte: \n");

                Console.Write(" Digite o número de inscrição: ");
                numInscricao = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();

                if (Contribuinte.ExcluirContribuinte(numInscricao) == true) // método para excluir contribuinte de acordo com número de inscrição
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\n Conta removida com sucesso! \n");

                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Número de inscrição não encontrado! \n");

                    Console.ResetColor();
                }
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n Número de inscrição inválido, digite apenas números \n");

                Console.ResetColor();
            }

            Console.ReadKey();
        }

        static void ExibirDadosContribuinte() // inserir dados para exibir um contribuinte
        {
            int numInscricao = 0;

            try
            {
                Console.WriteLine("\n Para exibir informações de um contribuinte: \n");

                Console.Write(" Digite o número de inscrição: ");
                numInscricao = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();

                if (Contribuinte.ExibirDadosContribuinte(numInscricao) == false) // exibir contribuinte de acordo com número de inscrição
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Número de inscrição não encontrado! \n");

                    Console.ResetColor();
                }
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n Número de inscrição inválido, digite apenas números \n");

                Console.ResetColor();
            }

            Console.ReadKey();
        }

        static void ImpostoContribuinte() // inserir dados para exibir quantidade de imposto pago pelo contribuinte
        {
            int numInscricao = 0;

            try
            {
                Console.WriteLine("\n Para calcular e exibir o imposto a ser pago por um contribuinte: \n");

                Console.Write(" Digite o número de inscrição: ");
                numInscricao = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();

                if (Contribuinte.ImpostoContribuinte(numInscricao) == false) // método para mostrar imposto pago pelo ou retornar false se número de inscrição for inválido
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Número de inscrição não encontrado! \n");

                    Console.ResetColor();
                }
            }
            catch
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n Número de inscrição inválido, digite apenas números \n");

                Console.ResetColor();
            }

            Console.ReadKey();
        }

        static void ImprimirNomes() // métodos para imprimir nomes na tela
        {
            Console.Clear();
            Console.WriteLine("\n Integrantes: \n");
            Console.WriteLine(" 652813 - Bryan Diniz Rodrigues ");
            Console.WriteLine(" 664469 - Luiz Henrique Gomes Guimarães ");
            Console.WriteLine(" 668579 - Thais Barcelos Lorentz ");
            Console.Write("\n Pressione qualquer tecla para continuar ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

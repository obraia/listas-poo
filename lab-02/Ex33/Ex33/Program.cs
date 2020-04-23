using System;

namespace Ex33
{
    class Program
    {
        static byte Cont = 0; // contador de contas cadastradas
        const int MAXPESSOAS = 100; // número máximo de pessoas suportado
        static Pessoa[] vetPessoas = new Pessoa[MAXPESSOAS]; // vetor de pessoas

        static void Main(string[] args)
        {
            Menu();
        }

        static void OpcsMenu() // mostrar opções do menu
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\t\t     Calculadora de IMC      \t\t\t");

            Console.ResetColor();

            Console.WriteLine("\n 1. Incluir uma nova pessoa. ");
            Console.WriteLine(" 2. Alterar a data de nascimento de uma pessoa cadastrada. ");
            Console.WriteLine(" 3. Alterar o peso de uma pessoa cadastrada. ");
            Console.WriteLine(" 4. Alterar a altura de uma pessoa cadastrada ");
            Console.WriteLine(" 5. Informar a idade atual de uma pessoa cadastrada. ");
            Console.WriteLine(" 6. Informar IMC de uma pessoa cadastrada. ");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n 7. Sair do programa ");

            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("\n\t\t\t\t\t\t\t\t");

            Console.ResetColor();

            Console.Write("\n Digite um opção: ");
        }

        static void Menu() // menu principal do programa
        {
            bool sair = false;

            do
            {
                Console.Clear();
                OpcsMenu();
                try
                {
                    byte opc = byte.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 0:
                            Console.Clear();
                            MostrarPessoas();
                            Console.ReadLine();
                            break;

                        case 1:
                            Console.Clear();
                            CadastrarPessoa();
                            break;

                        case 2:
                            Console.Clear();
                            AlterarDataNascimento();
                            break;

                        case 3:
                            Console.Clear();
                            AlterarPeso();
                            break;

                        case 4:
                            Console.Clear();
                            AlterarAltura();
                            break;

                        case 5:
                            Console.Clear();
                            MostrarIdade();
                            break;

                        case 6:
                            Console.Clear();
                            MostrarIMC();
                            break;

                        case 7:
                            sair = true;
                            break;

                        default:

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n Opção inválida! ");
                            Console.ResetColor();

                            Console.ReadKey();

                            break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Opção inválida! ");
                    Console.ResetColor();

                    Console.ReadKey();
                }
            } while (sair == false);
        }

        static void MostrarPessoas()
        {
            Console.WriteLine();
            for (int i = 0; i < Cont; i++)
            {
                Console.WriteLine(i + 1 + "°" + vetPessoas[i]);
                Console.WriteLine();
            }
        }

        static void CadastrarPessoa() // método para inserir dados de uma pessoa
        {
            bool loop = true;
            string dataNasc = "";
            float peso = 0;
            float altura = 0;

            bool dataValida = false;
            bool alturaValida = false;
            bool pesoValido = false;

            while (loop == true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("\n Para cadastrar uma nova pessoa \n");

                    Console.Write("\n Digite a data de nascimento no formato dd/mm/aaaa: ");
                    dataNasc = Console.ReadLine();

                    Console.Write("\n Digite o peso em Kg: ");
                    peso = float.Parse(Console.ReadLine());

                    Console.Write("\n Digite a altura em metros: ");
                    altura = float.Parse(Console.ReadLine());

                    Console.WriteLine();

                    dataValida = ValidarData(dataNasc);
                    alturaValida = ValidarAltura(altura);
                    pesoValido = ValidarPeso(peso);

                    if (dataValida == true && alturaValida == true && pesoValido == true)
                    {
                        loop = false;
                    }
                    else
                    {
                        loop = true;
                        Console.ReadLine();
                    }
                }
                catch
                {
                    loop = true;

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Parâmetro inválido! ");

                    Console.ResetColor();

                    Console.ReadKey();
                }
            }

            Pessoa pessoa = new Pessoa(dataNasc, peso, altura); // instânciar objeto pessoa

            if (Cont <= MAXPESSOAS)
            {
                vetPessoas[Cont] = pessoa;
                Cont++;

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n Pessoa cadastrada com sucesso! ");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Número máximo de cadastros atingido ");
                Console.ResetColor();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public static int ValidarPessoa() // método para validar um número de uma pessoa
        {
            Console.Write("\n Digite o número da pessoa: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero > 0 && numero <= Cont)
            {
                Console.Clear();
                Console.WriteLine("\n " + numero + "° - pessoa selecionada \n");
                System.Threading.Thread.Sleep(500);
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Pessoa não encontrada, tente novamente ");
                Console.ResetColor();

                Console.ReadKey();
                numero = 0;
            }

            return numero;
        }

        static void AlterarDataNascimento() // método para alterar data de nascimento
        {
            int numero = ValidarPessoa();
            String data = "";
            bool loop = true;

            if (numero != 0)
            {
                while (loop == true)
                {
                    Console.Clear();
                    Console.Write("\n Digite a nova data no formato dd/mm/aaa: ");
                    data = Console.ReadLine();

                    if (ValidarData(data) == true)
                    {
                        loop = false;
                        vetPessoas[numero - 1].DataNascimento = data;

                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine("\n Data alterada com sucesso! ");

                        Console.ResetColor();

                        Console.ReadKey();
                    }
                    else
                    {
                        loop = true;

                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\n Data inválida, tente novamente ");

                        Console.ResetColor();

                        Console.ReadKey();
                    }
                }
            }
        }

        static void AlterarPeso() // método para alterar peso de uma pessoa
        {
            int numero = ValidarPessoa();
            float peso = 0;
            bool loop = true;

            if (numero != 0)
            {
                while (loop == true)
                {
                    try
                    {
                        Console.Clear();

                        Console.Write("\n Digite o novo peso em Kg: ");

                        peso = float.Parse(Console.ReadLine());

                        if (ValidarPeso(peso) == true)
                        {

                            loop = false;
                            Console.Clear();
                            vetPessoas[numero - 1].Peso = peso;

                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\n Peso alterado com sucesso! ");
                            Console.ResetColor();

                            Console.ReadKey();
                        }
                        else
                        {
                            loop = true;

                            Console.Clear();

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n Peso inválido, tente novamente ");
                            Console.ResetColor();

                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    catch
                    {
                        loop = true;

                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Peso inválido, tente novamente ");
                        Console.ResetColor();

                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        static void AlterarAltura() // método para alterar altura de uma pessoa
        {
            int numero = ValidarPessoa();
            float altura = 0;
            bool loop = true;

            if (numero != 0)
            {
                while (loop == true)
                {
                    try
                    {
                        Console.Clear();

                        Console.Write("\n Digite a nova altura em metros: ");
                        altura = float.Parse(Console.ReadLine());

                        if (ValidarAltura(altura) == true)
                        {
                            loop = false;
                            Console.Clear();
                            vetPessoas[numero - 1].Altura = altura;

                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\n Altura alterada com sucesso! ");
                            Console.ResetColor();

                            Console.ReadKey();
                        }
                        else
                        {
                            loop = true;

                            Console.Clear();

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n Altura inválida, tente novamente");
                            Console.ResetColor();

                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    catch
                    {
                        loop = true;

                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Altura inválida, tente novamente");
                        Console.ResetColor();

                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        static void MostrarIdade() // método para inserir dados e mostrar a idade com base em um nome
        {
            int numero = ValidarPessoa();

            if (numero != 0)
            {
                Console.Clear();

                Console.WriteLine("\n {0}° pessoa tem {1} anos de idade", numero, DateInfo.Idade(vetPessoas[numero - 1].DataNascimento));
            }
            Console.ReadKey();
        }

        static void MostrarIMC() // método para inserir dados para mostrar IMC de acordo com um nome
        {
            int numero = ValidarPessoa();

            if (numero != 0)
            {
                vetPessoas[numero - 1].IMC();
                Console.Clear();
                Console.WriteLine("\n {0}° pessoa tem {1} de IMC", numero, vetPessoas[numero - 1].IMC());
            }
            Console.ReadKey();
        }

        static bool ValidarData(String data) // método para validar um data usando nossa classe DateInfo
        {
            bool dataValida = false;

            if (DateInfo.ValidDate(data))
            {
                dataValida = true;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Data inválida! \n");

                Console.ResetColor();
            }
            return dataValida;
        }

        static bool ValidarPeso(float peso) // método para validar peso
        {
            bool pesoValido = false;

            if (peso > 0)
            {
                pesoValido = true;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Peso inválido! \n");

                Console.ResetColor();
            }
            return pesoValido;
        }

        static bool ValidarAltura(float altura) // método para validar altura
        {
            bool alturaValida = false;

            if (altura > 0 && altura < 3)
            {
                alturaValida = true;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Altura inválida! \n");
                Console.ResetColor();
            }
            return alturaValida;
        }
    }
}

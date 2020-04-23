//
// nome do programa:  Ex57
//
// programador(es): Bryan Diniz
// data: 09/08/2019
// entrada(s): nome da conta, valor inicial, valor de deposito e valor de saque
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): de acordo com opcoes escolhidas nos menus
// para executar  e testar digite: Ex57.exe
// descricao:um programa para execultar operacoes basicas em uma conta bancaria
//

using System;
using System.Globalization;

namespace Ex57
{
    class Program
    {

        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho

                string nome = "Nome da Conta";
                string numero = "00000000-0";

                Conta c = new Conta(nome, numero); // intanciando objeto utilizando um construtor	
				
                while (10 > 5) // loop infinito até usuário desejar sair do programa
                {
                    Menu(c); // chamada de método inicial
                    Console.Clear();
                }
        }

        static void OpcsMenu() // opções a serem exibidas no menu
        {
            Console.WriteLine("1. Depositar na conta");
            Console.WriteLine("2. Fazer retirada na conta");
            Console.WriteLine("3. Imprimir saldo da conta");
            Console.WriteLine("4. Sair do programa");
            Console.WriteLine();
            Console.Write("Digite uma opção: ");
        }

        static void Menu(Conta c)
        {
            int valor; // variável que receberá valor para saque ou depósito

            OpcsMenu(); // chamada de método para imprimir menu

            try // try usado para tratamento de erros, como valores inválidos
            {
                int opc = int.Parse(Console.ReadLine()); // variável para armazenar opção do usuário para os itens do menu

                Console.Clear();
				
                switch (opc)
                {
                    case 1:
                        Console.Write("Digite um valor para o deposito: ");
                        valor = int.Parse(Console.ReadLine()); // armazenar valor de depósito do usuário
                        if(c.Depositar(valor)== true) Console.Write("Deposito realizado com sucesso"); // chamada de método de instância para realizar depósito
							else Console.WriteLine("Valor inválido");
                        break;

                    case 2:
                        Console.Write("Digite um valor para sacar: ");
                        valor = int.Parse(Console.ReadLine()); // armazenar valor de saque do usuário
                        if(c.Sacar(valor) == true) Console.Write("Saque realizado com sucesso"); // chamada de método de instância para realizar saque
							else Console.Write("Saldo insuficiênte ou valor inválido");
                        break;

                    case 3:
                        Console.WriteLine(c); // chamada de método de instância ToString do objeto, para imprimir informações sobre o saldo
                        break;

                    case 4:
                        Environment.Exit(0); // método usado para terminar a aplicação
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Valor inválido");
            }
			Console.ReadKey();
        }

        static void ImprimirNomes()
        {
			Console.Clear();	
            Console.WriteLine("Integrantes:");
            Console.WriteLine("652813 - Bryan Diniz Rodrigues");
            Console.WriteLine("664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine("668579 - Thais Barcelos Lorentz");
            Console.Write("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
			Console.Clear();			
        }
    }
}

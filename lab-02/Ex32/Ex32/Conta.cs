using System;

namespace Ex32
{
    public class Conta
    {
        const int maxContas = 100; // número máximo de contas
        static Conta[] vetContas = new Conta[maxContas]; //vetor de contas

        private static int _cont = 0; //contador de contas existentes

        private String _titular; // nome do titular da conta
        private int _agencia; // número da agência da conta
        private int _numConta; // número da conta
        private double _saldo; // saldo atual da conta.
        private bool _ativada;

        public Conta()
        {
            _ativada = false;
        }

        public Conta(string titular, int agencia, int numConta)
        {
            _titular = titular;
            _agencia = agencia;
            _numConta = numConta;
            _ativada = true;
            _cont++;
        }

        public static void PopularVetor()
        {
            Conta contaNull = new Conta();

            for (int i = _cont; i < vetContas.Length; i++)
            {
                vetContas[i] = contaNull;
            }
        }

        public static void AddConta(Conta conta)
        {
            bool subConta = false;

            if (_cont == 1) // Adicionar primeira conta
            {
                vetContas[0] = conta;
                subConta = true;
            }

            if (_cont == 1) // Populando vetor com contas vazias
            {
                PopularVetor();
            }

            for (int i = 1; i < vetContas.Length; i++)
            {
                if (vetContas[i]._ativada == false && subConta == false)
                {
                    vetContas[i] = conta;
                    subConta = true;
                    _cont++;
                }
            }

        }


        public static bool EntrarConta(int numConta)
        {
            bool retorno = true;

            foreach (Conta item in vetContas)
            {
                if (numConta == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\tNenhuma conta selecionada\t\n");

                    Console.ResetColor();

                    retorno = false;
                    break;
                }
                else if (numConta == item._numConta && item._ativada == true)
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\t Conta selecionada\t \n");

                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(item);

                    Console.ResetColor();

                    Console.WriteLine();
                    retorno = true;
                    break;
                }
                else
                {
                    retorno = false;
                }

            }


            return retorno;
        }

        public static void ExcluirConta(int numConta)
        {

            foreach (Conta item in vetContas)
            {

                if (numConta == item._numConta)
                {

                    item._ativada = false;

                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(" Conta deletada com sucesso ");

                    Console.ResetColor();

                    break;
                }
                else
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(" Número de conta inválido ");

                    Console.ResetColor();

                }

            }

        }

        public static void DepositarConta(int numConta, double valor)
        {

            foreach (Conta item in vetContas)
            {

                if (numConta == item._numConta)
                {

                    if (item.Depositar(valor) == true)
                    {

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(" Depósito realizado com sucesso! ");

                        Console.ResetColor();

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(" Valor de depósito inválido ");

                        Console.ResetColor();

                    }

                    break;
                }

            }

        }

        public static void SacarConta(int numConta, double valor)
        {

            foreach (Conta item in vetContas)
            {

                if (numConta == item._numConta)
                {

                    if (item.Retirar(valor) == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(" Saque realizado com sucesso! ");

                        Console.ResetColor();

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(" Valor de saque inválido, ou saldo insuficiente ");

                        Console.ResetColor();

                    }

                    break;
                }

            }

        }

        public static void VerSaldo(int numConta)
        {

            foreach (Conta item in vetContas)
            {

                if (numConta == item._numConta)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(" Saldo: R$" + item._saldo.ToString("F2"));

                    Console.ResetColor();

                    break;
                }

            }

        }

        public static void ExibirContas()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\t\tContas\t\t\t\n");

            Console.ResetColor();

            foreach (Conta item in vetContas)
            {
                if (item._ativada == true)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }

        }

        public static void BuscarConta(int numConta)
        {
            bool contaEncontrada = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();

            foreach (Conta item in vetContas)
            {

                if (numConta == item._numConta && item._ativada == true)
                {
                    Console.WriteLine(item);
                    contaEncontrada = true;
                    break;
                }

            }

            Console.ResetColor();

            if (contaEncontrada == false)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Número de conta inválido");

                Console.ResetColor();

            }

        }


        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                _saldo += valor;
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Retirar(double valor)
        {
            if (_saldo > valor && valor > 0)
            {
                _saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() // Retornar data do tipo dd/mm/aaaa
        {
            return " Conta: " + _numConta.ToString("D9") + "\n" +
                   " Titular: " + _titular + "\n" +
                   " Agência: " + _agencia.ToString("D4");
        }

    }
}
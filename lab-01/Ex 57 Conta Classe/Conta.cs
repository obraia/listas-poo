using System;

namespace Ex57
{
    class Conta
    {
        private string _nome;
        private string _numero;
        private double _saldo;

        public override string ToString() // retorno padrão do objeto em String
        {
            return "" + _nome + " seu saldo é de " + "R$" + _saldo.ToString("F2");
        }

        public Conta() { } // construtor padrão

        public Conta(string nome, string numero) // construtor para criação da conta
        {
            _nome = nome;
            _numero = numero;
        }

        public bool Depositar(int valor) // método para realizar depósito
        {
			if(valor>0) // não permite depósito de valores negativos
			{
				_saldo += valor;	
				return true;
			} else return false;
        }

        public bool Sacar(int valor) // método para realizar saque
        {
            if ((_saldo >= valor) &&(valor > 0)) // só permite saque se valor for menor que saldo e maior que zero
            {
                _saldo -= valor;
				return true;
            }else return false;
        }
    }
}

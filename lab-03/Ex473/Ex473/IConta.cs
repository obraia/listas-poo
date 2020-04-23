using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex473
{
    interface IConta
    {
        string Titular { get;}
        int NumConta { get;}
        int TipoConta { get; }
        int NumAgencia { get; }
        double Saldo { get; }
        bool ContaAtiva { get; }
        DateTime DataDeCriacao { get; }
        bool Deposito(double valor);
        bool Saque(double valor);
        void DesativarConta();
        string EscreverArquivo();
    }
}

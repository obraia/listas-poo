
namespace Ex33
{
    interface IConta
    {
        string Titular { get; set; }
        int NumConta { get; set; }
        int TipoConta { get; set; }
        int NumAgencia { get; set; }
        double Saldo { get; set; }
        bool ContaAtiva { get; set; }
        bool Deposita(double valor);
        bool Saca(double valor);
        string InfoConta();
        string EscreverArquivo();
    }
}

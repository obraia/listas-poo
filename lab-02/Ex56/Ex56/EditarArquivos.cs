using System.IO;

namespace Ex56
{
    class EditarArquivos
    {
        private string ArquivoEntrada; // armazenar caminho do arquivo de entrada
        private string ArquivoSaida; // armazenar caminho do arquivo de saida

        public EditarArquivos(string arquivoEntrada, string arquivoSaida)
        {
            ArquivoEntrada = arquivoEntrada;
            ArquivoSaida = arquivoSaida;
            CriarArquivos();
        }

        public void CriarArquivos() // método para gerar criar os arquivos de entrada e saída e fecha-los após o uso
        {
            StreamWriter criarArquivoE = new StreamWriter(ArquivoEntrada);
            criarArquivoE.Close();

            StreamWriter criarArquivoS = new StreamWriter(ArquivoSaida);
            criarArquivoS.Close();
        }

        public void EscreverArquivoEntrada(string caracteres) // escrever string recebida por parâmetro no arquivo de entrada
        {
            using (StreamWriter sw = File.AppendText(ArquivoEntrada))
            {
                sw.WriteLine(caracteres);
            }
        }

        public void EscreverArquivoSaida(string caracteres) // escrever string recebida por parâmetro no arquivo de saída
        {
            using (StreamWriter sw = File.AppendText(ArquivoSaida))
            {
                sw.WriteLine(caracteres);
            }
        }
    }
}


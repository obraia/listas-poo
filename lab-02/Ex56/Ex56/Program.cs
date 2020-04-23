using System;

namespace Ex56
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            try
            {
                string caminhoArquivoE = args[0]; // salvar caminho do arquivo de entrada
                string caminhoArquivoS = args[1]; // salvar caminho do arquivo de saída

                EditarArquivos arquivos = new EditarArquivos(caminhoArquivoE, caminhoArquivoS); // instânciando objeto para trabalhar com arquivos

                Console.WriteLine("\n Programa de teste do sistema de arquivos ");
                Console.WriteLine("\n Arquivo de entrada: " + caminhoArquivoE);
                Console.WriteLine(" Arquivo de saída: " + caminhoArquivoS);

                Console.Write("\n Entre com os caracteres: a x r s q w z * :  ");
                string entradaCaracteres = Console.ReadLine();

                char[] caracteres = new char[entradaCaracteres.Length]; // vetor para armazenar os caracteres até a tag flag "*"

                for (int i = 0; i < entradaCaracteres.Length; i++) // salvar caracters até a tag flag "*"
                {
                    if (entradaCaracteres[i] != '*')
                    {
                        caracteres[i] = entradaCaracteres[i];
                    }
                    else
                    {
                        i = entradaCaracteres.Length; // finalizar for
                    }
                }

                string saidaCaracteres = new string(caracteres); // converter caracters para string

                Console.WriteLine("\n Caracteres digitados: " + saidaCaracteres); // mostrar caracteres digitado pelo usuário
                Console.WriteLine(" Caracteres convertidos: " + saidaCaracteres.ToUpper()); // mostrar caracteres convertido para maiúsculas

                arquivos.EscreverArquivoEntrada(saidaCaracteres); // chamada de método para escrever no arquivo de entrada
                arquivos.EscreverArquivoSaida(saidaCaracteres.ToUpper()); // chamada de método para escrever no arquivo de saída

                Console.WriteLine("\n Os arquivos foram criados e editados com sucesso! ");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("\n Erro, para usar o programa digite Ex56.exe ArquivoEntrada.txt ArquivoSaida.txt \n");
                Console.ReadKey();
            }
        }
    }
}

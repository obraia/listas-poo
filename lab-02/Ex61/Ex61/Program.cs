//
// nome do programa: Ex61.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 22/09/2019
// entrada(s): comando desejado e local e nome do arquivo
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): resultado da opção ou mensagem de erro
// para executar  e testar digite: 
//  apagar nomeArquivo.extensão - renomear nomeArquivo.extensão\n - copiar nomeArquivo.extensão
// descricao: Recebe um comando como - > apagar nomeArquivo.extensão por linha de comando args[]
// e caso o arquivo for encontrado será realizada a operação, caso contrário exibirá uma mensagem de erro
//
// Ref: http://www.linhadecodigo.com.br/artigo/3684/trabalhando-com-arquivos-e-diretorios-em-csharp.aspx
// Ref: https://www.devmedia.com.br/obtendo-a-extensao-de-um-arquivo-em-c-sharp/21918
//

using System;
using System.IO;

namespace Ex61
{
    class Program
    {
        static void Main(string[] args)
        {
            string comando;
            string caminhoArquivo = "";

            if (args.Length == 2)
            {
                // armazenar comando entrado por LC (apagar, renomear e copiar)
                comando = args[0];
                // armazenar caminho do arquivo que desejamos manipular
                caminhoArquivo = args[1];

                switch (comando)
                {
                    case "apagar":
                        ApagarArquivo(caminhoArquivo);
                        break;

                    case "renomear":
                        RenomearArquivo(caminhoArquivo);
                        break;

                    case "copiar":
                        CopiarArquivo(caminhoArquivo);
                        break;

                    default:
                        Console.WriteLine("\n Comando inválido!\n\n Lista de comandos: \n\n -> apagar nomeArquivo.extensão \n -> renomear nomeArquivo.extensão\n -> copiar nomeArquivo.extensão ");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n Comando inválido!\n\n Lista de comandos: \n\n -> apagar nomeArquivo.extensão \n -> renomear nomeArquivo.extensão\n -> copiar nomeArquivo.extensão ");
            }
            Console.ReadKey();
        }

        static void ApagarArquivo(string caminhoArquivo)
        {

            // verificar existência do arquivo
            if (File.Exists(caminhoArquivo))
            {
                // comando para deletar arquivo
                File.Delete(caminhoArquivo);
                Console.WriteLine("\n Arquivo apagado com sucesso!");
            }
            else
            {
                Console.WriteLine("\n Arquivo não encontrado! ");
            }
        }

        static void RenomearArquivo(string caminhoArquivo)
        {
            string novoNome; // armazenar novo nome para o arquivo
            string extensao; // armazenar extensão do arquivo

            // verificar existência do arquivo
            if (File.Exists(caminhoArquivo))
            {
                // obter extensão do arquivo (.txt .exe .jpg etc...)
                extensao = Path.GetExtension(caminhoArquivo);

                Console.Write("\n Digite o novo nome do arquivo: ");
                // ler e concatenar nome do arquivo com a extensão
                novoNome = Console.ReadLine() + extensao;

                // instânciando objeto do arquivo de origem
                FileInfo arquivoOrigem = new FileInfo(caminhoArquivo);
                arquivoOrigem.MoveTo(novoNome); // renomear para novo nome

                Console.WriteLine("\n Arquivo renomeado com sucesso!");
            }
            else
            {
                Console.WriteLine("\n Arquivo não encontrado! ");
            }
        }

        static void CopiarArquivo(string caminhoArquivo)
        {
            int i, b;
            string ArquivoSaida; // armazenar nome do arquivo de saída
            string extensao; // armazenar extensão do arquivo

            // verificar existência do arquivo
            if (File.Exists(caminhoArquivo))
            {
                // obter extensão do arquivo (.txt .exe .jpg etc...)
                extensao = Path.GetExtension(caminhoArquivo);

                Console.Write("\n Digite o nome do arquivo de saída: ");
                ArquivoSaida = Console.ReadLine() + extensao;

                // obter propriedades do arquivo
                FileInfo fi = new FileInfo(caminhoArquivo);
                // instânciando objeto do tipo stream para abrir arquivo de entrada
                Stream entrada = File.Open(caminhoArquivo, FileMode.Open);
                // instânciando objeto do tipo stream para criar arquivo de saida
                Stream saida = File.Open(ArquivoSaida, FileMode.Create);

                for (i = 0; i < fi.Length; i++)
                {
                    b = entrada.ReadByte();
                    saida.WriteByte((byte)b);
                }
                Console.WriteLine("\n Arquivo copiado com sucesso!");
                Console.WriteLine("\n Bytes copiados: " + i);

                // terminando fluxos dos arquivos de entrada e saída
                entrada.Close();
                saida.Close();
            }
            else
            {
                Console.WriteLine("\n Arquivo não encontrado! ");
            }
        }
    }
}

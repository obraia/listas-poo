//
// nome do programa: Ex62.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 28/09/2019
// entrada(s): comando e nome/caminho do diretório
// saida(s): informação se a execução ocorreu ou não com sucesso
// para executar  e testar digite: 
// Ex62.exe apagar nomeDiretorio
// descricao: Um programa que recebe por linha de comando um comando (criar, apagar, copiar...) e um nome de diretório
// após isso irá realizar as instruções necessárias
//
// Ref:
// Ref: https://pt.stackoverflow.com/questions/31642/como-ler-arquivos-de-pasta-e-subpasta
// Ref: https://social.msdn.microsoft.com/Forums/pt-BR/f7a9c8f9-728d-48c5-b56a-84fb467b78c4/deletar-pastas-subpastas-e-arquivos-em-c?forum=clientept
// Ref: https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.move?view=netframework-4.8 
// Ref: https://docs.microsoft.com/pt-br/dotnet/standard/io/how-to-copy-directories
// Ref: 
//

using System;
using System.IO;

namespace Ex62
{
    class Program
    {
        static void Main(string[] args)
        {
            string comando;
            string diretorio = "";

            if (args.Length == 2)
            {
                comando = args[0].ToLower();
                diretorio = args[1].ToLower();

                switch (comando)
                {
                    case "criar":
                        CriarDiretorio(diretorio);
                        break;
                    case "absoluto":
                        CaminhoAbsoluto(diretorio);
                        break;
                    case "listar":
                        ListarDiretorio(diretorio);
                        break;
                    case "apagar":
                        ApagarDiretorio(diretorio);
                        break;
                    case "renomear":
                        RenomearDiretorio(diretorio);
                        break;
                    case "copiar":
                        CopiarDiretorio(diretorio);
                        break;
                    default:
                        Console.WriteLine("\n Comando inválido!\n\n Lista de comandos: \n -> criar nomeDiretorio \n -> absoluto nomeDiretorio \n -> apagar nomeDiretorio \n -> renomear nomeDiretorio \n -> copiar nomeDiretorio \n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n Comando inválido!\n\n Lista de comandos: \n -> criar nomeDiretorio \n -> absoluto nomeDiretorio \n -> apagar nomeDiretorio \n -> renomear nomeDiretorio \n -> copiar nomeDiretorio \n");
            }
        }

        static void CriarDiretorio(string diretorio)
        {
            if (!Directory.Exists(diretorio)) //Se o diretório não existir...
            {
                //Criamos um com o nome salvo na variável diretorio
                Directory.CreateDirectory(diretorio);
                Console.WriteLine("\n Pasta criada com sucesso \n");
            }
            else
            {
                Console.WriteLine("\n O diretório já existe! \n");
            }
        }

        static void CaminhoAbsoluto(string diretorio)
        {
            if (Directory.Exists(diretorio)) //Se o diretório existir...
            {
                // instâciar objeto do tipo DirectoryInfo para pegarmos informações sobre o diretório
                DirectoryInfo Diretorio = new DirectoryInfo(diretorio);
                Console.WriteLine("\n Caminho Absoluto: " + Diretorio.FullName);
            }
            else
            {
                Console.WriteLine("\n O diretório não foi encontrado ");
            }
        }

        static void ListarDiretorio(string diretorio)
        {
            if (Directory.Exists(diretorio)) //Se o diretório existir...
            {
                // salvar nomes dos diretorios de uma pasta em um vetor string
                string[] diretorios = Directory.GetDirectories(diretorio);
                // salvar nomes dos arquivos de uma pasta em um vetor string
                string[] arquivos = Directory.GetFiles(diretorio);

                Console.WriteLine("\n Diretórios:");
                // imprimir nomes dos diretórios
                foreach (var item in diretorios)
                {
                    Console.WriteLine(" " + item);
                }
                Console.WriteLine("\n Arquivos:");
                // imprimir nomes dos arquivos
                foreach (var item in arquivos)
                {
                    Console.WriteLine(" " + item);
                }
            }
            else
            {
                Console.WriteLine("\n O diretório não foi encontrado ");
            }
        }

        static void ApagarDiretorio(string diretorio)
        {
            if (Directory.Exists(diretorio)) //Se o diretório existir...
            {
                try
                {
                    Directory.Delete(diretorio, true);
                    Console.WriteLine("\n Diretório deletado com sucesso! ");
                }
                catch (IOException e)
                {
                    Console.WriteLine("\n " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("\n O diretório não foi encontrado ");
            }
        }

        static void RenomearDiretorio(string diretorio)
        {
            if (Directory.Exists(diretorio)) //Se o diretório existir...
            {
                try
                {
                    Console.Write("\n Digite o novo nome para o diretório: ");
                    string novoNome = Console.ReadLine();
                    Directory.Move(diretorio, novoNome);
                    Console.WriteLine("\n Diretório renomeado com sucesso! ");
                }
                catch (IOException e)
                {
                    Console.WriteLine("\n " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("\n O diretório não foi encontrado ");
            }
        }

        static void CopiarDiretorio(string diretorio)
        {
            if (Directory.Exists(diretorio)) //Se o diretório existir...
            {
                try
                {
                    // obter informações sobre o diretório a ser copiado
                    DirectoryInfo dir = new DirectoryInfo(diretorio);
                    // salvar todos os diretórios do diretório a ser copiado
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    // salvar todos os arquivos do diretório a ser copiado
                    FileInfo[] files = dir.GetFiles();

                    Console.Write("\n Digite o nome para a cópia do diretório: ");
                    string copiaDiretorio = Console.ReadLine();
                    // criar diretório com nome passado pelo usuário
                    Directory.CreateDirectory(copiaDiretorio);
                    
                    foreach (FileInfo file in files)
                    {
                        //fazer cópia de todos os arquivos para o novo diretório
                        string temppath = Path.Combine(copiaDiretorio, file.Name);
                        file.CopyTo(temppath, false);
                    }

                    Console.WriteLine("\n Diretório copiado com sucesso! ");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("\n O diretório não foi encontrado ");
            }
        }
    }
}

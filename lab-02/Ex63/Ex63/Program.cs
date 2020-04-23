using System;
using System.IO;

// Ref: https://docs.microsoft.com/pt-br/dotnet/api/system.io.driveinfo.getdrives?view=netframework-4.8

namespace Ex63
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes();

            // obeter todos os drives conectados no momento
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            Console.WriteLine("\n INFORMAÇÕES SOBRE TODOS OS DRIVES CONECTADOS \n");
            // percorrer e exibir informações de todos os drives
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine(" Disco {0}\n", d.Name);
                Console.WriteLine("  Tipo do disco: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  Sistema de arquivos:                         {0}", d.DriveFormat);
                    Console.WriteLine("  Espaço livre disponível deste usuário:  {0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("  Espaço total livre disponível:          {0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("  Espaço total do disco:                  {0, 15} bytes ", d.TotalSize);
                }
            }
            Console.WriteLine();
        }
        static void ImprimirNomes()
        {
            Console.Clear();
            Console.WriteLine("\n Integrantes:\n");
            Console.WriteLine(" 652813 - Bryan Diniz Rodrigues");
            Console.WriteLine(" 664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine(" 668579 - Thais Barcelos Lorentz");
            Console.Write("\n Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex473
{
    class Arquivo
    {
        public static List<IConta> ListContas = new List<IConta>();

        public static void LerArquivoAgenc(ref int agencia)
        {
            string caminhoArq = @"Files/Agencias/" + agencia + ".txt";

            ListContas.Clear();

            try
            {
                if (File.Exists(caminhoArq))
                {
                    using (StreamReader sr = new StreamReader(caminhoArq))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            string[] aux = linha.Split(';');
                            string titular = aux[0];
                            int numAgencia = int.Parse(aux[1]);
                            int numConta = int.Parse(aux[2]);
                            int tipoConta = int.Parse(aux[3]);
                            double saldo = double.Parse(aux[4]);
                            bool contaAtiva = bool.Parse(aux[5]);
                            DateTime dataDeCriacao = DateTime.Parse(aux[6]);

                            if (tipoConta == 1)
                            {
                                ContaCorrente cc = new ContaCorrente(titular, numAgencia, numConta, saldo, contaAtiva, dataDeCriacao);
                                ListContas.Add(cc);
                            }
                            else if (tipoConta == 2)
                            {
                                ContaCorrente cp = new ContaCorrente(titular, numAgencia, numConta, saldo, contaAtiva, dataDeCriacao);
                                ListContas.Add(cp);
                            }
                        }
                    }
                    string message = "Contas carregadas: " + ListContas.Count;
                    string caption = "Sucesso";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                }
                else
                {
                    string message = "Arquivo não encontrado";
                    string caption = "Erro";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
            }
        }

        public static void SalvarArquivo(ref int agencia)
        {
            string caminhoArq = @"Files/Agencias/" + agencia + ".txt";

            using (StreamWriter sr = new StreamWriter(caminhoArq))
            {
                foreach (var conta in ListContas)
                {
                    sr.WriteLine(conta.EscreverArquivo());
                }
            }
        }

        public static void CriarArquivos()
        {
            string caminhoDiretorio = "Files/Agencias";

            if (!Directory.Exists(caminhoDiretorio))
            {
                Directory.CreateDirectory(caminhoDiretorio);
            }

            string agenciasCadastradas = "Files/Agencias/Agencias.txt";

            if (!File.Exists(agenciasCadastradas))
            {
                using (StreamWriter sr = new StreamWriter(agenciasCadastradas))
                {
                    sr.WriteLine("10;20;30;40;50");
                }
            }

            using (StreamReader sr = new StreamReader(agenciasCadastradas))
            {
                string line = sr.ReadLine();
                string[] agencias = line.Split(';');

                for (int i = 0; i < agencias.Length; i++)
                {
                    string caminhoAgencia = caminhoDiretorio + "/" + agencias[i] + ".txt";
                    if (!File.Exists(caminhoAgencia))
                    {
                        StreamWriter create = new StreamWriter(caminhoAgencia);
                        create.Close();
                    }
                }
            }
        }
    }
}

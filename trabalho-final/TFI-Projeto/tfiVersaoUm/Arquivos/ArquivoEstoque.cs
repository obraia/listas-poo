﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace tfiVersaoUm
{
    class ArquivoEstoque
    {
        public static List<IProduto> ListaProdutos = new List<IProduto>();
        static string caminhoArquivo = @"Arquivos\estoque.txt";

        public static void LerArquivo()
        {
            ListaProdutos.Clear();

            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            //ID;Categoria;Nome;Preço Unidade;Quantidade;Quantidade vendida;Data de cadastro;Descrição

                            string[] aux = linha.Split(';');
                            string id = aux[0];
                            string categoria = aux[1];
                            string nome = aux[2];
                            double preco = double.Parse(aux[3]);
                            double quantidade = double.Parse(aux[4]);
                            double quantidadeVendida = double.Parse(aux[5]);
                            DateTime dataDeCadastro = DateTime.Parse(aux[6]);
                            string descricao = aux[7];

                            if (categoria == "Alimentos")
                            {
                                Alimento produto = new Alimento(id, nome, preco, (int)quantidade, (int)quantidadeVendida, dataDeCadastro, descricao);
                                ListaProdutos.Add(produto);
                            }
                            else if (categoria == "Limpeza")
                            {
                                Limpeza produto = new Limpeza(id, nome, preco, (int)quantidade, (int)quantidadeVendida, dataDeCadastro, descricao);
                                ListaProdutos.Add(produto);
                            }
                            else if (categoria == "Higiene pessoal")
                            {
                                HigienePessoal produto = new HigienePessoal(id, nome, preco, (int)quantidade, (int)quantidadeVendida, dataDeCadastro, descricao);
                                ListaProdutos.Add(produto);
                            }
                            else if (categoria == "Hortifruti")
                            {
                                Hortifruti produto = new Hortifruti(id, nome, preco, quantidade, quantidadeVendida, dataDeCadastro, descricao);
                                ListaProdutos.Add(produto);
                            }
                            else if (categoria == "Outros")
                            {
                                Outros produto = new Outros(id, nome, preco, (int)quantidade, (int)quantidadeVendida, dataDeCadastro, descricao);
                                ListaProdutos.Add(produto);
                            }
                        }
                    }
                }
                else
                {
                    string message = "Arquivo do estoque não encontrado";
                    string caption = "Erro";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
            catch
            {
                string message = "Erro ao carregar estoque";
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }
            
        }

        public static void SalvarArquivo()
        {
            using (StreamWriter sr = new StreamWriter(caminhoArquivo))
            {
                foreach (var produto in ListaProdutos)
                {
                    sr.WriteLine(produto.EscreverArquivo());
                }
            }
        }

        public static void RemoverProduto(int index)
        {
            File.Delete(@"Arquivos\Imagens\Estoque\" + ListaProdutos[index].ID + ".png");
            ListaProdutos.RemoveAt(index);
        }

    }
}

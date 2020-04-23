﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; // Round window
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfiVersaoUm
{
    public partial class AdicionarProduto : Form
    {
        static string ImagemEntrada = "";
        static int Cont = ArquivoEstoque.ListaProdutos.Count + 1;
        static string ImagemSaida = "";

        // Move Panel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Move Panel
        private void panel_move_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Round Window
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public AdicionarProduto()
        {
            InitializeComponent();
            CarregarProduto();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void button_abrirImagem_Click(object sender, EventArgs e)
        {
            AbrirImagem();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = textBox_id.Text;
                string categoria = comboBox_categoria.Text;
                string nome = textBox_nome.Text;
                double preco = double.Parse(textBox_preco.Text);
                double quantidade = double.Parse(textBox_quantidade.Text);
                DateTime dataCadastro = DateTime.Now;
                string descricao = textBox_descricao.Text;

                if (categoria != "" && nome != "" && descricao != "")
                {
                    ImagemSaida = @"Arquivos\Imagens\Estoque\" + codigo + ".png";
                    Imagem.Copiar(ImagemEntrada, ImagemSaida);

                    if (categoria == "Alimentos")
                    {
                        Alimento produto = new Alimento(codigo, nome, preco, (int)quantidade, 0, dataCadastro, descricao);
                        ArquivoEstoque.ListaProdutos.Add(produto);
                    }
                    else if (categoria == "Limpeza")
                    {
                        Limpeza produto = new Limpeza(codigo, nome, preco, (int)quantidade, 0, dataCadastro, descricao);
                        ArquivoEstoque.ListaProdutos.Add(produto);
                    }
                    else if (categoria == "Higiene pessoal")
                    {
                        HigienePessoal produto = new HigienePessoal(codigo, nome, preco, (int)quantidade, 0, dataCadastro, descricao);
                        ArquivoEstoque.ListaProdutos.Add(produto);
                    }
                    else if (categoria == "Hortifruti")
                    {
                        Hortifruti produto = new Hortifruti(codigo, nome, preco, quantidade, 0, dataCadastro, descricao);
                        ArquivoEstoque.ListaProdutos.Add(produto);
                    }
                    else if (categoria == "Outros")
                    {
                        Outros produto = new Outros(codigo, nome, preco, (int)quantidade, (int)quantidade, dataCadastro, descricao);
                        ArquivoEstoque.ListaProdutos.Add(produto);
                    }

                    string message = "Produto adicionado com sucesso";
                    string caption = "Sucesso";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);

                    ArquivoEstoque.SalvarArquivo();

                    this.Close();
                }
                else
                {
                    string message = "Preecnha todos os campos";
                    string caption = "Erro";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;//"Preencha todos os campos de forma válida";
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }

        }

        private void pictureBox_ImagemProd_Click(object sender, EventArgs e)
        {
            AbrirImagem();
        }

        private void AbrirImagem()
        {
            OpenFileDialog abrirImagem = new OpenFileDialog();
            abrirImagem.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            abrirImagem.Title = "Selecione uma imagem para o produto.";
            if (abrirImagem.ShowDialog() == DialogResult.OK)
            {
                ImagemEntrada = abrirImagem.FileName;
                pictureBox_Imagem.BackgroundImage = Imagem.Carregar(abrirImagem.FileName);
            }
        }

        private void CarregarProduto()
        {
            if (ArquivoEstoque.ListaProdutos.Count > 0)
            {
                string id = (long.Parse(ArquivoEstoque.ListaProdutos[ArquivoEstoque.ListaProdutos.Count - 1].ID) + 1).ToString();
                textBox_id.Text = id;
                comboBox_categoria.SelectedIndex = 0;
            }
            else
            {
                textBox_id.Text = "7891234" + (ArquivoEstoque.ListaProdutos.Count + 1).ToString("D5");
            }
        }
    }
}

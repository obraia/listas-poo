using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex473
{
    public partial class Banco : Form
    {
        public Banco()
        {
            Arquivo.CriarArquivos();
            MessageBox.Show((" Bryan Diniz Rodrigues - 652813 \n Luiz Henrique Gomes Guimarães - 664469 \n Thais Barcelos Lorentz - 668579"), "Criado por");
            InitializeComponent();
            AgenciasCadastradas();
        }

        private void bt_BuscarAgenc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK) ;
            //tB_caminhoArq.Text = openFile.FileName;
        }

        private void bt_CarregarAgenc_Click(object sender, EventArgs e)
        {
            if (cb_agencias.SelectedIndex > -1)
            {
                int agenciaSelec = int.Parse(cb_agencias.Text);
                Arquivo.LerArquivoAgenc(ref agenciaSelec);
                CarregarTabela();
            }
            else
            {
                string message = "Agência não selecionada";
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_addConta_Click(object sender, EventArgs e)
        {
            if (cb_agencias.SelectedIndex > -1)
            {
                int agenciaSelec = int.Parse(cb_agencias.Text);
                NovaConta nC = new NovaConta(agenciaSelec);
                nC.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma agência");
            }

        }

        private void bt_atualizarTabela_Click(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void bt_sacar_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (lvContas.SelectedItems.Count > 0)
            {
                ListViewItem selItem = lvContas.SelectedItems[0];
                index = selItem.Index;

                if (Arquivo.ListContas[index].ContaAtiva == true)
                {
                    Saque saque = new Saque(index);
                    saque.ShowDialog();
                }
                else
                {
                    MessageBox.Show("A conta selecionada foi desativada");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }

        }

        private void bt_depositar_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (lvContas.SelectedItems.Count > 0)
            {
                ListViewItem selItem = lvContas.SelectedItems[0];
                index = selItem.Index;

                if (Arquivo.ListContas[index].ContaAtiva == true)
                {
                    Deposito deposito = new Deposito(index);
                    deposito.ShowDialog();
                }
                else
                {
                    MessageBox.Show("A conta selecionada foi desativada");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            if (cb_agencias.SelectedIndex > -1)
            {
                int agenciaSelec = int.Parse(cb_agencias.Text);
                Arquivo.SalvarArquivo(ref agenciaSelec);

                string message = "Alterações salvas com sucesso";
                string caption = "Sucesso";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            }
            else
            {
                string message = "Agência não selecionada";
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }
        }

        private void bt_verSaldo_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (lvContas.SelectedItems.Count > 0)
            {
                ListViewItem selItem = lvContas.SelectedItems[0];
                index = selItem.Index;

                if (Arquivo.ListContas[index].ContaAtiva == true)
                {
                    MessageBox.Show("Saldo de: R$ " + (Arquivo.ListContas[index].Saldo).ToString("F2"));

                }
                else
                {
                    MessageBox.Show("A conta selecionada foi desativada");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }
        }

        private void bt_excluirConta_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (lvContas.SelectedItems.Count > 0)
            {
                ListViewItem selItem = lvContas.SelectedItems[0];
                index = selItem.Index;

                if (Arquivo.ListContas[index].ContaAtiva == true)
                {
                    string message = "Tem certeza que deseja excluir a conta?";
                    string caption = "Atenção";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

                    switch (result)
                    {
                        case DialogResult.Yes:   // Yes button pressed
                            Arquivo.ListContas[index].DesativarConta();
                            CarregarTabela();
                            break;
                        case DialogResult.No:    // No button pressed
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("A conta selecionada já foi desativada");
                }

            }
            else
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }
        }

        private void AgenciasCadastradas()
        {
            string Path = "Files/Agencias/Agencias.txt";

            using (StreamReader sr = new StreamReader(Path))
            {
                string line = sr.ReadLine();
                string[] agencias = line.Split(';');
                cb_agencias.Items.AddRange(agencias);
            }
        }

        private void CarregarTabela()
        {
            lvContas.Items.Clear();

            foreach (var conta in Arquivo.ListContas)
            {
                string titular = conta.Titular;
                string agencia = conta.NumAgencia.ToString("D3");
                string numero = conta.NumConta.ToString("D4");

                string tipo = "";
                if (conta.TipoConta == 1) tipo = "Corrente";
                else if (conta.TipoConta == 2) tipo = "Poupança";

                string estado = "";
                if (conta.ContaAtiva == true) estado = "Ativada";
                else estado = "Desativada";

                string dataDeCriacao = conta.DataDeCriacao.ToString();

                string[] row = { titular, agencia, numero, tipo, estado, dataDeCriacao };
                var listViewItem = new ListViewItem(row);
                lvContas.Items.Add(listViewItem);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ex473
{
    public partial class NovaConta : Form
    {
        int AgenciaSelec;

        public NovaConta(int agencia)
        {
            InitializeComponent();
            AgenciaSelec = agencia;
            CarregarNums();
        }

        void CarregarNums()
        {
            lb_infoConta.Text = "Agência: " + AgenciaSelec.ToString("D3") + " - N° conta: " + (Arquivo.ListContas.Count + 1).ToString("D4");
        }

        private void bt_adicionar_Click(object sender, EventArgs e)
        {
            bool validar = true;

            try
            {
                string titular = tB_titular.Text;

                int tipoConta = 1;
                if (rB_contaCorrente.Checked == true) { tipoConta = 1; }
                else if (rB_contaPoupanca.Checked == true) { tipoConta = 2; }
                else { validar = false; }

                int numConta = Arquivo.ListContas.Count + 1;
                DateTime dataDeCriacao = DateTime.Now;

                if (tB_titular.Text.Length > 3 && validar == true)
                {
                    if (tipoConta == 1)
                    {
                        ContaCorrente cc = new ContaCorrente(titular, AgenciaSelec, numConta, 0, true, dataDeCriacao);
                        Arquivo.ListContas.Add(cc);
                    }
                    else if (tipoConta == 2)
                    {
                        ContaPoupanca cp = new ContaPoupanca(titular, AgenciaSelec, numConta, 0, true, dataDeCriacao);
                        Arquivo.ListContas.Add(cp);
                    }
                    string message = "Contas criada com sucesso, seu número de conta é: " + numConta.ToString("D4");
                    string caption = "Sucesso";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos de forma válida");
                }
            }
            catch
            {
                MessageBox.Show("Preencha todos os campos de forma válida");
            }
        }

    }
}

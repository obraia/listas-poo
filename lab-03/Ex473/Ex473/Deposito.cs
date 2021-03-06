﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex473
{
    public partial class Deposito : Form
    {
        int Index;

        public Deposito(int index)
        {
            Index = index;
            InitializeComponent();
        }

        private void bt_depositar_Click(object sender, EventArgs e)
        {
            double valor;
            bool aux = double.TryParse(tB_valor.Text, out valor);

            if (Arquivo.ListContas[Index].Deposito(valor) == true && aux == true)
            {
                string message = "Depósito realaizado com sucesso";
                string caption = "Sucesso";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                string message = "Valor de depósito inválido";
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

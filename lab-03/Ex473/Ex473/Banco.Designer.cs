namespace Ex473
{
    partial class Banco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_CarregarAgenc = new System.Windows.Forms.Button();
            this.cb_agencias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvContas = new System.Windows.Forms.ListView();
            this.ch_Titular = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Agencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_NumConta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_TipoConta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_EstadoConta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_DataDeCriacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_addConta = new System.Windows.Forms.Button();
            this.bt_atualizarTabela = new System.Windows.Forms.Button();
            this.bt_sacar = new System.Windows.Forms.Button();
            this.bt_depositar = new System.Windows.Forms.Button();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.bt_verSaldo = new System.Windows.Forms.Button();
            this.bt_excluirConta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_CarregarAgenc
            // 
            this.bt_CarregarAgenc.Location = new System.Drawing.Point(273, 15);
            this.bt_CarregarAgenc.Name = "bt_CarregarAgenc";
            this.bt_CarregarAgenc.Size = new System.Drawing.Size(90, 23);
            this.bt_CarregarAgenc.TabIndex = 0;
            this.bt_CarregarAgenc.Text = "Carregar contas";
            this.bt_CarregarAgenc.UseVisualStyleBackColor = true;
            this.bt_CarregarAgenc.Click += new System.EventHandler(this.bt_CarregarAgenc_Click);
            // 
            // cb_agencias
            // 
            this.cb_agencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_agencias.FormattingEnabled = true;
            this.cb_agencias.Location = new System.Drawing.Point(193, 16);
            this.cb_agencias.Name = "cb_agencias";
            this.cb_agencias.Size = new System.Drawing.Size(70, 21);
            this.cb_agencias.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione uma agência:";
            // 
            // lvContas
            // 
            this.lvContas.BackgroundImageTiled = true;
            this.lvContas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvContas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Titular,
            this.ch_Agencia,
            this.ch_NumConta,
            this.ch_TipoConta,
            this.ch_EstadoConta,
            this.ch_DataDeCriacao});
            this.lvContas.FullRowSelect = true;
            this.lvContas.GridLines = true;
            this.lvContas.HideSelection = false;
            this.lvContas.Location = new System.Drawing.Point(12, 44);
            this.lvContas.Name = "lvContas";
            this.lvContas.Size = new System.Drawing.Size(427, 164);
            this.lvContas.TabIndex = 5;
            this.lvContas.UseCompatibleStateImageBehavior = false;
            this.lvContas.View = System.Windows.Forms.View.Details;
            // 
            // ch_Titular
            // 
            this.ch_Titular.Text = "Titular";
            this.ch_Titular.Width = 82;
            // 
            // ch_Agencia
            // 
            this.ch_Agencia.Text = "Agência";
            this.ch_Agencia.Width = 54;
            // 
            // ch_NumConta
            // 
            this.ch_NumConta.Text = "Conta";
            this.ch_NumConta.Width = 50;
            // 
            // ch_TipoConta
            // 
            this.ch_TipoConta.Text = "Tipo";
            this.ch_TipoConta.Width = 65;
            // 
            // ch_EstadoConta
            // 
            this.ch_EstadoConta.Text = "Estado";
            this.ch_EstadoConta.Width = 51;
            // 
            // ch_DataDeCriacao
            // 
            this.ch_DataDeCriacao.Text = "Iniciada em";
            this.ch_DataDeCriacao.Width = 120;
            // 
            // bt_addConta
            // 
            this.bt_addConta.Location = new System.Drawing.Point(12, 214);
            this.bt_addConta.Name = "bt_addConta";
            this.bt_addConta.Size = new System.Drawing.Size(63, 23);
            this.bt_addConta.TabIndex = 6;
            this.bt_addConta.Text = "Adicionar";
            this.bt_addConta.UseVisualStyleBackColor = true;
            this.bt_addConta.Click += new System.EventHandler(this.bt_addConta_Click);
            // 
            // bt_atualizarTabela
            // 
            this.bt_atualizarTabela.Location = new System.Drawing.Point(375, 14);
            this.bt_atualizarTabela.Name = "bt_atualizarTabela";
            this.bt_atualizarTabela.Size = new System.Drawing.Size(63, 23);
            this.bt_atualizarTabela.TabIndex = 7;
            this.bt_atualizarTabela.Text = "Atualizar";
            this.bt_atualizarTabela.UseVisualStyleBackColor = true;
            this.bt_atualizarTabela.Click += new System.EventHandler(this.bt_atualizarTabela_Click);
            // 
            // bt_sacar
            // 
            this.bt_sacar.Location = new System.Drawing.Point(81, 214);
            this.bt_sacar.Name = "bt_sacar";
            this.bt_sacar.Size = new System.Drawing.Size(56, 23);
            this.bt_sacar.TabIndex = 8;
            this.bt_sacar.Text = "Sacar";
            this.bt_sacar.UseVisualStyleBackColor = true;
            this.bt_sacar.Click += new System.EventHandler(this.bt_sacar_Click);
            // 
            // bt_depositar
            // 
            this.bt_depositar.Location = new System.Drawing.Point(143, 214);
            this.bt_depositar.Name = "bt_depositar";
            this.bt_depositar.Size = new System.Drawing.Size(66, 23);
            this.bt_depositar.TabIndex = 9;
            this.bt_depositar.Text = "Depositar";
            this.bt_depositar.UseVisualStyleBackColor = true;
            this.bt_depositar.Click += new System.EventHandler(this.bt_depositar_Click);
            // 
            // bt_salvar
            // 
            this.bt_salvar.Location = new System.Drawing.Point(375, 214);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(64, 23);
            this.bt_salvar.TabIndex = 10;
            this.bt_salvar.Text = "Salvar";
            this.bt_salvar.UseVisualStyleBackColor = true;
            this.bt_salvar.Click += new System.EventHandler(this.bt_salvar_Click);
            // 
            // bt_verSaldo
            // 
            this.bt_verSaldo.Location = new System.Drawing.Point(215, 214);
            this.bt_verSaldo.Name = "bt_verSaldo";
            this.bt_verSaldo.Size = new System.Drawing.Size(66, 23);
            this.bt_verSaldo.TabIndex = 11;
            this.bt_verSaldo.Text = "Ver saldo";
            this.bt_verSaldo.UseVisualStyleBackColor = true;
            this.bt_verSaldo.Click += new System.EventHandler(this.bt_verSaldo_Click);
            // 
            // bt_excluirConta
            // 
            this.bt_excluirConta.Location = new System.Drawing.Point(287, 214);
            this.bt_excluirConta.Name = "bt_excluirConta";
            this.bt_excluirConta.Size = new System.Drawing.Size(82, 23);
            this.bt_excluirConta.TabIndex = 12;
            this.bt_excluirConta.Text = "Excluir conta";
            this.bt_excluirConta.UseVisualStyleBackColor = true;
            this.bt_excluirConta.Click += new System.EventHandler(this.bt_excluirConta_Click);
            // 
            // Banco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 243);
            this.Controls.Add(this.bt_excluirConta);
            this.Controls.Add(this.bt_verSaldo);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.bt_depositar);
            this.Controls.Add(this.bt_sacar);
            this.Controls.Add(this.bt_atualizarTabela);
            this.Controls.Add(this.bt_addConta);
            this.Controls.Add(this.lvContas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_agencias);
            this.Controls.Add(this.bt_CarregarAgenc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Banco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_CarregarAgenc;
        private System.Windows.Forms.ComboBox cb_agencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvContas;
        private System.Windows.Forms.ColumnHeader ch_Titular;
        private System.Windows.Forms.ColumnHeader ch_Agencia;
        private System.Windows.Forms.ColumnHeader ch_NumConta;
        private System.Windows.Forms.ColumnHeader ch_TipoConta;
        private System.Windows.Forms.ColumnHeader ch_EstadoConta;
        private System.Windows.Forms.Button bt_addConta;
        private System.Windows.Forms.Button bt_atualizarTabela;
        private System.Windows.Forms.ColumnHeader ch_DataDeCriacao;
        private System.Windows.Forms.Button bt_sacar;
        private System.Windows.Forms.Button bt_depositar;
        private System.Windows.Forms.Button bt_salvar;
        private System.Windows.Forms.Button bt_verSaldo;
        private System.Windows.Forms.Button bt_excluirConta;
    }
}


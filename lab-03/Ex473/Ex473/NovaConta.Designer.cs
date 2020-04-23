namespace Ex473
{
    partial class NovaConta
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
            this.label1 = new System.Windows.Forms.Label();
            this.tB_titular = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rB_contaCorrente = new System.Windows.Forms.RadioButton();
            this.rB_contaPoupanca = new System.Windows.Forms.RadioButton();
            this.lb_infoConta = new System.Windows.Forms.Label();
            this.bt_adicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titular da conta:";
            // 
            // tB_titular
            // 
            this.tB_titular.Location = new System.Drawing.Point(146, 18);
            this.tB_titular.Name = "tB_titular";
            this.tB_titular.Size = new System.Drawing.Size(168, 20);
            this.tB_titular.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo da conta:";
            // 
            // rB_contaCorrente
            // 
            this.rB_contaCorrente.AutoSize = true;
            this.rB_contaCorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rB_contaCorrente.Location = new System.Drawing.Point(146, 53);
            this.rB_contaCorrente.Name = "rB_contaCorrente";
            this.rB_contaCorrente.Size = new System.Drawing.Size(72, 19);
            this.rB_contaCorrente.TabIndex = 2;
            this.rB_contaCorrente.TabStop = true;
            this.rB_contaCorrente.Text = "Corrente";
            this.rB_contaCorrente.UseVisualStyleBackColor = true;
            // 
            // rB_contaPoupanca
            // 
            this.rB_contaPoupanca.AutoSize = true;
            this.rB_contaPoupanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rB_contaPoupanca.Location = new System.Drawing.Point(233, 53);
            this.rB_contaPoupanca.Name = "rB_contaPoupanca";
            this.rB_contaPoupanca.Size = new System.Drawing.Size(81, 19);
            this.rB_contaPoupanca.TabIndex = 2;
            this.rB_contaPoupanca.TabStop = true;
            this.rB_contaPoupanca.Text = "Poupança";
            this.rB_contaPoupanca.UseVisualStyleBackColor = true;
            // 
            // lb_infoConta
            // 
            this.lb_infoConta.AutoSize = true;
            this.lb_infoConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_infoConta.Location = new System.Drawing.Point(19, 89);
            this.lb_infoConta.Name = "lb_infoConta";
            this.lb_infoConta.Size = new System.Drawing.Size(154, 16);
            this.lb_infoConta.TabIndex = 0;
            this.lb_infoConta.Text = "Agência: 0  - Conta: 0";
            // 
            // bt_adicionar
            // 
            this.bt_adicionar.Location = new System.Drawing.Point(239, 82);
            this.bt_adicionar.Name = "bt_adicionar";
            this.bt_adicionar.Size = new System.Drawing.Size(75, 23);
            this.bt_adicionar.TabIndex = 5;
            this.bt_adicionar.Text = "Adicionar";
            this.bt_adicionar.UseVisualStyleBackColor = true;
            this.bt_adicionar.Click += new System.EventHandler(this.bt_adicionar_Click);
            // 
            // NovaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 124);
            this.Controls.Add(this.bt_adicionar);
            this.Controls.Add(this.rB_contaPoupanca);
            this.Controls.Add(this.rB_contaCorrente);
            this.Controls.Add(this.tB_titular);
            this.Controls.Add(this.lb_infoConta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NovaConta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NovaConta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_titular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rB_contaCorrente;
        private System.Windows.Forms.RadioButton rB_contaPoupanca;
        private System.Windows.Forms.Label lb_infoConta;
        private System.Windows.Forms.Button bt_adicionar;
    }
}
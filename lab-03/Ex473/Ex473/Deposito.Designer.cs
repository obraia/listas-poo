namespace Ex473
{
    partial class Deposito
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
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_depositar = new System.Windows.Forms.Button();
            this.tB_valor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(71, 35);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_cancelar.TabIndex = 7;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // bt_depositar
            // 
            this.bt_depositar.Location = new System.Drawing.Point(154, 35);
            this.bt_depositar.Name = "bt_depositar";
            this.bt_depositar.Size = new System.Drawing.Size(75, 23);
            this.bt_depositar.TabIndex = 6;
            this.bt_depositar.Text = "Depositar";
            this.bt_depositar.UseVisualStyleBackColor = true;
            this.bt_depositar.Click += new System.EventHandler(this.bt_depositar_Click);
            // 
            // tB_valor
            // 
            this.tB_valor.Location = new System.Drawing.Point(71, 9);
            this.tB_valor.Name = "tB_valor";
            this.tB_valor.Size = new System.Drawing.Size(158, 20);
            this.tB_valor.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Valor:";
            // 
            // Deposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 67);
            this.ControlBox = false;
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_depositar);
            this.Controls.Add(this.tB_valor);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Deposito";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_depositar;
        private System.Windows.Forms.TextBox tB_valor;
        private System.Windows.Forms.Label label1;
    }
}
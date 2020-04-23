namespace Ex473
{
    partial class Saque
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
            this.tB_valor = new System.Windows.Forms.TextBox();
            this.bt_sacar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            // 
            // tB_valor
            // 
            this.tB_valor.Location = new System.Drawing.Point(67, 8);
            this.tB_valor.Name = "tB_valor";
            this.tB_valor.Size = new System.Drawing.Size(158, 20);
            this.tB_valor.TabIndex = 1;
            // 
            // bt_sacar
            // 
            this.bt_sacar.Location = new System.Drawing.Point(150, 34);
            this.bt_sacar.Name = "bt_sacar";
            this.bt_sacar.Size = new System.Drawing.Size(75, 23);
            this.bt_sacar.TabIndex = 2;
            this.bt_sacar.Text = "Sacar";
            this.bt_sacar.UseVisualStyleBackColor = true;
            this.bt_sacar.Click += new System.EventHandler(this.bt_sacar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(67, 34);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_cancelar.TabIndex = 3;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // Saque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 67);
            this.ControlBox = false;
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_sacar);
            this.Controls.Add(this.tB_valor);
            this.Controls.Add(this.label1);
            this.Name = "Saque";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_valor;
        private System.Windows.Forms.Button bt_sacar;
        private System.Windows.Forms.Button bt_cancelar;
    }
}
namespace ULA
{
    partial class Calculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSoma = new System.Windows.Forms.Button();
            this.buttonSubtracao = new System.Windows.Forms.Button();
            this.labelResultado = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxHexa = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxMantissaR = new System.Windows.Forms.TextBox();
            this.textBoxResultadoNumero = new System.Windows.Forms.TextBox();
            this.textBoxExpoenteR = new System.Windows.Forms.TextBox();
            this.textBoxSinalR = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxSinal2 = new System.Windows.Forms.TextBox();
            this.textBoxExpoente2 = new System.Windows.Forms.TextBox();
            this.textBoxMantissa2 = new System.Windows.Forms.TextBox();
            this.labelNumero2 = new System.Windows.Forms.Label();
            this.textBoxNumero2 = new System.Windows.Forms.TextBox();
            this.textBoxHexa2 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxSinal1 = new System.Windows.Forms.TextBox();
            this.textBoxExpoente1 = new System.Windows.Forms.TextBox();
            this.textBoxMantissa1 = new System.Windows.Forms.TextBox();
            this.textBoxHexa1 = new System.Windows.Forms.TextBox();
            this.labelNumero1 = new System.Windows.Forms.Label();
            this.textBoxNumero1 = new System.Windows.Forms.TextBox();
            this.labelNomes = new System.Windows.Forms.Label();
            this.bt_close_window = new System.Windows.Forms.Button();
            this.PanelMove = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.circularButton_converter = new ULA.CircularButton();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PanelMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonSoma);
            this.panel3.Controls.Add(this.buttonSubtracao);
            this.panel3.Controls.Add(this.labelResultado);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.textBoxHexa);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.textBoxMantissaR);
            this.panel3.Controls.Add(this.textBoxResultadoNumero);
            this.panel3.Controls.Add(this.textBoxExpoenteR);
            this.panel3.Controls.Add(this.textBoxSinalR);
            this.panel3.Location = new System.Drawing.Point(294, 241);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 209);
            this.panel3.TabIndex = 55;
            // 
            // buttonSoma
            // 
            this.buttonSoma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonSoma.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSoma.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSoma.Location = new System.Drawing.Point(35, 13);
            this.buttonSoma.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSoma.Name = "buttonSoma";
            this.buttonSoma.Size = new System.Drawing.Size(51, 38);
            this.buttonSoma.TabIndex = 38;
            this.buttonSoma.Text = "+";
            this.buttonSoma.UseVisualStyleBackColor = false;
            this.buttonSoma.Click += new System.EventHandler(this.buttonSoma_Click);
            // 
            // buttonSubtracao
            // 
            this.buttonSubtracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonSubtracao.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubtracao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSubtracao.Location = new System.Drawing.Point(90, 13);
            this.buttonSubtracao.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubtracao.Name = "buttonSubtracao";
            this.buttonSubtracao.Size = new System.Drawing.Size(51, 38);
            this.buttonSubtracao.TabIndex = 39;
            this.buttonSubtracao.Text = "-";
            this.buttonSubtracao.UseVisualStyleBackColor = false;
            this.buttonSubtracao.Click += new System.EventHandler(this.buttonSubtracao_Click);
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.Location = new System.Drawing.Point(84, 71);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(111, 30);
            this.labelResultado.TabIndex = 47;
            this.labelResultado.Text = "Resultado";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(145, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 38);
            this.button2.TabIndex = 40;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBoxHexa
            // 
            this.textBoxHexa.Location = new System.Drawing.Point(81, 184);
            this.textBoxHexa.Name = "textBoxHexa";
            this.textBoxHexa.ReadOnly = true;
            this.textBoxHexa.Size = new System.Drawing.Size(116, 20);
            this.textBoxHexa.TabIndex = 46;
            this.textBoxHexa.Text = "IEEE 754 Hexadecimal";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(200, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 38);
            this.button3.TabIndex = 41;
            this.button3.Text = "÷";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBoxMantissaR
            // 
            this.textBoxMantissaR.Location = new System.Drawing.Point(122, 150);
            this.textBoxMantissaR.Name = "textBoxMantissaR";
            this.textBoxMantissaR.ReadOnly = true;
            this.textBoxMantissaR.Size = new System.Drawing.Size(150, 20);
            this.textBoxMantissaR.TabIndex = 45;
            this.textBoxMantissaR.Text = "Mantissa";
            // 
            // textBoxResultadoNumero
            // 
            this.textBoxResultadoNumero.Location = new System.Drawing.Point(89, 114);
            this.textBoxResultadoNumero.Name = "textBoxResultadoNumero";
            this.textBoxResultadoNumero.ReadOnly = true;
            this.textBoxResultadoNumero.Size = new System.Drawing.Size(100, 20);
            this.textBoxResultadoNumero.TabIndex = 42;
            this.textBoxResultadoNumero.Text = "Resultado";
            // 
            // textBoxExpoenteR
            // 
            this.textBoxExpoenteR.Location = new System.Drawing.Point(49, 150);
            this.textBoxExpoenteR.Name = "textBoxExpoenteR";
            this.textBoxExpoenteR.ReadOnly = true;
            this.textBoxExpoenteR.Size = new System.Drawing.Size(67, 20);
            this.textBoxExpoenteR.TabIndex = 44;
            this.textBoxExpoenteR.Text = "Expoente";
            // 
            // textBoxSinalR
            // 
            this.textBoxSinalR.Location = new System.Drawing.Point(4, 150);
            this.textBoxSinalR.Name = "textBoxSinalR";
            this.textBoxSinalR.ReadOnly = true;
            this.textBoxSinalR.Size = new System.Drawing.Size(39, 20);
            this.textBoxSinalR.TabIndex = 43;
            this.textBoxSinalR.Text = "Sinal";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.labelNumero2);
            this.panel6.Controls.Add(this.textBoxNumero2);
            this.panel6.Controls.Add(this.textBoxHexa2);
            this.panel6.Location = new System.Drawing.Point(556, 8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(294, 168);
            this.panel6.TabIndex = 56;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBoxSinal2);
            this.panel5.Controls.Add(this.textBoxExpoente2);
            this.panel5.Controls.Add(this.textBoxMantissa2);
            this.panel5.Location = new System.Drawing.Point(10, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(276, 31);
            this.panel5.TabIndex = 51;
            // 
            // textBoxSinal2
            // 
            this.textBoxSinal2.Location = new System.Drawing.Point(4, 6);
            this.textBoxSinal2.Name = "textBoxSinal2";
            this.textBoxSinal2.ReadOnly = true;
            this.textBoxSinal2.Size = new System.Drawing.Size(39, 20);
            this.textBoxSinal2.TabIndex = 9;
            this.textBoxSinal2.Text = "Sinal";
            // 
            // textBoxExpoente2
            // 
            this.textBoxExpoente2.Location = new System.Drawing.Point(49, 6);
            this.textBoxExpoente2.Name = "textBoxExpoente2";
            this.textBoxExpoente2.ReadOnly = true;
            this.textBoxExpoente2.Size = new System.Drawing.Size(67, 20);
            this.textBoxExpoente2.TabIndex = 10;
            this.textBoxExpoente2.Text = "Expoente";
            // 
            // textBoxMantissa2
            // 
            this.textBoxMantissa2.Location = new System.Drawing.Point(122, 6);
            this.textBoxMantissa2.Name = "textBoxMantissa2";
            this.textBoxMantissa2.ReadOnly = true;
            this.textBoxMantissa2.Size = new System.Drawing.Size(150, 20);
            this.textBoxMantissa2.TabIndex = 11;
            this.textBoxMantissa2.Text = "Mantissa";
            // 
            // labelNumero2
            // 
            this.labelNumero2.AutoSize = true;
            this.labelNumero2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelNumero2.Location = new System.Drawing.Point(84, 14);
            this.labelNumero2.Name = "labelNumero2";
            this.labelNumero2.Size = new System.Drawing.Size(112, 30);
            this.labelNumero2.TabIndex = 2;
            this.labelNumero2.Text = "Número 2";
            // 
            // textBoxNumero2
            // 
            this.textBoxNumero2.Location = new System.Drawing.Point(90, 49);
            this.textBoxNumero2.Name = "textBoxNumero2";
            this.textBoxNumero2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumero2.TabIndex = 1;
            // 
            // textBoxHexa2
            // 
            this.textBoxHexa2.Location = new System.Drawing.Point(82, 134);
            this.textBoxHexa2.Name = "textBoxHexa2";
            this.textBoxHexa2.ReadOnly = true;
            this.textBoxHexa2.Size = new System.Drawing.Size(116, 20);
            this.textBoxHexa2.TabIndex = 13;
            this.textBoxHexa2.Text = "IEEE 754 Hexadecimal";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.textBoxHexa1);
            this.panel7.Controls.Add(this.labelNumero1);
            this.panel7.Controls.Add(this.textBoxNumero1);
            this.panel7.Location = new System.Drawing.Point(8, 8);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(294, 168);
            this.panel7.TabIndex = 57;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxSinal1);
            this.panel4.Controls.Add(this.textBoxExpoente1);
            this.panel4.Controls.Add(this.textBoxMantissa1);
            this.panel4.Location = new System.Drawing.Point(9, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 31);
            this.panel4.TabIndex = 50;
            // 
            // textBoxSinal1
            // 
            this.textBoxSinal1.Location = new System.Drawing.Point(4, 6);
            this.textBoxSinal1.Name = "textBoxSinal1";
            this.textBoxSinal1.ReadOnly = true;
            this.textBoxSinal1.Size = new System.Drawing.Size(39, 20);
            this.textBoxSinal1.TabIndex = 6;
            this.textBoxSinal1.Text = "Sinal";
            // 
            // textBoxExpoente1
            // 
            this.textBoxExpoente1.Location = new System.Drawing.Point(49, 6);
            this.textBoxExpoente1.Name = "textBoxExpoente1";
            this.textBoxExpoente1.ReadOnly = true;
            this.textBoxExpoente1.Size = new System.Drawing.Size(67, 20);
            this.textBoxExpoente1.TabIndex = 7;
            this.textBoxExpoente1.Text = "Expoente";
            // 
            // textBoxMantissa1
            // 
            this.textBoxMantissa1.Location = new System.Drawing.Point(122, 6);
            this.textBoxMantissa1.Name = "textBoxMantissa1";
            this.textBoxMantissa1.ReadOnly = true;
            this.textBoxMantissa1.Size = new System.Drawing.Size(150, 20);
            this.textBoxMantissa1.TabIndex = 8;
            this.textBoxMantissa1.Text = "Mantissa";
            // 
            // textBoxHexa1
            // 
            this.textBoxHexa1.Location = new System.Drawing.Point(89, 134);
            this.textBoxHexa1.Name = "textBoxHexa1";
            this.textBoxHexa1.ReadOnly = true;
            this.textBoxHexa1.Size = new System.Drawing.Size(116, 20);
            this.textBoxHexa1.TabIndex = 12;
            this.textBoxHexa1.Text = "IEEE 754 Hexadecimal";
            // 
            // labelNumero1
            // 
            this.labelNumero1.AutoSize = true;
            this.labelNumero1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero1.Location = new System.Drawing.Point(91, 14);
            this.labelNumero1.Name = "labelNumero1";
            this.labelNumero1.Size = new System.Drawing.Size(112, 30);
            this.labelNumero1.TabIndex = 1;
            this.labelNumero1.Text = "Número 1";
            // 
            // textBoxNumero1
            // 
            this.textBoxNumero1.Location = new System.Drawing.Point(97, 49);
            this.textBoxNumero1.Name = "textBoxNumero1";
            this.textBoxNumero1.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumero1.TabIndex = 0;
            // 
            // labelNomes
            // 
            this.labelNomes.AutoSize = true;
            this.labelNomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomes.Location = new System.Drawing.Point(531, 466);
            this.labelNomes.Name = "labelNomes";
            this.labelNomes.Size = new System.Drawing.Size(331, 16);
            this.labelNomes.TabIndex = 58;
            this.labelNomes.Text = "Bryan Diniz | Luiz Henrique | Maria Luiza | Thaís Lorentz";
            // 
            // bt_close_window
            // 
            this.bt_close_window.BackColor = System.Drawing.Color.Transparent;
            this.bt_close_window.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_close_window.BackgroundImage")));
            this.bt_close_window.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_close_window.FlatAppearance.BorderSize = 0;
            this.bt_close_window.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close_window.ForeColor = System.Drawing.Color.Transparent;
            this.bt_close_window.Location = new System.Drawing.Point(831, 6);
            this.bt_close_window.Name = "bt_close_window";
            this.bt_close_window.Size = new System.Drawing.Size(25, 25);
            this.bt_close_window.TabIndex = 59;
            this.bt_close_window.UseVisualStyleBackColor = false;
            this.bt_close_window.Click += new System.EventHandler(this.bt_close_window_Click);
            // 
            // PanelMove
            // 
            this.PanelMove.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PanelMove.Controls.Add(this.pictureBoxIcon);
            this.PanelMove.Controls.Add(this.bt_close_window);
            this.PanelMove.Controls.Add(this.label1);
            this.PanelMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelMove.Location = new System.Drawing.Point(0, 0);
            this.PanelMove.Name = "PanelMove";
            this.PanelMove.Size = new System.Drawing.Size(866, 38);
            this.PanelMove.TabIndex = 60;
            this.PanelMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseMove);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(6, 7);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 62;
            this.pictureBoxIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "Calculadora IEEE754 (Subtração em desenvolvimento)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.circularButton_converter);
            this.panel1.Location = new System.Drawing.Point(5, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 185);
            this.panel1.TabIndex = 61;
            // 
            // circularButton_converter
            // 
            this.circularButton_converter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.circularButton_converter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circularButton_converter.FlatAppearance.BorderSize = 0;
            this.circularButton_converter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton_converter.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.circularButton_converter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.circularButton_converter.Location = new System.Drawing.Point(370, 38);
            this.circularButton_converter.Name = "circularButton_converter";
            this.circularButton_converter.Size = new System.Drawing.Size(125, 125);
            this.circularButton_converter.TabIndex = 54;
            this.circularButton_converter.Text = "Converter";
            this.circularButton_converter.UseVisualStyleBackColor = false;
            this.circularButton_converter.Click += new System.EventHandler(this.circularButton_converter_Click);
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(866, 487);
            this.ControlBox = false;
            this.Controls.Add(this.labelNomes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PanelMove);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Calculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.PanelMove.ResumeLayout(false);
            this.PanelMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSoma;
        private System.Windows.Forms.Button buttonSubtracao;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxHexa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxMantissaR;
        private System.Windows.Forms.TextBox textBoxResultadoNumero;
        private System.Windows.Forms.TextBox textBoxExpoenteR;
        private System.Windows.Forms.TextBox textBoxSinalR;
        private CircularButton circularButton_converter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBoxSinal2;
        private System.Windows.Forms.TextBox textBoxExpoente2;
        private System.Windows.Forms.TextBox textBoxMantissa2;
        private System.Windows.Forms.Label labelNumero2;
        private System.Windows.Forms.TextBox textBoxNumero2;
        private System.Windows.Forms.TextBox textBoxHexa2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxSinal1;
        private System.Windows.Forms.TextBox textBoxExpoente1;
        private System.Windows.Forms.TextBox textBoxMantissa1;
        private System.Windows.Forms.TextBox textBoxHexa1;
        private System.Windows.Forms.Label labelNumero1;
        private System.Windows.Forms.TextBox textBoxNumero1;
        private System.Windows.Forms.Label labelNomes;
        private System.Windows.Forms.Button bt_close_window;
        private System.Windows.Forms.Panel PanelMove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}
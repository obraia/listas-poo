using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Move Panel
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ULA
{
    public partial class Calculadora : Form
    {
        static float decimalA, decimalB;

        // Move Panel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
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

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        public Calculadora()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void circularButton_converter_Click(object sender, EventArgs e)
        {
            try
            {
                decimalA = float.Parse(textBoxNumero1.Text);
                decimalB = float.Parse(textBoxNumero2.Text);
            }
            catch
            {
                MessageBox.Show("Digite um número válido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool[] A = Conversores.PontoFlutuanteParaBinario(decimalA);
            string binarioA = Conversores.BoolParaString(A);
            string hexaDecimalA = Conversores.BinarioParaHexa(binarioA);
            string sinalA = ManipularBinario.ObterSinal1Bit(A);
            string expoenteBinarioA = ManipularBinario.ObterExpoente8bit(A);
            int expoenteA = Conversores.BinarioParaDecimal(ManipularBinario.ObterExpoente8bit(A), 8) - 127;
            string mantissaA = ManipularBinario.ObterMantissa23bit(A);

            bool[] B = Conversores.PontoFlutuanteParaBinario(decimalB);
            string binarioB = Conversores.BoolParaString(B);
            string hexaDecimalB = Conversores.BinarioParaHexa(binarioB);
            string sinalB = ManipularBinario.ObterSinal1Bit(B);
            string expoenteBinarioB = ManipularBinario.ObterExpoente8bit(B);
            int expoenteB = Conversores.BinarioParaDecimal(ManipularBinario.ObterExpoente8bit(B), 8) - 127;
            string mantissaB = ManipularBinario.ObterMantissa23bit(B);

            textBoxSinal1.Text = sinalA;
            textBoxExpoente1.Text = expoenteBinarioA;
            textBoxMantissa1.Text = mantissaA;
            textBoxHexa1.Text = hexaDecimalA;

            textBoxSinal2.Text = sinalB;
            textBoxExpoente2.Text = expoenteBinarioB;
            textBoxMantissa2.Text = mantissaB;
            textBoxHexa2.Text = hexaDecimalB;
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            try
            {
                decimalA = float.Parse(textBoxNumero1.Text);
                decimalB = float.Parse(textBoxNumero2.Text);

                // textBoxResultadoNumero.Text = (decimalA + decimalB).ToString();

                if ((decimalA >= 0) && (decimalB >= 0))
                {
                    Soma(decimalA, decimalB, true, "0");
                }
                else if ((decimalA >= 0) && (decimalB <= 0) && (Math.Abs(decimalB) < decimalA))
                {
                    Soma(decimalA, decimalB, false, "0");
                }
                else if ((decimalA >= 0) && (decimalB <= 0) && (Math.Abs(decimalB) > decimalA))
                {
                    Soma(decimalB, decimalA, false, "1");
                }
                else if ((decimalA <= 0) && (decimalB >= 0) && (Math.Abs(decimalA) > decimalB))
                {
                    // decimalA *= -1;
                    Soma(decimalA, decimalB, false, "1");
                }
                else if ((decimalA <= 0) && (decimalB >= 0) && (Math.Abs(decimalB) > decimalA))
                {
                    //  decimalA *= -1;
                    Soma(decimalB, decimalA, false, "0");
                }
                else if ((decimalA <= 0) && (decimalB <= 0))
                {
                    //  decimalA *= -1;
                    Soma(decimalA, decimalB, true, "1");
                }
            }
            catch
            {
                MessageBox.Show("Digite um número válido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSubtracao_Click(object sender, EventArgs e)
        {

            decimalA = float.Parse(textBoxNumero1.Text);
            decimalB = float.Parse(textBoxNumero2.Text);

            //  textBoxResultadoNumero.Text = (decimalA - decimalB).ToString();

            if ((decimalA >= 0) && (decimalB >= 0) && (decimalA > decimalB))
            {
                decimalB *= -1;
                Soma(decimalA, decimalB, false, "0");
            }
            else if ((decimalA >= 0) && (decimalB >= 0) && (decimalB > decimalA))
            {
                decimalB *= -1;
                Soma(decimalA, decimalB, false, "1");
            }
            else if ((decimalA >= 0) && (decimalB <= 0))
            {
                decimalB *= -1;
                Soma(decimalA, decimalB, true, "0");
            }
            else if ((decimalA <= 0) && (decimalB >= 0))
            {
                decimalB *= -1;
                Soma(decimalA, decimalB, true, "1");
            }
            else if ((decimalA <= 0) && (decimalB <= 0))
            {
                decimalB *= -1;
                Soma(decimalA, decimalB, true, "1");
            }
        }

        private void bt_close_window_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Soma(float decimalA, float decimalB, bool soma, string sinal)
        {
            Somador32Bit somador32 = new Somador32Bit();
            Somador8Bit somador8 = new Somador8Bit();



            bool overflow = false;

            bool[] A = Conversores.PontoFlutuanteParaBinario(decimalA);
            string binarioA = Conversores.BoolParaString(A);
            string hexaDecimalA = Conversores.BinarioParaHexa(binarioA);
            string sinalA = ManipularBinario.ObterSinal1Bit(A);

            int expoenteA = Conversores.BinarioParaDecimal(ManipularBinario.ObterExpoente8bit(A), 8) - 127;
            string mantissaA = ManipularBinario.ObterMantissa23bit(A);
            string expoenteFinal = "";
            int deslocar = 0;
            bool[] resultadoSomaMantisas = null;

            bool[] B = Conversores.PontoFlutuanteParaBinario(decimalB);
            string binarioB = Conversores.BoolParaString(B);
            string hexaDecimalB = Conversores.BinarioParaHexa(binarioB);
            string sinalB = ManipularBinario.ObterSinal1Bit(B);
            int expoenteB = Conversores.BinarioParaDecimal(ManipularBinario.ObterExpoente8bit(B), 8) - 127;
            string mantissaB = ManipularBinario.ObterMantissa23bit(B);

            // se os dois número forem iguais a zero
            if ((decimalA == decimalB) && (decimalA == 0))
            {
                textBoxResultadoNumero.Text = "0";
                textBoxSinalR.Text = "0";
                textBoxExpoenteR.Text = "00000000";
                textBoxMantissaR.Text = "00000000000000000000000";
                textBoxHexa.Text = "0x00000000";
            }
            else if (decimalA == 0)
            {
                textBoxResultadoNumero.Text = decimalB.ToString();
                textBoxSinalR.Text = ManipularBinario.ObterSinal1Bit(B);
                textBoxExpoenteR.Text = ManipularBinario.ObterExpoente8bit(B);
                textBoxMantissaR.Text = ManipularBinario.ObterMantissa23bit(B);
                textBoxHexa.Text = Conversores.BinarioParaHexa(binarioB);
            }
            else if (decimalB == 0)
            {
                textBoxResultadoNumero.Text = decimalA.ToString();
                textBoxSinalR.Text = ManipularBinario.ObterSinal1Bit(A);
                textBoxExpoenteR.Text = ManipularBinario.ObterExpoente8bit(A);
                textBoxMantissaR.Text = ManipularBinario.ObterMantissa23bit(A);
                textBoxHexa.Text = Conversores.BinarioParaHexa(binarioB);
            }
            else
            {
                mantissaA = ManipularBinario.Adicionar1(mantissaA);
                mantissaB = ManipularBinario.Adicionar1(mantissaB);

                if (expoenteB > expoenteA)
                {
                    expoenteFinal = ManipularBinario.ObterExpoente8bit(B);
                    deslocar = Math.Abs(expoenteA - expoenteB);
                    mantissaA = ManipularBinario.Deslocamento(mantissaA, deslocar);
                }
                else if (expoenteA > expoenteB)
                {
                    expoenteFinal = ManipularBinario.ObterExpoente8bit(A);
                    deslocar = Math.Abs(expoenteB - expoenteA);
                    mantissaB = ManipularBinario.Deslocamento(mantissaB, deslocar);
                }
                else if (expoenteA == expoenteB)
                {
                    expoenteFinal = ManipularBinario.ObterExpoente8bit(A);
                }

                if (soma == false)
                {
                    mantissaB = ManipularBinario.ComplementoDe2(mantissaB);
                }

                bool[] BinarioA = Conversores.StringParaBool(mantissaA, 24);
                bool[] BinarioB = Conversores.StringParaBool(mantissaB, 24);
                resultadoSomaMantisas = somador32.Somador(BinarioA, BinarioB, ref overflow, soma);

                string somaMantissas = Conversores.BoolParaString(resultadoSomaMantisas);
                //somaMantissas = ManipularBinario.AlinhaResultadoMantissa(somaMantissas);
                somaMantissas = ManipularBinario.Remover1(somaMantissas);

                if (overflow == true && soma == true)
                {
                    expoenteFinal = Conversores.BoolParaString(somador8.Somador(Conversores.StringParaBool(expoenteFinal, 8), Conversores.StringParaBool("00000001", 8), ref overflow));
                }
                else if (overflow == true && soma == false)
                {
                    //somaMantissas = ManipularBinario.NormalizarAposSoma(somaMantissas, ref expoenteFinal);
                }

                somaMantissas = ManipularBinario.ArredondarBinario(somaMantissas);

                string IEEE754_Binario = ManipularBinario.Gerar_IEEE754(sinal, expoenteFinal, somaMantissas);
                string IEEE754_Hexa = Conversores.BinarioParaHexa(IEEE754_Binario);

                bool[] resultado = Conversores.StringParaBool(IEEE754_Binario, 32);

                sinal = ManipularBinario.ObterSinal1Bit(resultado);
                string expoente = ManipularBinario.ObterExpoente8bit(resultado);
                string mantissa = ManipularBinario.ObterMantissa23bit(resultado);

                textBoxResultadoNumero.Text = Conversores.BinarioFlutuanteParaDecimal(resultado).ToString();
                textBoxSinalR.Text = sinal;
                textBoxExpoenteR.Text = expoente;
                textBoxMantissaR.Text = mantissa;
                textBoxHexa.Text = IEEE754_Hexa;
            }
        }
    }
}

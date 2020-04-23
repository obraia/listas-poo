using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class ManipularBinario
    {
        public static string ComplementoDe2(string mantissa)
        {
            ComplementoDe2 complemento = new ComplementoDe2();
            bool overflow = false;

            bool[] mantissaBool = Conversores.StringParaBool(mantissa, 24);
            bool[] Um = Conversores.StringParaBool("00000000000000000000001", 24);

            for (int i = 0; i < mantissaBool.Length; i++)
            {
                if (mantissaBool[i] == true) mantissaBool[i] = false;
                else mantissaBool[i] = true;
            }

            mantissaBool = complemento.complemento2(mantissaBool, Um, ref overflow);

            return Conversores.BoolParaString(mantissaBool).PadRight(24, '0');
        }

        public static string ObterSinal1Bit(bool[] binario)
        {
            string binarioS = "";
            string sinal = "";

            binarioS = Conversores.BoolParaString(binario);
            sinal = binarioS.Substring(0, 1);

            return sinal;
        }

        public static string ObterExpoente8bit(bool[] binario)
        {
            string binarioS = "";
            string expoente = "";

            binarioS = Conversores.BoolParaString(binario);
            expoente = binarioS.Substring(1, 8);

            return expoente;
        }

        public static string ObterMantissa23bit(bool[] binario)
        {
            string binarioS = "";
            string mantissa = "";

            binarioS = Conversores.BoolParaString(binario);
            mantissa = binarioS.Substring(9, 23);

            return mantissa;
        }

        public static string Deslocamento(string binario, int deslocar)
        {
            if (deslocar > 0)
            {
                string binarioAlinhado = binario.PadLeft(24 + deslocar, '0');

                return binarioAlinhado.Substring(0, 24);
            }
            else
            {
                deslocar = (deslocar * -1);

                string binarioAlinhado = binario.PadRight(25 + deslocar, '0');

                return binarioAlinhado.Substring(1, 25);
            }
        }

        // adicionar 1 implícito a mantissa
        public static string Adicionar1(string binario)
        {
            binario = "1" + binario;

            // binario = binario.PadRight(24, '0');

            return binario.Substring(0, 24);
        }

        // remover 1 implícito da mantissa
        public static string Remover1(string binario)
        {
            binario = binario.Remove(0, 1);

            binario = binario.PadRight(23, '0');

            return binario.Substring(0, 23);
        }

        // arredontar binário somando 1 a mantissa
        public static string ArredondarBinario(string binario)
        {

            if ((binario[binario.Length - 1] == '1') && (binario[binario.Length - 2] == '1'))
            {
                bool[] Binario = Conversores.StringParaBool(binario, 24);
                bool[] arredondar = new bool[24];
                bool overflow = false;

                arredondar[22] = true;
                Somador32Bit somador = new Somador32Bit();
                bool[] resultado = somador.Somador(Binario, arredondar, ref overflow, false);
                return Conversores.BoolParaString(resultado).Substring(0, 23);
            }

            return binario.Substring(0, 23);
        }

        public static string AlinhaResultadoMantissa(string binario)
        {
            if (binario[0] == '1')
            {
                binario = binario.Remove(0, 2);
                binario = binario.PadLeft(23, '0');
            }

            return binario;
        }

        public static string Gerar_IEEE754(string sinal, string expoente, string mantissa)
        {
            return sinal + expoente + mantissa;
        }
    }
}

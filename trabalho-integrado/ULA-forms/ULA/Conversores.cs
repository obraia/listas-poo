using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULA
{
    class Conversores
    {
        // Converte um binário IEEE754 para decimal
        public static double BinarioFlutuanteParaDecimal(bool[] binario)
        {
            string sinal = "";
            string expoente = "";
            string mantissa = "";
            double expoenteReal = 0;

            sinal = ManipularBinario.ObterSinal1Bit(binario);
            expoente = ManipularBinario.ObterExpoente8bit(binario);
            expoenteReal = Conversores.BinarioParaDecimal(expoente, 8) - 127;

            mantissa = ManipularBinario.ObterMantissa23bit(binario);

            double parteFlutuante = 0;

            for (double i = 0; i < mantissa.Length; i++)
            {
                if (mantissa[(int)i] == '0')
                {
                    parteFlutuante += 0 * Math.Pow(2.0, (i+1) * (-1));
                }
                else
                {
                    parteFlutuante += 1 * Math.Pow(2.0, (i+1) * (-1));
                }
            }

            if (sinal[0] == '0')
            {
                parteFlutuante = (1 + parteFlutuante) * Math.Pow(2.0, expoenteReal);
            }
            else
            {
                parteFlutuante = ((1 + parteFlutuante) * Math.Pow(2.0, expoenteReal) * -1);
            }

            return parteFlutuante;
        }

        // converte string binario para inteiro decimal
        public static int BinarioParaDecimal(string binario, byte tam)
        {
            byte i;
            int x;
            int bit;
            x = 0;

            for (i = 0; i < tam; i++)
            {
                if (binario[i] == '1') { bit = 1; } else { bit = 0; }

                x = x + bit * (int)Math.Pow(2, 7 - i);
            }

            return x;
        }

        // converte um número float para binário no formato IEEE754
        public static bool[] PontoFlutuanteParaBinario(float flutuante)
        {
            // .TrimStart(new Char[] { '0' } remove zeros a esquerda da string

            float numeroF = 0;
            int parteInteira = 0;
            float parteFlutuante = 0;
            char sinal;
            string binarioInteiro = "";
            string binarioFlutuante = "";
            int expoente = 0;
            int expoentePolarizado = 0;
            string expoentePolarizadoBinario = "";
            string mantissa = "";
            string flutuanteNormalizado = "";
            string binarioFinal = "";

            numeroF = flutuante;

            if (numeroF < 0)
            {
                sinal = '1';
                numeroF *= -1;
            }
            else
            {
                sinal = '0';
            }

            parteInteira = (int)numeroF;
            parteFlutuante = numeroF - parteInteira;

            binarioInteiro = Conversores.InteiroParaBinario(parteInteira, 32).TrimStart(new Char[] { '0' });

            if (parteFlutuante > 0)
            {
                binarioFlutuante = Conversores.FlutuanteParaBinario(parteFlutuante);
            }

            if (parteInteira > 0)
            {
                expoente = binarioInteiro.Length - 1;
                expoentePolarizado = (binarioInteiro.Length - 1) + 127;
                mantissa = (binarioInteiro + binarioFlutuante).Remove(0, 1);
            }
            else if (parteInteira == 0 && parteFlutuante == 0)
            {
                expoentePolarizado = 0;
            }
            else
            {
                flutuanteNormalizado = binarioFlutuante.TrimStart(new Char[] { '0' });
                flutuanteNormalizado = flutuanteNormalizado.Remove(0, 1);

                expoente = -(binarioFlutuante.Length - flutuanteNormalizado.Length);
                expoentePolarizado = (127 - (binarioFlutuante.Length - flutuanteNormalizado.Length));
                mantissa = flutuanteNormalizado;

            }

            expoentePolarizadoBinario = Conversores.InteiroParaBinario(expoentePolarizado, 8);

            binarioFinal = sinal + expoentePolarizadoBinario + mantissa;

            bool[] IEEE754 = Conversores.StringParaBool(binarioFinal, 32);

            return IEEE754;
        }

        // converte número inteiro em binário
        public static string InteiroParaBinario(int numeroDecimal, int bits)
        {
            char[] binario = new char[bits];
            int x = numeroDecimal;

            for (int i = 0; i < binario.Length; i++)
            {
                if ((x % 2) == 1)
                {
                    binario[bits - 1 - i] = '1';
                }
                else
                {
                    binario[bits - 1 - i] = '0';
                }
                x = x / 2;
            }
            return new string(binario);
        }

        // converte parte flutuante de um número para binário
        public static string FlutuanteParaBinario(float parteFlutuante)
        {
            char[] flutuante = new char[32];
            char[] mantissa = null;
            float x = parteFlutuante;
            int a;
            int i = 0;

            try
            {
                for (i = 0; i < flutuante.Length; i++)
                {
                    x *= 2;
                    a = (int)x;
                    if (a == 1) flutuante[i] = '1';
                    else flutuante[i] = '0';

                    if (x >= 1)
                    {
                        x = x - 1;
                        if (x == 0) break;
                    }
                }

                mantissa = new char[i + 1];

                for (int j = 0; j < mantissa.Length; j++)
                {
                    mantissa[j] = flutuante[j];
                }
            }
            catch { }

            return new string(mantissa);
        }

        // converte binario em vetor de bool para string
        public static string BoolParaString(bool[] binario)
        {
            char[] binarioChar = new char[binario.Length];

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == true)
                {
                    binarioChar[i] = '1';
                }
                else
                {
                    binarioChar[i] = '0';
                }
            }
            return new string(binarioChar);
        }

        // converte binario em string para vetor de bool
        public static bool[] StringParaBool(string binarioS, int tamanho)
        {
            bool[] binario = new bool[tamanho];
            try
            {
                for (int i = 0; i < tamanho; i++)
                {
                    if (binarioS[i] == '1')
                    {
                        binario[i] = true;
                    }
                    else
                    {
                        binario[i] = false;
                    }
                }
            }
            catch { }

            return binario;
        }

        // imprime na tela o número binário a partir de um vetor de bool
        public static void ImprimirBinario(bool[] binario)
        {
            char[] binarioChar = new char[binario.Length];

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == true)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
            }
        }

        // converte uma string de binário para hexadecimal IEEE754
        public static string BinarioParaHexa(string binario)
        {
            string[] tabela = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            string[] valor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string[] resultado = new string[8];
            string[] aux = new string[8];
            string sinal;
            int a = 0;

            // separar sinal
            if (binario[0] == '0') { sinal = "0"; }
            else { sinal = "1"; }

            // remover sinal do IEEE754 e acrescentar zero a esquerda para a conversão
            binario = "0" + binario.Substring(1, 31);

            // separar string do binario em grupos de 4 bits
            for (int i = 7; i >= 0; i--)
            {
                aux[i] = binario.Substring((28 - a), 4);
                a = a + 4;
            }

            // comparar grupos de 4 bits com a tabela
            for (int i = 0; i < aux.Length; i++)
            {
                for (int j = 0; j < tabela.Length; j++)
                {
                    if (aux[i] == tabela[j])
                    {
                        resultado[i] = valor[j];
                    }
                }
            }

            return sinal + "x" + string.Join("", resultado);
        }
    }
}

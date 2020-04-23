using System;

namespace Ex31
{
    class Date5
    {

        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }

        private String[] NomeMes = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho ", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

        private int[] NumDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public Date5(int dia, int mes, int ano) // Construtor para inicializar data
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;

            if (Bissexto() == true)
            {
                NumDias[1] = 29; // até 29 de fervereiro se ano for fissexto
            }
            else
            {
                NumDias[1] = 28; // até 28 de fervereiro se ano não for Bissexto
            }
        }

        private bool Bissexto() // verificar se um ano é ou não Bissexto
        {
            if (Ano % 4 != 0) return false;
            else if (Ano % 100 != 0) return true;
            else if (Ano % 400 != 0) return false;
            else return true;
        }

        public void ProximoDia() // avançar para o próximo dia de uma data
        {
            if (Bissexto() == true)
            {
                NumDias[1] = 29; // até 29 de fervereiro se ano for bissexto
            }
            else
            {
                NumDias[1] = 28; // até 28 de fervereiro se ano não for bissexto
            }
			
            if ((Dia == NumDias[Mes - 1]) && (Mes < 12))
            {
                Dia = 1;
                Mes++;
            }
            else if ((Dia == NumDias[Mes - 1]) && (Mes == 12))
            {
                Dia = 1;
                Mes = 1;
                Ano++;
            }
            else Dia++;
        }

        private static bool MaiorData(Date5 data1, Date5 data2) // método para verificar maior data
        {
            bool data1Maior = false;

            // TESTAR DATAS DO MESMO ANO
            if ((data1.Ano == data2.Ano) && (data1.Mes > data2.Mes)) data1Maior = true;
            else data1Maior = false;

            if ((data1.Ano == data2.Ano) && (data1.Mes > data2.Mes) && (data1.Dia >= data2.Dia)) data1Maior = true;
            else data1Maior = false;

            // TESTAR DATAS DE ANOS DIFERENTES
            if (data1.Ano > data2.Ano)
            {
                data1Maior = true;
            }
            else
            {
                data1Maior = false;
            }

            return data1Maior;
        }

        public static int DiffDias(Date5 data1, Date5 data2) // obeter diferença de dias entre duas datas
        {
            bool data1Maior = MaiorData(data1, data2); // testar qual será a maior data
            bool loop = true;
            int cont = -1; // variável para contar números de dias que será percorrido

            if (data1Maior == true) // se Data1 for maior a Data2 irá percorrer até ela
            {
                while (loop == true)
                {
                    if (data2.ToString() == data1.ToString()) // Se data2 for igual a data1, terminar repetição
                    {
                        loop = false;
                    }

                    data2.ProximoDia(); // Ir para próximo dia da data
                    cont++; // Armazenar quantos dias foi percorrido
                }
            }
            else
            {
                while (loop == true)
                {
                    if (data1.ToString() == data2.ToString())
                    {
                        loop = false;
                    }

                    data1.ProximoDia(); // Ir para próximo dia da data
                    cont++; // Armazenar quantos dias foi percorrido
                }
            }

            return cont;
        }

        public int DiaDoAno() // mostrar posição do dia em uma data
        {
            int diaPos = 0;

            // EX: 25/03/2019 --> Mes 1 = 31 dias, Mes 2 = 28, já o Mes 3 (atual) = 25 dias ---> 31 + 28 + 25 = 84

            for (int i = 0; i < Mes-1; i++) // percorrer vetor com dias dos meses
            {
                diaPos += NumDias[i]; // adicionando dias dos meses anteriores
            }

            diaPos += Dia; // adicionando dias do mês atual

            return diaPos;
        }

        public bool DataValida() // Verificar validade de uma data
        {
            bool validate = false;

            try
            {
                if ((Mes >= 1) && (Mes <= 12))
                {
                    validate = true;
                }
                else validate = false;

                if ((Dia > 0) && (Dia <= NumDias[Mes - 1]) && (validate == true))
                {
                    validate = true;
                }
                else validate = false;

                if ((Ano >= 1) && (validate == true))
                {
                    validate = true;
                }
                else validate = false;
            }
            catch
            {
                validate = false;
            }

            return validate;
        }


        public String MostrarData() // Mostrar data por extenso
        {
            return Dia.ToString("D2") + " de " + NomeMes[Mes - 1] + " de " + Ano.ToString("D4");
        }

        public override string ToString() // Retornar data do tipo dd/mm/aaaa
        {
            return Dia.ToString("D2") + "/" + Mes.ToString("D2") + "/" + Ano.ToString("D4");
        }

    }
}

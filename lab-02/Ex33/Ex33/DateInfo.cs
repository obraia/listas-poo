using System;

namespace Ex33
{
    public class DateInfo
    {
        static int dataH = 2019;  // armazenar ano para calcular idade

        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }

        private String[] NomeMes = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho ", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

        private int[] NumDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public DateInfo(int dia, int mes, int ano) // Construtor para inicializar data
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

        public static int Idade(string dataS) // retornar idade de uma pessoa
        {
            var array = dataS.Split('/');
            int ano = int.Parse(array[2]);

            return dataH - ano;
        }

        public static bool ValidDate(string dataS) // validar data do formato dd/mm/aaaa
        {
            int dia;
            int mes;
            int ano;

            try
            {
                var array = dataS.Split('/');

                dia = int.Parse(array[0]);
                mes = int.Parse(array[1]);
                ano = int.Parse(array[2]);

            }
            catch
            {
                dia = 0;
                mes = 0;
                ano = 0;
            }
            DateInfo data = new DateInfo(dia, mes, ano);

            return data.DataValida();
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

        public string MostrarData() // Mostrar data por extenso
        {
            return Dia.ToString("D2") + " de " + NomeMes[Mes - 1] + " de " + Ano.ToString("D4");
        }

        public override string ToString() // Retornar data do tipo dd/mm/aaaa
        {
            return Dia.ToString("D2") + "/" + Mes.ToString("D2") + "/" + Ano.ToString("D4");
        }
    }
}

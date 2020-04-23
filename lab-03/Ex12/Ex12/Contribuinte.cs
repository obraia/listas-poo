using System;

namespace Ex12
{
    abstract class Contribuinte
    {
        public static int Cont = 0; // contador de contribuintes cadastrados 
        const int MaxContribuintes = 100; // número máximo de contas suportado
        public static Contribuinte[] VetContribuintes = new Contribuinte[MaxContribuintes]; //vetor de contribuintes

        public String Nome { get; protected set; }
        public String Endereco { get; protected set; }
        public int NumeroInscricao { get; protected set; }

        protected bool PFisica; // true para pessoa física, false para pessoa jurídica
        public bool ContribuinteStatus { get; protected set; } // definir se uma conta está ou não ativa


        public Contribuinte(String nome, String endereco, bool pfisica, bool contribuinteStatus) // construtor para instânciar contribuinte válido
        {
            Nome = nome;
            Endereco = endereco;
            PFisica = pfisica;
            NumeroInscricao = Cont + 1;
            ContribuinteStatus = contribuinteStatus;
        }

        public static bool AddContribuinte(Contribuinte contribuinte) // método para adicionar contribuinte ao vetor
        {
            bool confirm = false;

            if (Cont < MaxContribuintes)
            {
                VetContribuintes[Cont] = contribuinte;
                Cont++;
                confirm = true;
            }
            else
            {
                confirm = false;
            }
            return confirm;
        }

        public static bool ExcluirContribuinte(int numInsc) // método para excluir um contribuinte
        {
            bool confirm = false;

            if (numInsc <= Cont && VetContribuintes[numInsc].ContribuinteStatus == true)
            {
                VetContribuintes[numInsc].ContribuinteStatus = false;

                confirm = true;
            }
            else
            {
                confirm = false;
            }

            return confirm;
        }

        public static bool ExibirDadosContribuinte(int numInsc) // método para imprimir informações gerais de um contribuinte
        {
            bool confirm = false;

            if (numInsc <= Cont && VetContribuintes[numInsc].ContribuinteStatus == true)
            {
                Console.WriteLine(VetContribuintes[numInsc].MostrarInformacoes());

                confirm = true;
            }
            else
            {
                confirm = false;
            }

            return confirm;
        }

        public static bool ImpostoContribuinte(int numInsc) // método para imprimir imposto de um contribuinte
        {
            bool confirm = false;

            if (numInsc <= Cont && VetContribuintes[numInsc].ContribuinteStatus == true)
            {
                Console.WriteLine("\n {0} pagará R${1} de Imposto de Renda \n", VetContribuintes[numInsc].Nome, VetContribuintes[numInsc].CalcImposto().ToString("F2"));

                confirm = true;
            }
            else
            {
                confirm = false;
            }

            return confirm;
        }

        public static void InfoTodosContribuintes(bool pfisica) // mostrar informações de todos os contribuintes -> 
        {
            //bool pfisica = true, exibirá informações  dos contribuintes pessoa física
            //bool pfisica = false, exibirá informações dos contribuintes pessoa jurídica

            for (int i = 0; i < Cont; i++) // percorrer vetor até o número de contas cadastradas (Cont)
            {
                if (VetContribuintes[i].PFisica == pfisica && VetContribuintes[i].ContribuinteStatus == true)
                {
                    Console.WriteLine(VetContribuintes[i]);
                }
            }
        }

        //MÉTODOS A SEREM SOBREESCRITOS PELAS CLASSES FILHAS

        abstract public double CalcImposto(); // método que será sobreescrito para calcular e retornar valor do imposto

        abstract public string MostrarInformacoes(); // método para exibir informações do contribuinte que será sobreescrito

        abstract public string EscreverArquivo();
    }
}

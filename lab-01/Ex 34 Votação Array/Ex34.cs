//
// nome do programa: 
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 14/08/2019
// entrada(s): numero de eleitores e numero no qual cada um irá votar
// o numero de matricula (6 dígitos)e o nome completo dos alunos
// saida(s): resultado dos votos inseridos em numero de votos e porcentagem
// para executar  e testar digite: Ex34.exe 5
// descricao: um programa que funciona a partir de linhas de comandos em que sera inserido um numero de eleitors
// apos todos esses eleitores efeiturem seus votos, sera mostrado o resultado, e caso de um segundo turno, uma
// segunda eleição será chamada
//

using System;

namespace Ex34
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de método para mostrar nomes do integrantes do trabalho

            try // try usado para previnir erros ao receber parametros invalidos pelo args
            {
                int eleitores = int.Parse(args[0]); // converter entrada args para inteiro
                AddCandidatos(eleitores); // chamada de método inicial
            }
            catch
            {
                Console.WriteLine("Valor inválido");
            }
        }

        static void AddCandidatos(int eleitores) // método para adicionar os candidatos
        {
			// para adicionar um candidado basta instânciar um novo objeto, e adiciona-lo no vetor Candidatos
			// contrutor Candidato: (string nome, int numero, int idade)
            Candidato Machado = new Candidato("Machado de Assis", 19, 69);
            Candidato Guimaraes = new Candidato("Guimarães Rosa", 21, 59);
            Candidato Cecilia = new Candidato("Cecília Meireles", 33, 63);
			
			Candidato Drummond = new Candidato("Carlos Drummond de Andrade", 48, 84);
			

            Candidato[] Candidatos = new Candidato[] { Machado, Guimaraes, Cecilia, Drummond }; // vetor para armazenar candidatos

            Candidato Branco = new Candidato("Branco", 0); // instanciando objeto para o voto Branco
            Candidato Nulo = new Candidato("Nulo"); // instanciando objeto para o voto Nulo

            Candidato[] Invalidos = new Candidato[] { Branco, Nulo }; // vetor para armazenar votos nulos e brancos

            Votacao(eleitores, Candidatos, Invalidos); // chamada do método para iniciar a votação 
        }

        static void Votacao(int eleitores, Candidato[] candidatos, Candidato[] invalidos) // método para apresentar opcoes para a votacao
        {
            Console.Clear();

            int opc = 0; // variável para armazenar opção do usuário

            Console.WriteLine("Número de eleitores: " + eleitores); // mostrar quantidade de eleitores digitada

            foreach (var item in candidatos) // zerar números de votos válidos para o segundo turno
            {
                item.ZerarVotos();
            }
            foreach (var item in invalidos) // zerar números de votos nulos e brancos para o segundo turno
            {
                item.ZerarVotos();
            }

            for (int i = 0; i < eleitores; i++) // repetição de acordo com número de eleitores
            {
                bool votoConfirmado = false; // verificar votos nulos

                Console.WriteLine();

                foreach (var item in candidatos) // mostrar números e nome dos candidatos
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("0  - Branco");

                Console.Write("\nEleitor {0}, digite o número do candidato em que deseja votar: ", i + 1);

                try // try para realizar tratamento de erros
                {
                    opc = int.Parse(Console.ReadLine()); // receber opção de voto do eleitor
                }
                catch
                {
                    opc = 999; // retorna valor para voto nulo
                }

                foreach (var item in candidatos) // percorrer lista candidatos para adicionar os votos
                {
                    if (item.Numero == opc) // verificar voto do eleitor
                    {
                        item.AddVoto(); // adicionar voto
                        Console.Clear();
                        Console.WriteLine("Voto confirmado");
                        votoConfirmado = true;
                        System.Threading.Thread.Sleep(200);
                        break;
                    }
                }

                if (opc == 0) // adicionar voto branco
                {
                    foreach (var pos in invalidos)
                    {
                        if (pos.Nome == "Branco")
                        {
                            Console.Clear();
                            Console.WriteLine("Voto Branco");
                            System.Threading.Thread.Sleep(200);
                            pos.AddVoto();
                        }
                    }
                }

                if ((votoConfirmado == false) && (opc != 0)) // adicionar voto nulo
                {
                    foreach (var pos in invalidos)
                    {
                        if (pos.Nome == "Nulo")
                        {
                            Console.Clear();
                            Console.WriteLine("Voto nulo");
                            System.Threading.Thread.Sleep(200);
                            pos.AddVoto();
                        }
                    }
                }
            }
			
            int votosValidos = VotosValidos(invalidos, eleitores); // armazenar número de votos válidos
            MostrarResultados(candidatos, invalidos, eleitores, votosValidos); // método para mostrar resultados
            Apuracao(candidatos, invalidos, eleitores, votosValidos); // chamada de método para apurar os votos
        }

        static int VotosValidos(Candidato[] invalidos, int eleitores) // método para filtrar votos válidos
        {
            int votosInvalidos = 0;

            foreach (var item in invalidos) // filtrar votos válidos, excluindo votos nulos e brancos
            {
                votosInvalidos = votosInvalidos + item.Votos;
            }

            return eleitores - votosInvalidos;
        }

        static void MostrarResultados(Candidato[] candidatos, Candidato[] invalidos, int eleitores, int validos) // métodos resultados primeiro e segundo turno
        {
            Console.Clear();

            Array.Sort(candidatos); // ordenar vetor de acordo com o método IComparable.CompareTo 

            foreach (var item in candidatos) // mostrar votos totais e válidos
            {
                Console.WriteLine("{0} - {1} votos, sendo %{2} do total, votos validos %{3}", item.Nome, item.Votos, item.Porcentagem(eleitores).ToString("F1"), item.Porcentagem(validos).ToString("F1"));
            }
            Console.WriteLine();

            foreach (var item in invalidos) // mostrar votos nulos e brancos
            {
                Console.WriteLine("{0} - teve {1} votos, sendo %{2} do total", item.Nome, item.Votos, item.Porcentagem(eleitores).ToString("F1"));
            }
            Console.WriteLine();
        }

        static void Apuracao(Candidato[] candidatos, Candidato[] invalidos, int eleitores, int validos)
        {
            bool segTurno = false; // variável que indica se terá ou não segundo turno

            if (candidatos.Length == 2) // caso já esteja no segundo turno, ira mostrar o ganhador
            {
                Console.WriteLine("Ganhador: " + candidatos[0]);
                Console.ReadKey();
                Environment.Exit(0); // fechar programa
            }

            foreach (var item in candidatos) // percorrer lista para definir se terá ou não segundo turno
            {
                if (item.Porcentagem(validos) > 50) // se % de votos válidos for maior que 50%, exibir ganhador no primeiro turno
                {
                    Console.WriteLine("Ganhador: " + item);
                    Console.WriteLine();
                    segTurno = false;
                    break;
                }
                else segTurno = true;
            }

            if (segTurno == true) // chamar votacao para segundo turno
            {
                Candidato[] segundoTurno = new Candidato[] { candidatos[0], candidatos[1] }; // selecionando participantes do segundo turno de acordo com a ordenação

                Console.WriteLine("Terá segundo turno entre {0} e {1}", segundoTurno[0], segundoTurno[1]);

                Console.Write("\nPressione qualquer tecla para continuar");
                Console.ReadKey();

                Console.WriteLine("Votação segundo turno");

                Votacao(eleitores, segundoTurno, invalidos); // chamada de metodo de votação, agora para o segundo turno
            }
        }

        static void ImprimirNomes()
        {
			Console.Clear();	
            Console.WriteLine("Integrantes:");
            Console.WriteLine("652813 - Bryan Diniz Rodrigues");
            Console.WriteLine("664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine("668579 - Thais Barcelos Lorentz");
            Console.Write("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
			Console.Clear();			
        }
    }
}
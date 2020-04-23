using System;

namespace Ex34
{
    class Candidato : IComparable<Candidato>
    {
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        public int Votos  { get; private set; }
        public int Idade { get; private set; }

        public Candidato(){} // construtor padrão
		
        public Candidato(string nome, int numero, int idade)
        {
            Nome = nome;
            Numero = numero;
            Idade = idade;
        }

        public Candidato(string nome, int numero)
        {
            Nome = nome;
            Numero = numero;
        }

        public Candidato(string nome)
        {
            Nome = nome;
        }
			
        public override string ToString()
        {
            return "" + Numero + " - " + Nome;
        }

        public int CompareTo(Candidato cand)
        {
            // Se o número de votos for igual então faz a ordenação de acordo com a maior idade
            if (this.Votos == cand.Votos)
            {
                return cand.Idade.CompareTo(this.Idade);
            }
            // Ordenação padrão : do maior número de votos para o menor
            return cand.Votos.CompareTo(this.Votos);
        }
		
        public void AddVoto() // adiciona votos de acordo com o num recebido
        {
            Votos++;
        }		
  
        public void ZerarVotos() // zera votos para um segundo turno
        {
            Votos = 0;
        }

        public float Porcentagem(int total) // calcular porcentagem de acordo com o total de votos
        {
            return (100f / total) * Votos;
        }
		
    }
}
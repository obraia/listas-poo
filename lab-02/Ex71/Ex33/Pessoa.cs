using System;

namespace Ex71
{
    class Pessoa
    {
        public float Peso { get; set; } // armazenar peso da pessoa
        public float Altura { get; set; } // armazenar altura da pessoa
        public String DataNascimento { get; set; } // armazenar data de nascimento do tipo dd/mm/aaaa

        public Pessoa(String dataNascimento, float peso, float altura)
        {
            Peso = peso;
            Altura = altura;
            DataNascimento = dataNascimento;
        }

        public float IMC() // método para calcular IMC
        {
            return Peso / (Altura * Altura);
        }

        public int Idade() // método para retornar idade
        {
            return DateInfo.Idade(DataNascimento);
        }

        public override string ToString() // retornar informações sobre uma pessoa cadastrada
        {
            return
                "\n Idade: " + Idade()
                + "\n Altura: " + Altura.ToString("F2") + "m"
                + "\n Peso: " + Peso + "KG"
                + "\n IMC: " + IMC();
        }
    }
}

using System;

namespace Ex22
{
    public class Circulo : IForma
    {
        public string Nome { get; private set; }
        public double Raio { get; private set; }

        public Circulo(double raio)
        {
            Nome = "Circulo";
            Raio = raio;
        }

        public double CalcArea()
        {
            return Math.PI * Math.Pow(Raio, 2.0);
        }

        public double CalcPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        public override string ToString()
        {
            return " " + Nome + "\n Raio: " + Raio + "cm \n Área: " + CalcArea().ToString("F4") + "cm² \n Perimetro: " + CalcPerimetro().ToString("F4") + "cm \n";
        }
    }
}

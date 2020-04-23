
namespace Ex22
{
    public class Quadrado : IForma
    {
        public string Nome { get; private set; }
        public double Lado { get; private set; }

        public Quadrado(double lado)
        {
            Nome = "Quadrado";
            Lado = lado;
        }

        public double CalcArea()
        {
            return Lado * Lado;
        }

        public double CalcPerimetro()
        {
            return Lado * 4;
        }

        public override string ToString()
        {
            return " " + Nome + "\n Lado: " + Lado + "cm \n Área: " + CalcArea() + "cm² \n Perimetro: " + CalcPerimetro() + "cm \n";
        }
    }
}

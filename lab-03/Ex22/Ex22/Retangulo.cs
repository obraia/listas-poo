
namespace Ex22
{
    public class Retangulo : IForma
    {
        public string Nome { get; private set; }
        public double BaseX { get; private set; }
        public double AlturaY { get; private set; }

        public Retangulo(double baseX, double alturaY)
        {
            Nome = "Retângulo";
            BaseX = baseX;
            AlturaY = alturaY;
        }

        public double CalcArea()
        {
            return BaseX * AlturaY;
        }

        public double CalcPerimetro()
        {
            return (BaseX * 2) + (AlturaY * 2);
        }

        public override string ToString()
        {
            return " " + Nome + "\n Base: " + BaseX + "cm \n Altura: " + AlturaY + "cm \n Área: " + CalcArea() + "cm² \n Perimetro: " + CalcPerimetro() + "cm \n";
        }
    }
}

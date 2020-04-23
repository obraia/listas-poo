
namespace Ex21
{
    public class DVD : IControle
    {
        public bool Ligado { get; private set; }

        public DVD()
        {
            Ligado = false;
        }

        public void Ligar()
        {
            Ligado = true;
        }
        public void Desligar()
        {
            Ligado = false;
        }
    }
}

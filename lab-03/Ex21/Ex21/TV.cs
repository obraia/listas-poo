
namespace Ex21
{
    public class TV : IControle
    {
        public bool Ligada { get; private set; }
        public int MaxC { get; private set; }
        public int MaxV { get; private set; }
        public int Canal { get; private set; }
        public int Vol { get; private set; }

        public TV()
        {
            Ligada = false;
            MaxC = 83;
            MaxV = 100;
            Canal = 1;
            Vol = 0;
        }

        public void sCanal()
        {
            if (Ligada)
            {
                if (Canal == MaxC) { Canal = 1; }
                else { Canal++; }
            }
        }

        public void bCanal()
        {
            if (Ligada)
            {
                if (Canal == 1) { Canal = MaxC; }
                else { Canal--; }
            }
        }

        public void sVol()
        {
            if (Ligada)
            {
                if (Vol < MaxV) { Vol++; }
            }
        }

        public void bVol()
        {
            if (Ligada)
            {
                if (Vol > 0) { Vol--; }
            }
        }

        public void Ligar()
        {
            Ligada = true;
        }
        public void Desligar()
        {
            Ligada = false;
        }
    }
}

using System;

namespace TV_Ex3_4_LAB2_p_SGA_s218
{
    class TV
    {
        private int maxC;
        private int maxV;
        private int canal;
        private int vol;
        private bool ligada;

        public TV()
        {
            this.Init(1, 0, 83, 100);
        }

        public TV (int c, int vol, int maxC, int maxVol)
        {
            this.Init(c, vol, maxC, maxVol);
        }

        private void Init(int can, int vol, int maxC, int maxV)
        {
            this.maxC = maxC;
            this.maxV = maxV;

            if ((can > 0) && (can < this.maxC))
                this.canal = can;
            else
                this.canal = 1;
            if ((vol >= 0) && (vol < this.maxV))
                this.vol = vol;
            else
                this.vol = 0;
            this.ligada = false;
        }

        public int Canal
        {
            get
            {
                return canal;
            }
        }

        public int Vol
        {
            get
            {
                return vol;
            }
        }


        public bool Ligada
        {
            get
            {
                return ligada;
            }
        }


        public void sCanal()
        {
            if (ligada)
            {
                if (canal == maxC)
                    canal = 1;
                else
                    canal++;
            }
        }

        public void bCanal()
        {
            if (ligada)
            {
                if (canal == 1)
                    canal = maxC;
                else
                    canal--;
            }
        }

        public void sVol()
        {
            if (ligada)
            {
                if (vol < maxV)
                    vol++;
            }
        }

        public void bVol()
        {
            if (ligada)
            {
                if (vol > 0)
                    vol--;
            }
        }

        public void Power()
        {
            ligada = !ligada;
        }    
    }
}

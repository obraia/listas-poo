using System;

namespace Ex56
{
    class Conversor
    {
        public float FtoC(float graus)
        { // metodo de convesao de Fahrenheit para Celsius
            return (graus - 32) * 5 / 9;
        }
        public float CtoF(float graus)
        { // metodo de convesao de Celsius para Fahrenheit
            return (graus * 1.8f) + 32;
        }

    }
}
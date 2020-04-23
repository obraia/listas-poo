namespace Ex51
{
    class Calc
    {
        public double Soma(double numA, double numB) // metodo somar
        {
            return (numA + numB);
        }
        public double Sub(double numA, double numB) // metodo subtrair
        {
            return (numA - numB);
        }
        public double Mult(double numA, double numB) // metodo multiplicar
        {
            return (numA * numB);
        }
        public double Div(double numA, double numB) // metodo divisao
        {
            return (numA / numB);
        }
		
		public double Fat(double numA) // metodo fatoracao
		{
			double num, fatorial = 1;
			num = numA;
			
			while(num > 1)
			{
			fatorial = fatorial*num;
			num--;
			}			
			return fatorial;
		}

    }

}
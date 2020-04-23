//
// nome do programa: Ex35.cs
//
// programador(es): Bryan Diniz, Luiz Henrique Gomes Guimarães, Thais Barcelos Lorentz
// data: 07/08/2019
// entrada(s): um valor para temperatura em °C ou em °F, exemplo 75 C 
// o numero de matricula (6 dígitos)e o nome completo do aluno 
// saida(s): valor convertido para outra medida
// para executar  e testar digite: 
// Ex55.exe 75 C 
// descricao: Recebe uma temperatura em °c e converte para °f ou o oposto.
//

using System;
using System.Globalization;

namespace Ex55
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNomes(); // chamada de metodo para mostrar nomes do integrantes do trabalho            
			
			Conversor c = new Conversor(); // instanciando objeto de conversao

            try  // try usado para previnir erros ao receber parametros invalidos pelo args
            {
				float minC = (-273.15f), minF = (-459.67f); // limite minimo de conversao				
                float graus = float.Parse(args[0]); // recebendo valor numerico para medida
                string medida = args[1].ToLower(); // recebendo medida para indicar a conversao
				
                if (((medida == "°c") || (medida == "c") || (medida == "celsius")) && (graus >= minC))
                {
                    Console.WriteLine("{0} graus Fahrenheit", c.CtoF(graus).ToString("F2"));
					//Curiosidades(graus, 'c');
                }
                else if (((medida == "°f") || (medida == "f") || (medida == "fahrenheit")) && (graus >= minF))
                {
                    Console.WriteLine("{0} graus Celsius", c.FtoC(graus).ToString("F2"));
					//Curiosidades(graus, 'f');					
                }
                else Console.WriteLine("Medida inválida");
            }
            catch
            {
                Console.WriteLine("Parâmetros inválidos, tente algo como: 43 f ou 32 °C");
            }
        }
		
		/*static void Curiosidades(float graus, char medida)
		{
			Console.WriteLine();
			
			if(medida == 'c')
			{
					 if((graus > -50) && (graus < -100)) Console.WriteLine("A temperatura mais baixa registrada na terra é -89,2 ºC \nna estação de pesquisa russa em Vostok, na Antártica, em 21 de julho de 1983.");
				else if((graus > 30) && (graus < 40)) Console.WriteLine("A temperatura normal do corpo humano é entre 36.1ºC e 37.2ºC.");
				else if((graus > 50) && (graus < 60)) Console.WriteLine("A temperatura mais alta registrada na terra é 56.7 ºC em \nGreenland Ranch, Vale da Morte, Califórnia, Estados Unidos em 10 de julho de 1913.");
				else if((graus > 90) && (graus < 150)) Console.WriteLine("100 °C é a temperatura de ebulição da água a 1 ATM.");
				else if((graus > 2000) && (graus < 5600)) Console.WriteLine("A temperatura na superfície do Sol é cerca de 5505 °C.");
				else if((graus > 5600) && (graus < 7000)) Console.WriteLine("A temperatura do núcle da Terra é cerca de 6000 °C.");
				else if(graus > 7000) Console.WriteLine("A temperatura de 141 x 10^30 °C a chamada Temperatura de Planck, a radiação \nemitida por uma partícula nessa temperatura teria o menor comprimento de onda possível.");
			}
			if (medida == 'f')
			{
					 if((graus > -50) && (graus < -100)) Console.WriteLine("A temperatura mais baixa registrada na terra é -128,56 ºF \nna estação de pesquisa russa em Vostok, na Antártica, em 21 de julho de 1983.");
				else if((graus > 30) && (graus < 40)) Console.WriteLine("A temperatura normal do corpo humano é entre 96.98 ºF e 98.96 ºF.");
				else if((graus > 50) && (graus < 60)) Console.WriteLine("A temperatura mais alta registrada na terra é 134.06 ºC em \nGreenland Ranch, Vale da Morte, Califórnia, Estados Unidos em 10 de julho de 1913.");
				else if((graus > 150) && (graus < 300)) Console.WriteLine("212 °F é a temperatura de ebulição da água a 1 ATM.");
				else if((graus > 7000) && (graus < 9500)) Console.WriteLine("A temperatura na superfície do Sol é cerca de 9941 °F.");
				else if((graus > 9500) && (graus < 15000)) Console.WriteLine("A temperatura do núcle da Terra é cerca de 10832 °C.");				
				else if(graus > 15000) Console.WriteLine("A temperatura de 2.55×10^32 °F a chamada Temperatura de Planck, a radiação \nemitida por uma partícula nessa temperatura teria o menor comprimento de onda possível.");
			}
		}*/
		
        static void ImprimirNomes()
        {
			Console.Clear();	
            Console.WriteLine("Integrantes:");
            Console.WriteLine("652813 - Bryan Diniz Rodrigues");
            Console.WriteLine("664469 - Luiz Henrique Gomes Guimarães");
            Console.WriteLine("668579 - Thais Barcelos Lorentz");
            Console.Write("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
			Console.Clear();			
        }

    }
}
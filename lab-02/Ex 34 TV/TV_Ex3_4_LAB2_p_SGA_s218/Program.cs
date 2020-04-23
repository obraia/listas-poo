using System;

namespace TV_Ex3_4_LAB2_p_SGA_s218
{
    class Program
    {

        static public void Tela(TV tv1)
        {
            Console.Clear();
            Console.WriteLine();

            if (tv1.Ligada)
            {
                Console.ForegroundColor = ConsoleColor.Green;					
                Console.WriteLine(" TV LIGADA\n ");
				Console.ResetColor();
				
                Console.WriteLine(" Canal = {0:00} ", tv1.Canal);
                Console.WriteLine(" Volume = {0:00}", tv1.Vol);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;				
                Console.WriteLine(" TV DESLIGADA ");
				Console.ResetColor();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            TV tv1 = new TV();

            char opcao;
			
            do
            {
                Tela(tv1);
				
                Console.WriteLine(" Opcoes: ");
                Console.WriteLine(" Canal: - e +");
                Console.WriteLine(" Volume: < e >");
                Console.WriteLine(" Power: P");
                Console.WriteLine("\n Sair: X");
                Console.WriteLine();
				
                opcao = Console.ReadKey().KeyChar;
				
                switch (opcao)
                {
					case '=':
                    case '+':
                        tv1.sCanal();
                        break;
						
					case '-':	
                    case '_':
                        tv1.bCanal();
                        break;
						
					case '.':	
                    case '>':
						tv1.sVol();
                        break;
						
					case ',':	
                    case '<':
						tv1.bVol();                   
                        break;
						
                    case 'P':
                    case 'p':
                        tv1.Power();
                        break;
                }
            } while (opcao.ToString().ToUpper() != "X");
        }
    }
   
}

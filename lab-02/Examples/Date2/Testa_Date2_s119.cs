
using System;

namespace Date2 {
	
	class Testa_Date2 {
		static void Main(string[ ] args) {
		// Programa de teste Date2 
			Console.WriteLine("Programa de teste Date2:" );	
			Date2 d1 = new Date2 ( ) ;
			Date2 d2 = new Date2 (19 , 2 , 2019);;
			Console.WriteLine ( "Data com valores padrao: " + d1.GetDia() + "/" + d1.GetMes() + "/" + d1.GetAno() );
			if (d1.anoBissexto ( ))
				Console.WriteLine ("eh uma data de ano bissexto" ); 
			else
				Console.WriteLine ("nao eh uma data de ano bissexto" );
			Console.WriteLine( "Data LAB2: " + d2.GetDia() + "/" + d2.GetMes() + "/" + d2.GetAno() );
			if (d2.anoBissexto ( ))
				Console.WriteLine ("eh uma data de ano bissexto" ); 
			else
				Console.WriteLine  ("nao eh uma data de ano bissexto" );					
		}
	}
}

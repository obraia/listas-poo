
using System;

namespace Date1 {
	
	class Testa_Date1 {
		static void Main(string[] args){ // Programa de teste Date1  
			Console.WriteLine ("Programa de teste Date1:" ); 
			Date1 d1 = new Date1( );
			d1.iniciaData (4 , 10 , 2000);
			Console.Write (d1.GetDia() + "/" + d1.GetMes() + "/" + d1.GetAno() );
		if (d1.anoBissexto ( ))
			Console.WriteLine (" eh uma data de ano bissexto" ); 
		else
			Console.WriteLine (" nao eh uma data de ano bissexto" );	
		Date1 d2 = new Date1( );			
		d2.iniciaData (15 , 2 , 2019);
		Console.Write (d2.GetDia() + "/" + d2.GetMes() + "/" + d2.GetAno() );
		if (d2.anoBissexto ( ))
			Console.WriteLine (" eh uma data de ano bissexto" ); 
		else
			Console.WriteLine (" nao eh uma data de ano bissexto" );
			
		}
	}
}

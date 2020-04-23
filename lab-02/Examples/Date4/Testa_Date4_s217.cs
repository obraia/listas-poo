
using System;

namespace Date4 {
	

	class Testa_Date4 {
		static void Main(string[] args){
		
		// Programa de teste Date4  
	
			Date4 d1 = new Date4 ( ) ;
			Date4 d2 = new Date4(23, 8, 2017);
			Date4 d3 = new Date4(29, 2, 2014) ;
			Date4 d4 = new Date4(30, 01, 1899) ;
			Console.WriteLine( "\nData padrao: " + d1.Dia + "/" + d1.Mes + "/" + d1.Ano) ;
			Console.WriteLine( "Data LAB2: " + d2.Dia + "/" + d2.Mes + "/" + d2.Ano) ;
			Console.WriteLine( "Data errada 3 alterada: " + d3.Dia + "/" + d3.Mes + "/" + d3.Ano) ;
			Console.WriteLine( "Data errada 4 alterada: " + d4.Dia + "/" + d4.Mes + "/" + d4.Ano) ;
		}
	
	}

}

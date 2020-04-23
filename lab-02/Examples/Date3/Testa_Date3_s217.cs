
using System;

namespace Date3 {
	
	class Testa_Date3  {
		static void Main(string[] args){		
		// Programa de teste Date3  
			Console.WriteLine ("Programa de teste Date3:" );	
			Date3 d1 = new Date3 ( ) ;
			Date3 d2 = new Date3(23, 08, 2017) ;
			Console.WriteLine (  "Data padrao: " + d1.Dia + "/" + d1.Mes + "/" + d1.Ano) ;
			Console.WriteLine (  "Data LAB2: " + d2.Dia + "/" + d2.Mes + "/" + d2.Ano ) ;
		}	
	}
}


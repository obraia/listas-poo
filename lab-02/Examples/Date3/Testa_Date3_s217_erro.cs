
using System;

namespace Date3 {
	
	class Testa_Date3  {
		static void Main(string[] args){// com getters e setters com erros
	
		// Programa de teste Date3  
			Console.WriteLine ("Programa de teste Date3:" );	
			Date3 d1 = new Date3 ( ) ;
			Date3 d2 = new Date3(23, 08, 2017) ;
			Console.WriteLine (  "Data padrao: " + d1.dia + "/" + d1.mes + "/" + d1.ano) ;
			Console.WriteLine (  "Data LAB2: " + d2.dia + "/" + d2.mes + "/" + d2.ano ) ;
		}	
	}
}



using System;
using System.Threading;
using System.Diagnostics;

namespace Date {
	class NovaData : Date {
		private static String [ ] NomeMeses = {"Janeiro", "Fevereiro", "Março",
		"Abril", "Maio", "Junho", "Julho ", "Agosto" ,
		"Setembro", "Outubro" , "Novembro" , "Dezembro" } ;
		public String toString ( ) {
			String temp = dia  + " de " + NomeMeses [mes - 1]  + " de " + ano ;
			return temp ;
		}	
	
	}

}

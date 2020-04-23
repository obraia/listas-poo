
using System;
using System.Threading;
using System.Diagnostics;

namespace Date {
	

	class Testa_NovaData {
		static void Main(string[] args){
			NovaData d1 = new NovaData ( ) ;
			Console.WriteLine( "\nData padrao: " + d1.dia  + "/" +
			d1.mes + "/" + d1.			ano  ) ;
			Console.WriteLine( "Data padrao: " + d1.toString ( ) );
			if (d1.anoBissexto ( ))
				Console.WriteLine ("eh uma data de ano bissexto" ); 
			else
				Console.WriteLine ("Nao eh uma data de ano bissexto" );
		}
	}

}

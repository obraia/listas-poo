
using System;

namespace Date3 {
	class Date3 {
		private int dia, mes, ano ; // tres atributos inteiros
		public Date3( ) { // construtor default sem parâmetros inicializados com valores validos 
			dia = 1 ; mes = 1 ; ano = 1900; 
		} 
		public Date3(int d, int m, int a) {// construtor com parâmetros passados por valor
			if ( ( d > 0) && (d <= 31) )
				dia = d ;
			if ( (m > 0) && (m <= 12) )
				mes = m;
			if ( a > 1900)
			ano = a ;
		}		 
		 
		public bool anoBissexto ( ) {
			if ( ano % 4 != 0)
				return false ;
			else if ( ano % 100 != 0)
				return true ;
			else if ( ano % 400 != 0)
				return false ;
			else return true ;
		}
		
		public int Dia { 
			get { 
				return dia;
			}
		}	
		public int Mes { 
			get { 
				return mes ;
			}
		}
		public int Ano { 
			get {
				return ano;
			}
		}	
	}
}


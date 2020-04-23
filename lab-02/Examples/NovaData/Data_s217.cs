
using System;

namespace Date {
	class Date {
		public int dia, mes, ano ; // tres atributos inteiros
		public Date( ) {  // construtor default sem parâmetros 
			dia = 1 ; mes = 1 ; ano = 1900; 
		}	
		 
		public Date(int d, int m, int a) {// construtor com parâmetros passados por valor
			dia = d; mes = m; ano = a; 
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
	
	}

	

	
	
}

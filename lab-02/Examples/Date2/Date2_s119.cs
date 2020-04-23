
using System;

namespace Date2 {
	class Date2 {
		int dia, mes, ano ; // tres atributos inteiros
		public Date2( ) {  } // construtor default sem parâmetros 
		public Date2(int d, int m, int a) { // construtor com parâmetros passados por valor
			dia = d; mes = m; ano = a; 
		} 
		
		public int GetDia() { return dia; }
		public int GetMes() { return mes; }
		public int GetAno() { return ano; }
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

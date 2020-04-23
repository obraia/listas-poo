
using System;

namespace Date1 {
	class Date1 {
		int dia, mes, ano ; // tres atributos inteiros
		public void iniciaData (int d ,int m ,int a ) {
			if ( a > 1900) 
				ano = a ;
			if ( (m > 0) && (m <= 12) )
				mes = m;
			if ( ( d > 0) && (d <= 31) )
				dia = d ;
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

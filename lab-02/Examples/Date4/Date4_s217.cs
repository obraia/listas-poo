
using System;
using System.Threading;
using System.Diagnostics;

namespace Date4 {

	class Date4{
		private int dia, mes, ano ; // tres atributos inteiros
		private static int [ ] numDias  = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
		public Date4( ) { // construtor default sem parâmetros inicializados com valores validos 
			dia = 1 ; mes = 1 ; ano = 1900; 
		} 
		
		public Date4 ( int dia , int mes, int ano ) {// construtor com parâmetros passados por valor
			if ((mes > 0) && (mes <= 12)) this.mes = mes;
			else this.mes = 1 ;
			if (( dia > 0) && (dia <= numDias[mes - 1])) this.dia = dia ;
			else this.dia = 1 ;
			if ( ano > 1900) this.ano = ano ;
			else this.ano = 1900;
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

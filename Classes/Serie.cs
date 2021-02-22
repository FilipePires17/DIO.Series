using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos

        // Métodos
		public Serie(int id, string titulo, string sinopse, int ano)
		{
			this.Id = id;
			this.Titulo = titulo;
			this.Sinopse = sinopse;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			string retorno = "";
            retorno += "Gêneros: ";
			for(int i = 0; i<countGeneros; i++){
				retorno += this.Generos[i];
				if(i+1<countGeneros)
					retorno += ", ";
			}
			retorno += Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Sinopse + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        
    }
}
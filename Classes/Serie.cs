using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
		private bool Terminado { get; set; }

        // Métodos
		public Serie(int id, string titulo, string sinopse, int ano, bool terminado)
		{
			this.Id = id;
			this.Titulo = titulo;
			this.Sinopse = sinopse;
			this.Ano = ano;
            this.Excluido = false;
			this.Terminado = terminado;
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
			retorno += Terminado ? "FINALIZADA" : "Em Andamento" + Environment.NewLine;
            retorno += this.Excluido ? "Cadastro Excluído" : "";
			return retorno;
		}

        
    }
}
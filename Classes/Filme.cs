using System;
namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        // Atributos
        private string Duracao { get; set; }

        public Filme(int id, string titulo, string sinopse, int ano_de_lancamento, string duracao){
            this.Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            Ano = ano_de_lancamento;
            Duracao = duracao;
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
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

    }
}
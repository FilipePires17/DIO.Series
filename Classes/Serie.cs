using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
		private Genero[] Generos = new Genero[10];
		private int countGeneros = 0;
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Serie(int id, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Titulo = titulo;
			this.Descricao = descricao;
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
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }

		public void addGenero(Genero genero){
			if(countGeneros<10){
				Generos[countGeneros] = genero;
				countGeneros++;
			} else {
				Console.WriteLine("Número máximo de gêneros atingido.");
			}
		}
    }
}
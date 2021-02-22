using System;
namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }

        protected Genero[] Generos = new Genero[10];
		protected int countGeneros = 0;
		protected string Titulo { get; set; }
		protected string Sinopse { get; set; }
		protected int Ano { get; set; }
        protected bool Excluido {get; set;}

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
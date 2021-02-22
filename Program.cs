using System;
using System.Collections.Generic;
/*
TODO: 
aumentar as opções
adicionar filmes
tratar erros e melhorar experiencia do usuário com perguntas de confirmação
generalizar entidadeBase
enviar :)
*/
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuarioPrincipal();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeriesEFilmes();
						break;
					case "2":
						MenuSerie();
						break;
					case "3":
						MenuFilme();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuarioPrincipal();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

		private static void MenuSerie(){
			string opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();

			while (opcaoUsuarioSerie.ToUpper() != "X")
			{
				switch (opcaoUsuarioSerie)
				{
					case "1":
						InserirItem(true);
						break;
					case "2":
						AtualizarItem(true);
						break;
					case "3":
						ExcluirItem(true);
						break;
					case "4":
						VisualizarItem(true);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
			}
		}
		private static void MenuFilme(){
			string opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();

			while (opcaoUsuarioFilme.ToUpper() != "X")
			{
				switch (opcaoUsuarioFilme)
				{
					case "1":
						InserirItem(false);
						break;
					case "2":
						AtualizarItem(false);
						break;
					case "3":
						ExcluirItem(false);
						break;
					case "4":
						VisualizarItem(false);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
			}
		}
        private static void ExcluirItem(bool isSerie)
		{
			if(isSerie){
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				repositorioSerie.Exclui(indiceSerie);
			} else {
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				repositorioFilme.Exclui(indiceFilme);
			}
		}
        private static void VisualizarItem(bool isSerie)
		{
			if(isSerie){
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				var serie = repositorioSerie.RetornaPorId(indiceSerie);

				Console.WriteLine(serie);
			} else {
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				var filme = repositorioSerie.RetornaPorId(indiceFilme);

				Console.WriteLine(filme);
			}
		}

        private static void AtualizarItem(bool isSerie)
		{
			if(isSerie){
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				Serie atualizaSerie = CadastraSerie(indiceSerie);
				
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				do{
					Console.Write("Digite o gênero entre as opções acima: ");
					int entradaGenero = int.Parse(Console.ReadLine());
					atualizaSerie.addGenero((Genero)entradaGenero);
					Console.WriteLine("Deseja inserir mais um gênero?(y/n)");
				} while(Console.ReadLine().ToUpper().Equals("Y"));

				repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
			} else{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				Filme atualizaFilme = CadastraFilme(indiceFilme);
				
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				do{
					Console.Write("Digite o gênero entre as opções acima: ");
					int entradaGenero = int.Parse(Console.ReadLine());
					atualizaFilme.addGenero((Genero)entradaGenero);
					Console.WriteLine("Deseja inserir mais um gênero?(y/n)");
				} while(Console.ReadLine().ToUpper().Equals("Y"));

				repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
			}
		}
        private static void ListarSeriesEFilmes()
		{
			var listaSerie = repositorioSerie.Lista();
			var listaFilme = repositorioFilme.Lista();

			Console.Write("SÉRIES\n\n");

			if (listaSerie.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
			} else {
				foreach (var serie in listaSerie)
				{
					var excluido = serie.retornaExcluido();

					Console.WriteLine(excluido ? $"#ID {serie.retornaId()}: - *Não disponível*" : "#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
				}
			}
			Console.WriteLine("----------------------------");
			Console.Write("\nFILMES\n\n");

			if (listaFilme.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
			} else{
				foreach (var filme in listaFilme)
				{
					var excluido = filme.retornaExcluido();

					Console.WriteLine(excluido ? $"#ID {filme.retornaId()}: - *Não disponível*" : "#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
				}
			}
		}

        private static void InserirItem(bool isSerie)
		{
			if(isSerie){
				Console.WriteLine("Inserir nova série");

				Serie novaSerie = CadastraSerie(repositorioSerie.ProximoId());
				
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				do{
					Console.Write("Digite o gênero entre as opções acima: ");
					int entradaGenero = int.Parse(Console.ReadLine());
					novaSerie.addGenero((Genero)entradaGenero);
					Console.WriteLine("Deseja inserir mais um gênero?(y/n)");
				} while(Console.ReadLine().ToUpper().Equals("Y"));

				repositorioSerie.Insere(novaSerie);
			} else{
				Console.WriteLine("Inserir novo filme");

				Filme novoFilme = CadastraFilme(repositorioFilme.ProximoId());
				
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				do{
					Console.Write("Digite o gênero entre as opções acima: ");
					int entradaGenero = int.Parse(Console.ReadLine());
					novoFilme.addGenero((Genero)entradaGenero);
					Console.WriteLine("Deseja inserir mais um gênero?(y/n)");
				} while(Console.ReadLine().ToUpper().Equals("Y"));

				repositorioFilme.Insere(novoFilme);
			}
		}
        private static string ObterOpcaoUsuarioPrincipal()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries e filmes");
			Console.WriteLine("2- Atualizar séries");
			Console.WriteLine("3- Atualizar filmes");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static string ObterOpcaoUsuarioSerie(){
			Console.WriteLine("1- Inserir nova série");
			Console.WriteLine("2- Atualizar série");
			Console.WriteLine("3- Excluir série");
			Console.WriteLine("4- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static string ObterOpcaoUsuarioFilme(){
			Console.WriteLine("1- Inserir novo filme");
			Console.WriteLine("2- Atualizar filme");
			Console.WriteLine("3- Excluir filme");
			Console.WriteLine("4- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static Serie CadastraSerie(int id){

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: id,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaDescricao);
			
			return novaSerie;
		}
		private static Filme CadastraFilme(int id){

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do filme: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a duração do filme: ");
			string entradaDuracao = Console.ReadLine();

			Filme novoFilme = new Filme(id: id,
										titulo: entradaTitulo,
										sinopse: entradaDescricao,
										ano_de_lancamento: entradaAno,
										duracao: entradaDuracao);
			
			return novoFilme;
		}
    }
}

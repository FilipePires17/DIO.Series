using System;
//using System.Collections.Generic;
/*
TODO: 
aumentar as opções
tratar erros e melhorar experiencia do usuário com perguntas de confirmação
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
			Console.WriteLine("DIO Séries a seu dispor!!!\n");
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
						Console.WriteLine("Entrada inválida, tente novamente");
						break;
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
				bool entradaValida;
				string entradaExcluir;

				Console.WriteLine("Tem certeza que deseja excluir a série: {0}(s/n)", repositorioSerie.Lista()[indiceSerie].retornaTitulo());
				do{
					entradaExcluir = Console.ReadLine();
					if(entradaExcluir.ToLower().Equals("s")){
						repositorioSerie.Exclui(indiceSerie);
						entradaValida = true;
						Console.WriteLine("Série excluída com sucesso");
					} else if(entradaExcluir.ToLower().Equals("n")){
						entradaValida = true;
						Console.WriteLine("Série não excluída");
					} else{
						Console.WriteLine("Entrada inválida, tente novamente");
						entradaValida = false;
					}
				} while(!entradaValida);
			} else {
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());
				bool entradaValida;
				string entradaExcluir;

				Console.WriteLine("Tem certeza que deseja excluir o filme: {0}(s/n)", repositorioFilme.Lista()[indiceFilme].retornaTitulo());
				do{
					entradaExcluir = Console.ReadLine();
					if(entradaExcluir.ToLower().Equals("s")){
						repositorioFilme.Exclui(indiceFilme);
						entradaValida = true;
						Console.WriteLine("Filme excluído com sucesso");
					} else if(entradaExcluir.ToLower().Equals("n")){
						entradaValida = true;
						Console.WriteLine("Filme não excluído");
					} else{
						Console.WriteLine("Entrada inválida, tente novamente");
						entradaValida = false;
					}
				} while(!entradaValida);
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
					Console.WriteLine("Deseja inserir mais um gênero?(sim/nao)");
				} while(Console.ReadLine().ToLower().Equals("sim"));

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
					Console.WriteLine("Deseja inserir mais um gênero?(sim/nao)");
				} while(Console.ReadLine().ToLower().Equals("sim"));

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
					Console.WriteLine("Deseja inserir mais um gênero?(sim/nao)");
				} while(Console.ReadLine().ToLower().Equals("sim"));

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
					Console.WriteLine("Deseja inserir mais um gênero?(sim/nao)");
				} while(Console.ReadLine().ToLower().Equals("sim"));

				repositorioFilme.Insere(novoFilme);
			}
		}
        private static string ObterOpcaoUsuarioPrincipal()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries e filmes");
			Console.WriteLine("2- Atualizar e visualizar séries");
			Console.WriteLine("3- Atualizar e visualizar filmes");
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

			Console.Write("A Série já foi finalizada?(sim/nao): ");
			string entradaTerminado;
			bool terminado, entradaValida;
			do{
				entradaTerminado = Console.ReadLine();
				if(entradaTerminado.ToLower().Equals("sim")){
					terminado = true;
					entradaValida = true;
				}
				else if(entradaTerminado.ToLower().Equals("nao")){
					terminado = false;
					entradaValida = true;
				}
				else{
					Console.WriteLine("Entrada inválida, responda novamente:(sim/nao)");
					terminado = false;
					entradaValida = false;
				}
			} while(!entradaValida);

			Serie novaSerie = new Serie(id: id,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaDescricao,
										terminado: terminado);
			
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

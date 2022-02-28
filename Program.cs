using Acervo.Filmes;

class Program
{
    static FilmeRepositorio repositorio = new FilmeRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper() != "X")
        {
            switch(opcaoUsuario)
            {
                case "1":
                ListarFilmes();
                break;
                case "2":
                InserirFilme();
                break;
                case "3":
                AtualizarFilme();
                break;
                case "4":
                ExcluirFilme();
                break;
                case "5":
                VisualizarFilme();
                break;
                case "C":
                Console.Clear();
                break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }

        System.Console.WriteLine("Fechando sistema de gerenciamento de filmes.");
        System.Console.WriteLine("LocalizaLabs#2 - DIO");
        System.Console.ReadLine();
    }

    private static void ListarFilmes()
    {
        System.Console.WriteLine("Listando Filmes ...");
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            System.Console.WriteLine("Nenhum filme cadastrado");
            return;
        }
        foreach (var filme in lista)
        {
            var excluido = filme.retornaExcluido();
            System.Console.WriteLine($"#ID: {filme.retornaId()} - {filme.retornaTitulo()} {(excluido ? "- Excluido" : "")}");
        }
    }

    private static void InserirFilme()
    {
        System.Console.WriteLine("Inserir novo filme");

        foreach (int gen in Enum.GetValues(typeof (Genero)))
        {
            System.Console.WriteLine($"{gen} - {Enum.GetName(typeof(Genero),gen)}");
        }
        Console.Write("Digite o numero do genero do filme: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o titulo do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        foreach (int claindic in Enum.GetValues(typeof(ClassIndicativa)))
        {
            System.Console.WriteLine("{0} - {1}", claindic, Enum.GetName(typeof(ClassIndicativa),claindic));
        }
        System.Console.WriteLine("Informe a classificação indicativa: ");
        int entradaClaindic = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Ja assistiu esse filme? 1-Não / 2-Sim");
        int entradaAssistiu = int.Parse(Console.ReadLine());

        Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descrição: entradaDescricao,
                                    classIndicativa: (ClassIndicativa)entradaClaindic,
                                    assistido: (Assistido)entradaAssistiu);
        repositorio.Insere(novoFilme);
    }

    private static void AtualizarFilme()
    {
        System.Console.Write("Digite o Id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        foreach (int gen in Enum.GetValues(typeof (Genero)))
        {
            System.Console.WriteLine($"{gen} - {Enum.GetName(typeof(Genero),gen)}");
        }
        Console.Write("Digite o numero do genero do filme: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o titulo do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        foreach (int claindic in Enum.GetValues(typeof(ClassIndicativa)))
        {
            System.Console.WriteLine("{0} - {1}", claindic, Enum.GetName(typeof(ClassIndicativa),claindic));
        }
        System.Console.WriteLine("Informe a classificação indicativa: ");
        int entradaClaindic = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Ja assistiu esse filme? 1-Não / 2-Sim");
        int entradaAssistiu = int.Parse(Console.ReadLine());

        Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descrição: entradaDescricao,
                                    classIndicativa: (ClassIndicativa)entradaClaindic,
                                    assistido: (Assistido)entradaAssistiu);
        repositorio.Atualizar(indiceFilme, atualizaFilme);
    }

    private static void ExcluirFilme()
    {
        Console.Write("Digite o Id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        repositorio.Excluir(indiceFilme);
    }

    private static void VisualizarFilme()
    {
        Console.Write("Digite o Id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        var filme = repositorio.RetornaPorId(indiceFilme);

        System.Console.WriteLine(filme);
    }
    private static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine("-------------------");
        System.Console.WriteLine("Meu Acervo de Filmes");
        System.Console.WriteLine("Selecione uma das opções abaixo: ");

        System.Console.WriteLine("1 - Listar filmes");
        System.Console.WriteLine("2 - Cadastrar novo filme");
        System.Console.WriteLine("3 - Atualizar dados de filme");
        System.Console.WriteLine("4 - Excluir filme");
        System.Console.WriteLine("5 - Visualizar informações sobre filme");
        System.Console.WriteLine("C - Limpar tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine("-------------------");
        return opcaoUsuario;
    }
}
namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public string? ObterOpcaoMenu()
    {
        // Apresentação: Menu de Controle de Equipamentos
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Controle de Equipamentos");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Equipamento");
        Console.WriteLine("2 - Editar Equipamento");
        Console.WriteLine("3 - Excluir Equipamento");
        Console.WriteLine("4 - Visualizar Equipamentos");
        Console.WriteLine("S - Voltar ao Menu Inicial");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Cadastro Equipamentos");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Digite o Nome do Equipamento: ");
        string nome = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Digite o Preço de Aquisição: ");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Digite a Data de Fabricação (dd/mm/yyyy): ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Equipamento equipamento = new Equipamento(nome, precoAquisicao, dataFabricacao);

        repositorioEquipamento.Cadastrar(equipamento);

        Console.WriteLine();
        Console.WriteLine($"Equipamento {equipamento.Nome} Cadastrado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Edição de Equipamentos");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        // tabela do console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.Id,
                eq.Nome,
                eq.PrecoAquisicao,
                eq.DataFabricacao.ToShortDateString()
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do Equipamento a ser Editado: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o Nome do Equipamento: ");
        string nome = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o Preço de Aquisição:");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite a Data de Fabricação (dd/mm/yyyy): ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();

        Equipamento equipamentoAtualizado = new Equipamento(nome, precoAquisicao, dataFabricacao);

        repositorioEquipamento.Editar(idSelecionado, equipamentoAtualizado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine($"Equipamento {nome} Editado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Exclusão de Equipamentos");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        // tabela do console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
        );

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.Id,
                eq.Nome,
                eq.PrecoAquisicao,
                eq.DataFabricacao.ToShortDateString()
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do Equipamento a ser Excluído: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioEquipamento.Excluir(idSelecionado);

        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine($"Equipamento foi Excluído com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void VisualizarTodos()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Visualização de Equipamentos");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        // tabela do console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.Id,
                eq.Nome,
                eq.PrecoAquisicao,
                eq.DataFabricacao.ToShortDateString()
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }
}

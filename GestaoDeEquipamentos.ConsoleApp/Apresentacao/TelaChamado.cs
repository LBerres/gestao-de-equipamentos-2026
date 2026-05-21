namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class TelaChamado
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;
    public string? ObterOpcaoMenu()
    {
        // Apresentação: Menu de Controle de Chamados
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Controle de Chamados");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Chamado");
        Console.WriteLine("2 - Editar Chamado");
        Console.WriteLine("3 - Excluir Chamado");
        Console.WriteLine("4 - Visualizar Chamados");
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
        Console.WriteLine("Cadastro de Chamado");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        // Obtenção dos Dados
        Console.Write("Digite o Título do Chamado: ");
        string titulo = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite a Descrição do Chamado: ");
        string descricao = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        DateTime dataAbertura = DateTime.Now;

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

        // Pedir para o usuário selecionar o ID do equipamento desejado
        Console.Write("Digite o ID do Equipamento que Deseja Selecionar: ");
        int idEquipamentoSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Equipamento equipamentoSelecionado = null;

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.Id == idEquipamentoSelecionado)
            {
                equipamentoSelecionado = eq;
                break;
            }
        }

        Chamados novoChamado = new Chamados(titulo, descricao, equipamentoSelecionado);

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine($"O Chamado {novoChamado.Titulo} Foi Cadastrado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Edição de Chamados");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Chamados[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamados ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
                ch.Id,
                ch.Titulo,
                ch.Descricao,
                ch.DataAbertura.ToShortDateString(),
                ch.Equipamento.Nome
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do Registro que Deseja Editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Digite o Novo Título do Chamado: ");
        string titulo = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Digite a Nova Descrição do Chamado: ");
        string descricao = Console.ReadLine();
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
                eq.Id, eq.Nome, eq.PrecoAquisicao, eq.DataFabricacao
            );
        }

        Console.Write("Digite o ID do Equipamento que Deseja Selecionar: ");
        int idEquipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = null;

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.Id == idEquipamentoSelecionado)
            {
                equipamentoSelecionado = eq;
                break;
            }
        }

        Chamados chamadoAtualizado = new Chamados(titulo, descricao, equipamentoSelecionado);

        repositorioChamado.Editar(idSelecionado, chamadoAtualizado);

        Console.WriteLine($"O Chamado {titulo} Foi Editado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Exclusão de Chamados");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Chamados[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        // Tabela
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamados ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
                ch.Id,
                ch.Titulo,
                ch.Descricao,
                ch.DataAbertura.ToShortDateString(),
                ch.Equipamento.Nome
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do Chamado a ser Excluído: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioChamado.Excluir(idSelecionado);

        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine($"Chamado foi Excluído com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("Visualização de Chamados");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Chamados[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        // Tabela
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamados ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
                ch.Id,
                ch.Titulo,
                ch.Descricao,
                ch.DataAbertura.ToShortDateString(),
                ch.Equipamento.Nome
            );
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }
}
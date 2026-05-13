using GestaoDeEquipamentos.ConsoleApp.Dominio;

int contadorId = 1;

Equipamento[] equipamentosSalvos = new Equipamento[100];

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Editar equipamento");
    Console.WriteLine("3 - Excluir equipamento");
    Console.WriteLine("4 - Visualizar equipamentos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenu = Console.ReadLine()?.ToUpper();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

// Operações C.R.U.D - Create, Read/Retrieve, Update, Delete
    if (opcaoMenu == "1")
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o Nome do Equipamento:");
        string nome = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o Preço de Aquisição:");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite a Data de Fabricação (dd/mm/yyyy):");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("---------------------------------");

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.dataFabricacao = dataFabricacao;
        equipamento.id = contadorId++;

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            if (equipamentosSalvos[i] == null)
            {
                equipamentosSalvos[i] = equipamento;
                break;
            }
        }

        Console.WriteLine($"Equipamento {equipamento.nome} Cadastrado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }

    else if (opcaoMenu == "2")
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Equipamentos");
        Console.WriteLine("---------------------------------");

        // Tabela do Console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {1, -15}",
            "ID", "Nome", "Preço de Aquisição", "Data de Fabricação");

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
            );
        }

        Console.Write("Digite o ID do Equipamento a ser Editado: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o Nome do Equipamento:");
        string nome = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o Preço de Aquisição:");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("---------------------------------");
        Console.Write("Digite a Data de Fabricação (dd/mm/yyyy):");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();
        
        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.id == idSelecionado)
            {
                eq.nome = nome;
                eq.precoAquisicao = precoAquisicao;
                eq.dataFabricacao = dataFabricacao;
                break;
            }
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Equipamento {nome} Editado com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }

    else if (opcaoMenu == "3")
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Equipamentos");
        Console.WriteLine("---------------------------------");

        // Tabela do Console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {1, -15}",
            "ID", "Nome", "Preço de Aquisição", "Data de Fabricação");

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
            );
        }

        Console.Write("Digite o ID do Equipamento a ser Excluído: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.id == idSelecionado)
            {
                equipamentosSalvos[i] = null;
                break;
            }
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Equipamento foi Excluído com Sucesso!");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }

    else if (opcaoMenu == "4")
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Equipamentos");
        Console.WriteLine("---------------------------------");

        // Tabela do Console
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {1, -15}",
            "ID", "Nome", "Preço de Aquisição", "Data de Fabricação");

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione Enter Para Continuar...");
        Console.ReadLine();
    }
}
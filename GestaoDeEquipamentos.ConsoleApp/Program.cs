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

    if (opcaoMenu == "1")
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o Nome do Equipamento:");
        string nome = Console.ReadLine();

        Console.Write("Digite o Preço de Aquisição:");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());

        Console.Write("Digite a Data de Fabricação (dd/mm/yyyy):");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

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
        Console.WriteLine("Pressione Enter para continuar...");
        Console.ReadLine();
    }
    else if (opcaoMenu == "2")
    {
    }
    else if (opcaoMenu == "3")
    {
    }
    else if (opcaoMenu == "4")
    {
    }
}
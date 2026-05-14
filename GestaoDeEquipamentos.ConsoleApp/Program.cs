using System.Formats.Asn1;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

int contadorIdsEquipamentos = 1;
Equipamento[] equipamentosSalvos = new Equipamento[100];

int contadorIdsChamados = 1;
Chamados[] chamadosSalvos = new Chamados[100];

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Controle de Equipamento");
    Console.WriteLine("2 - Controle de Chamados");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenuPrincipal == "1")
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualizar Equipamentos");
            Console.WriteLine("S - Voltar ao Menu Inicial");
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
                equipamento.id = contadorIdsEquipamentos++;

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
                        eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao.ToShortDateString()
                    );
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione Enter Para Continuar...");
                Console.ReadLine();
            }
        }

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
 else if (opcaoMenuPrincipal == "2")
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Controle de Chamados");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1 - Cadastrar Chamado");
                Console.WriteLine("2 - Editar Chamado");
                Console.WriteLine("3 - Excluir Chamado");
                Console.WriteLine("4 - Visualizar Chamados");
                Console.WriteLine("S - Voltar Para o Menu Inicial");
                Console.WriteLine("---------------------------------");
                Console.Write("> ");
                string? opcaoMenu = Console.ReadLine()?.ToUpper();

                if (opcaoMenu == "S")
                {
                    Console.Clear();
                    break;
                }

                // Operações CRUD - Create, Retrieve, Update, Delete

                if (opcaoMenu == "1")
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Cadastro de Chamado");
                    Console.WriteLine("---------------------------------");

                    // Obtenção dos Dados
                    Console.Write("Digite o título do chamado: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Digite a descrição do chamado: ");
                    string descricao = Console.ReadLine();

                    DateTime dataAbertura = DateTime.Now;

                    // Apresentar os equipamentos cadastrados
                    Console.WriteLine("---------------------------------");

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
                            eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
                        );
                    }

                    Console.WriteLine("---------------------------------");

                    // Pedir para o usuário selecionar o ID do equipamento desejado
                    Console.Write("Digite o id do equipamento que deseja selecionar: ");
                    int idEquipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

                    Equipamento equipamentoSelecionado = null;

                    for (int i = 0; i < equipamentosSalvos.Length; i++)
                    {
                        Equipamento eq = equipamentosSalvos[i];

                        if (eq == null)
                            continue;

                        if (eq.id == idEquipamentoSelecionado)
                        {
                            equipamentoSelecionado = eq;
                            break;
                        }
                    }

                    Chamados novoChamado = new Chamados();
                    novoChamado.id = contadorIdsChamados++;
                    novoChamado.titulo = titulo;
                    novoChamado.descricao = descricao;
                    novoChamado.dataAbertura = dataAbertura;
                    novoChamado.equipamento = equipamentoSelecionado;

                    for (int i = 0; i < chamadosSalvos.Length; i++)
                    {
                        if (chamadosSalvos[i] == null)
                        {
                            chamadosSalvos[i] = novoChamado;
                            break;
                        }
                    }

                    Console.WriteLine($"O chamado {novoChamado.titulo} foi cadastrado com sucesso!");
                    Console.ReadLine();
                }

                else if (opcaoMenu == "4")
                {
                    Console.WriteLine(
                        "{0, -7} | {1, -15} | {2, -20} | {3, -15} | {4, -15}",
                        "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
                    );

                    for (int i = 0; i < chamadosSalvos.Length; i++)
                    {
                        Chamados ch = chamadosSalvos[i];

                        if (ch == null)
                            continue;

                        Console.WriteLine(
                            "{0, -7} | {1, -15} | {2, -20} | {3, -17} | {4, -15}",
                            ch.id,
                            ch.titulo,
                            ch.descricao,
                            ch.dataAbertura.ToShortDateString(),
                            ch.equipamento.nome
                        );
                    }

                    Console.WriteLine("---------------------------------");
                    Console.Write("Digite ENTER para Continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
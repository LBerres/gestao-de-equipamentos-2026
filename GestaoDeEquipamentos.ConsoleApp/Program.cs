using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Repositorio;

int contadorIdsChamados = 1;
Chamados[] chamadosSalvos = new Chamados[100];

TelaPrincipal telaPrincipal = new TelaPrincipal();

repositorioEquipamento = new RepositorioEquipamento();
TelaEquipamento telaEquipamento = new TelaEquipamento();
telaEquipamento.repositorioEquipamento = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();

while (true)
{
    // Apresentação: Menu Principal
    string? opcaoMenuPrincipal = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1")
        {
            string? opcaoMenu = telaEquipamento.ObterOpcaoMenuEquipamento();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            // Operações C.R.U.D - Create, Read/Retrieve, Update, Delete
            if (opcaoMenu == "1")
            {
                telaEquipamento.Cadastrar();
            }
            else if (opcaoMenu == "2")
            {
                telaEquipamento.Editar();
            }
            else if (opcaoMenu == "3")
            {
                telaEquipamento.Excluir();
            }
            else if (opcaoMenu == "4")
            {
                telaEquipamento.VisualizarTodos();
            }
        }
        else if (opcaoMenuPrincipal == "2")
        {
            string? opcaoMenu = telaChamado.ObterOpcaoMenuChamado();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            // Operações CRUD - Create, Retrieve, Update, Delete
            if (opcaoMenu == "1")
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

                // tabela do console
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                    "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
                );

                for (int i = 0; i < TelaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = TelaEquipamento.equipamentosSalvos[i];

                    if (eq == null)
                        continue;

                    Console.WriteLine(
                        "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                        eq.id,
                        eq.nome,
                        eq.precoAquisicao,
                        eq.dataFabricacao.ToShortDateString()
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

                for (int i = 0; i < TelaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = TelaEquipamento.equipamentosSalvos[i];

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

                Console.WriteLine($"O Chamado {novoChamado.titulo} Foi Cadastrado com Sucesso!");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.ReadLine();
            }

            else if (opcaoMenu == "2")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine("Edição de Chamados");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

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
                        ch.id,
                        ch.titulo,
                        ch.descricao,
                        ch.dataAbertura.ToShortDateString(),
                        ch.equipamento.nome
                    );
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");

                Console.Write("Digite o ID do Chamado a ser Editado: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

                Console.Write("Digite o Novo Título Para o Chamado: ");
                string titulo = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

                Console.Write("Digite a Nova Descrição para o Chamado: ");
                string descricao = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

                Console.Write("Digite a Nova Data de Abertura do Chamado (dd/mm/yyyy): ");
                DateTime dataAbertura = DateTime.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < chamadosSalvos.Length; i++)
                {
                    Chamados ch = chamadosSalvos[i];

                    if (ch == null)
                        continue;

                    if (ch.id == idSelecionado)
                    {
                        ch.titulo = titulo;
                        ch.descricao = descricao;
                        ch.dataAbertura = dataAbertura;
                        break;
                    }
                }
            }

            else if (opcaoMenu == "3")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine("Exclusão de Chamados");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

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
                        ch.id,
                        ch.titulo,
                        ch.descricao,
                        ch.dataAbertura.ToShortDateString(),
                        ch.equipamento.nome
                    );
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");

                Console.Write("Digite o ID do Chamado a ser Excluído: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine);

                for (int i = 0; i < chamadosSalvos.Length; i++)
                {
                    Chamados ch = chamadosSalvos[i];

                    if (ch == null)
                        continue;

                    if (ch.id == idSelecionado)
                    {
                        chamadosSalvos[i] = null;
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Chamado foi Excluído com Sucesso!");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione Enter Para Continuar...");
                Console.ReadLine();
            }

            else if (opcaoMenu == "4")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine("Visualização de Chamados");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();

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
                        ch.id,
                        ch.titulo,
                        ch.descricao,
                        ch.dataAbertura.ToShortDateString(),
                        ch.equipamento.nome
                    );
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione Enter Para Continuar...");
                Console.ReadLine();
            }

        }
    }
}

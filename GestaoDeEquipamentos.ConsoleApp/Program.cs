using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();

TelaPrincipal telaPrincipal = new TelaPrincipal();

TelaEquipamento telaEquipamento = new TelaEquipamento();
telaEquipamento.repositorioEquipamento = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

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
            string? opcaoMenu = telaEquipamento.ObterOpcaoMenu();

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
            string? opcaoMenu = telaChamado.ObterOpcaoMenu();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            // Operações CRUD - Create, Retrieve, Update, Delete
            if (opcaoMenu == "1")
            {
                telaChamado.Cadastrar();
            }

            else if (opcaoMenu == "2")
            {
                telaChamado.Editar();
            }

            else if (opcaoMenu == "3")
            {
                telaChamado.Excluir();
            }

            else if (opcaoMenu == "4")
            {
                telaChamado.VisualizarTodos();
            }
        }
    }
}

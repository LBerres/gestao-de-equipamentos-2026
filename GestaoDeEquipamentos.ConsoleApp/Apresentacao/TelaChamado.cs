namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class TelaChamdo
{
    public string ObterOpcaoMenuChamado()
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
}
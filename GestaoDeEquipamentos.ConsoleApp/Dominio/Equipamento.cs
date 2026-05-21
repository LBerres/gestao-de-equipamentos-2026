using GestaoDeEquipamentos.ConsoleApp.Utilidades;

namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Equipamento
{
    public int Id { get; private set; } // { get; set } - Propriedade Autoimplementada - Acesso de Leitura e Escrita Livre
    public string Nome { get; private set; }
    public decimal PrecoAquisicao { get; private set; }
    public DateTime DataFabricacao { get; private set; }

    //Método Construtor 
    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao)
    {   // this - referencia o objeto atual da classe, ou seja, o objeto que está sendo criado
        Id = GeradorIds.ObterIdEquipamento();

        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    public void Atualizar(Equipamento equipamentoAtualizado)
    {
        Nome = equipamentoAtualizado.Nome;
        PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
    }
}

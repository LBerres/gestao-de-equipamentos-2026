namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

using GestaoDeEquipamentos.ConsoleApp.Utilidades;
/*
    • Deve ter um identificador único (id);
    • Deve ter a título do chamado;
    • Deve ter a descrição do chamado;
    • Deve ter uma data de abertura;
    • Deve ter um equipamento;
*/

public class Chamados
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public Equipamento Equipamento { get; private set; }

    public Chamados(string titulo, string descricao, Equipamento equipamento)
    {
        Id = GeradorIds.ObterIdChamado();

        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;

        DataAbertura = DateTime.Now;
    }

    public void Atualizar(Chamados chamadoAtualizado)
    {
        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        Equipamento = chamadoAtualizado.Equipamento;
    }
}

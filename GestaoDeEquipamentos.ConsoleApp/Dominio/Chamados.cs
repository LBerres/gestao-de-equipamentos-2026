namespace GestaoDeEquipamentos.ConsoleApp.Dominio;
/*
    • Deve ter um identificador único (id);
    • Deve ter a título do chamado;
    • Deve ter a descrição do chamado;
    • Deve ter uma data de abertura;
    • Deve ter um equipamento;
*/

public class Chamados
{
    public int id;
    public string titulo;
    public string descricao;
    public DateTime dataAbertura;
    public Equipamento equipamento;
}

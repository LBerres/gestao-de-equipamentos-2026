using GestaoDeEquipamentos.ConsoleApp.Dominio;
namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    private Chamados[] chamadosSalvos = new Chamados[100];

    public void Cadastrar(Chamados novoChamado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            if (chamadosSalvos[i] == null)
            {
                chamadosSalvos[i] = novoChamado;
                break;
            }
        }
    }

    public void Editar(int idSelecionado, Chamados ChamadoAtualizado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamados chamadoSelecionado = chamadosSalvos[i];

            if (chamadoSelecionado == null)
                continue;

            if (chamadoSelecionado.Id == idSelecionado)
            {
                chamadoSelecionado.Atualizar(ChamadoAtualizado);
                break;
            }
        }
    }

    public void Excluir(int idSelecionado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamados chamadoSelecionado = chamadosSalvos[i];

            if (chamadoSelecionado == null)
                continue;

            if (chamadoSelecionado.Id == idSelecionado)
            {
                chamadosSalvos[i] = null;
                break;
            }
        }
    }

    public Chamados[] SelecionarTodos()
    {
        return chamadosSalvos;
    }
}
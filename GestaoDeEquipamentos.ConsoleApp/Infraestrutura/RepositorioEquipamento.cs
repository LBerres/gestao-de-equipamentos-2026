namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

using GestaoDeEquipamentos.ConsoleApp.Utilidades;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using System.Data.Common;
using System.Runtime.CompilerServices;

public class RepositorioEquipamento // armazém / recipiente
{
    public int contadorIdsEquipamentos = 1;
    private Equipamento[] equipamentosSalvos = new Equipamento[100];

     public void Cadastrar(Equipamento novoEquipamento)
    {
        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            if (equipamentosSalvos[i] == null)
            {
                equipamentosSalvos[i] = novoEquipamento;
                break;
            }
        }
    }

    public void Editar(int idSelecionado, Equipamento equipamentoAtualizado)
    {
        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento equipamentoSelecionado = equipamentosSalvos[i];

            if (equipamentoSelecionado == null)
                continue;

            if (equipamentoSelecionado.Id == idSelecionado)
            {
                equipamentoSelecionado.Atualizar(equipamentoAtualizado);
                break;
            }
        }
    }

    public void Excluir(int idSelecionado)
    {
        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento equipamentoSelecionado = equipamentosSalvos[i];

            if (equipamentoSelecionado == null)
                continue;

            if (equipamentoSelecionado.Id == idSelecionado)
            {
                equipamentosSalvos[i] = null;
                break;
            }
        }
    }

    public Equipamento[] SelecionarTodos()
    {
        return equipamentosSalvos;
    }
}
using Aula07.Domain.Entities;
using Aula07.Infrastrucutre.Data;

namespace Aula07.Application.Services;

public static class ClienteService
{
    public static void Incluir(Cliente cliente)
    {
        BancoDeDados.Clientes.Add(cliente);
    }

    public static void Excluir()
    {
    }

    public static List<Cliente> Listar()
    {
        return BancoDeDados.Clientes.ToList();
    }
}

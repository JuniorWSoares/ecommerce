using Aula07.Domain.Entities;

namespace Aula07.Infrastrucutre.Data;
public static class BancoDeDados
{
    public static List<Carrinho> Carrinhos { get; set; } = new();
    public static List<Cliente> Clientes { get; set; } = new();
    public static List<Produto> Produtos { get; set; } = new();
}

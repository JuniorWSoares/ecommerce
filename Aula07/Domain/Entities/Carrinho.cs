namespace Aula07.Domain.Entities;
public class Carrinho
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; } = new Cliente();
    public int ClienteId { get; set; }
    public List<Produto> Produtos { get; set; } = new ();
}

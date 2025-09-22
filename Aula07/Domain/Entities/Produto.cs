namespace Aula07.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preço { get; set; }
    public double Quantidade { get; set; }
}

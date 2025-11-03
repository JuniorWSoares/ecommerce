namespace Dominio.Entidades;
public class Produto
{
    public int Id { get;set; }
    public string Nome { get;set; } = string.Empty;
    public decimal ValorSecreto { get; set; } = 0;
}

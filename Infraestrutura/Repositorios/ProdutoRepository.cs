using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Data;

namespace Infraestrutura.Repositorios;

public class ProdutoRepository: IProdutoRepository
{
    public void Incluir(Produto produto)
    {
        BancoSql.Produtos.Add(produto);
    }

    public List<Produto> Listar()
    {
        return BancoSql.Produtos.ToList();
    }
}

using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IProdutoRepository
    {
        void Incluir(Produto produto);
        List<Produto> Listar();
    }
}

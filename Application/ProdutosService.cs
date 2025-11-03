namespace Application;

using Application.DTOs;
using Dominio.Entidades;
using Dominio.Interfaces;

public class ProdutosService
{
    private IProdutoRepository _produtoRepository;

    public ProdutosService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public void Incluir(ProdutoDTO produtoDTO)
    {
        Produto produto = produtoDTO.Mapear();
        _produtoRepository.Incluir(produto);
    }

    public List<ProdutoDTO> Listar()
    {
        List<Produto> produtos = _produtoRepository.Listar();

        List<ProdutoDTO> produtosDTO = new List<ProdutoDTO>();

        foreach (Produto produto in produtos)
        {
            ProdutoDTO dto = new ProdutoDTO { Id = produto.Id, Nome = produto.Nome };
            produtosDTO.Add(dto);
        }

        return produtosDTO;
    }
}

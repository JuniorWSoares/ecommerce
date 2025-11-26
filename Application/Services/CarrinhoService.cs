using System;
using ecommerce.Dominio.Entidades;
using ecommerce.Dominio.Interfaces;
using ecommerce.Application.DTOs;

namespace ecommerce.Application.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepo;
        private readonly IProdutoRepository _produtoRepo;

        public CarrinhoService(ICarrinhoRepository carrinhoRepo, IProdutoRepository produtoRepo)
        {
            _carrinhoRepo = carrinhoRepo;
            _produtoRepo = produtoRepo;
        }
        
        // Adiciona um item ao carrinho
        public void AdicionarItem(AdicionarItemDTO dto)
        {
            // 1. Validar se o produto existe
            var produto = _produtoRepo.ObterPorId(dto.ProdutoId);
            if (produto == null)
                throw new ArgumentException("Produto não encontrado.");

            // 2. Buscar Carrinho do Usuário
            var carrinho = _carrinhoRepo.ObterCarrinhoDoUsuario(dto.UsuarioId);

            // Se não existir, cria um novo
            if (carrinho == null)
            {
                carrinho = new Carrinho(dto.UsuarioId);
                _carrinhoRepo.Adicionar(carrinho);
            }

            // 3. Adicionar Item (A entidade recalcula o total)
            carrinho.AdicionarItem(produto, dto.Quantidade);

            // 4. Salvar atualização
            _carrinhoRepo.Atualizar(carrinho);
        }

        // Permite alterar a quantidade de um item já existente
        public void AtualizarItem(Guid usuarioId, Guid produtoId, int novaQuantidade)
        {
            var carrinho = _carrinhoRepo.ObterCarrinhoDoUsuario(usuarioId);
            if (carrinho == null) throw new ArgumentException("Carrinho não encontrado.");

            // Chama o método da Entidade (Regra de Negócio)
            carrinho.AtualizarItem(produtoId, novaQuantidade);

            _carrinhoRepo.Atualizar(carrinho);
        }

        // Remove um item do carrinho
        public void RemoverItem(Guid usuarioId, Guid produtoId)
        {
            var carrinho = _carrinhoRepo.ObterCarrinhoDoUsuario(usuarioId);
            if (carrinho == null) throw new ArgumentException("Carrinho não encontrado.");

            // Chama o método da Entidade
            carrinho.RemoverItem(produtoId);

            _carrinhoRepo.Atualizar(carrinho);
        }

        // Método para visualizar o carrinho
        public CarrinhoRespostaDTO ObterCarrinho(Guid usuarioId)
        {
            var carrinho = _carrinhoRepo.ObterCarrinhoDoUsuario(usuarioId);

            if (carrinho == null)
            {
                // Se não tem carrinho, retorna um vazio (melhor que erro 404 neste caso)
                return new CarrinhoRespostaDTO
                {
                    UsuarioId = usuarioId,
                    ValorTotal = 0,
                    Itens = new List<ItemCarrinhoDTO>()
                };
            }

            // Mapeamento manual de Entidade para DTO
            return new CarrinhoRespostaDTO
            {
                Id = carrinho.Id,
                UsuarioId = carrinho.UsuarioId,
                ValorTotal = carrinho.ValorTotal,
                Itens = carrinho.Itens.Select(i => new ItemCarrinhoDTO
                {
                    ProdutoId = i.ProdutoId,
                    Nome = i.ProdutoNome,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Subtotal = i.Subtotal
                }).ToList()
            };
        }
    }
}
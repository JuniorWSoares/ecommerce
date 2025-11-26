using Microsoft.AspNetCore.Mvc;
using ecommerce.Application.Services;
using ecommerce.Application.DTOs;
using System;

namespace ecommerce.MinhaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidoController(PedidoService service)
        {
            _service = service;
        }

        [HttpPost("finalizar")]
        public IActionResult Finalizar([FromBody] CheckoutDTO dto)
        {
            try
            {
                // A mágica do Polimorfismo e Baixa de Estoque acontece lá dentro
                var pedidoId = _service.FinalizarPedido(dto);

                return Ok(new
                {
                    mensagem = "Pedido realizado com sucesso!",
                    pedidoId = pedidoId,
                    status = "Aguardando Processamento"
                });
            }
            catch (InvalidOperationException ex) // Erro de estoque ou carrinho vazio
            {
                return StatusCode(409, new { erro = ex.Message }); // 409 Conflict
            }
            catch (ArgumentException ex) // Erro de validação (ex: cartão inválido)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno: " + ex.Message });
            }
        }

        [HttpPost("{id}/cancelar")]
        public IActionResult Cancelar(Guid id)
        {
            try
            {
                _service.CancelarPedido(id);
                return Ok(new { mensagem = "Pedido cancelado." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
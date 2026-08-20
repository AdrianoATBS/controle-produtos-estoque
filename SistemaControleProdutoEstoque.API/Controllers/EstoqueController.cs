using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarUltimaMovimentacaoDoProdutoUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IAdicionarEstoqueUseCase _adicionarEstoqueUseCase;
        private readonly IBuscarMovimentacaoPorProdutoUseCase _buscarMovimentacaoPorProdutoUseCase;
        private readonly IBuscarUltimaMovimentacaoDoProdutoUseCase _buscarUltimaMovimentacaoDoProdutoUseCase;
        private readonly IBuscarTodasMovimentacoesUseCase _buscarTodasMovimentacoesUseCase;
        public EstoqueController(IAdicionarEstoqueUseCase adicionarEstoqueUseCase,
            IBuscarMovimentacaoPorProdutoUseCase buscarMovimentacaoPorProdutoUseCase,
            IBuscarUltimaMovimentacaoDoProdutoUseCase buscarUltimaMovimentacaoDoProdutoUseCase,
            IBuscarTodasMovimentacoesUseCase buscarTodasMovimentacoesUseCase)
        {
            _adicionarEstoqueUseCase = adicionarEstoqueUseCase;
            _buscarMovimentacaoPorProdutoUseCase = buscarMovimentacaoPorProdutoUseCase;
            _buscarUltimaMovimentacaoDoProdutoUseCase = buscarUltimaMovimentacaoDoProdutoUseCase;
            _buscarTodasMovimentacoesUseCase = buscarTodasMovimentacoesUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEstoque(AdicionarEstoqueRequest request)
        {
            try
            {
               var resultado = await _adicionarEstoqueUseCase.Executar(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("buscar-movimentacoes/{produtoId}")]
        public async Task<IActionResult> BuscarMovimentacaoPorProduto(Guid produtoId)
        {
            try
            {
                var resultado = await _buscarMovimentacaoPorProdutoUseCase.Executar(produtoId);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("ultima-movimentacao/{produtoId}")]
        public async Task<IActionResult> BuscarUltimaMovimentacaoDoProduto(Guid produtoId)
        {
            var resultado = await _buscarUltimaMovimentacaoDoProdutoUseCase.Executar(produtoId);
            return Ok(resultado);
        }
        [HttpGet("todas-movimentacoes")]
        public async Task<IActionResult> BuscarTodasMovimentacoes()
        {
            try
            {
                var resultado = await _buscarTodasMovimentacoesUseCase.Executar();
                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;
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
        public EstoqueController(IAdicionarEstoqueUseCase adicionarEstoqueUseCase,
            IBuscarMovimentacaoPorProdutoUseCase buscarMovimentacaoPorProdutoUseCase,
            IBuscarUltimaMovimentacaoDoProdutoUseCase buscarUltimaMovimentacaoDoProdutoUseCase)
        {
            _adicionarEstoqueUseCase = adicionarEstoqueUseCase;
            _buscarMovimentacaoPorProdutoUseCase = buscarMovimentacaoPorProdutoUseCase;
            _buscarUltimaMovimentacaoDoProdutoUseCase = buscarUltimaMovimentacaoDoProdutoUseCase;
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
        [HttpGet("{produtoId}")]
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
        [HttpGet("/ultima-movimentacao/{produtoId}")]
        public async Task<IActionResult> BuscarUltimaMovimentacaoDoProduto(Guid produtoId)
        {
            var resultado = await _buscarUltimaMovimentacaoDoProdutoUseCase.Executar(produtoId);
            return Ok(resultado);
        }

    }
}

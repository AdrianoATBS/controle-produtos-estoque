using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IAdicionarEstoqueUseCase _adicionarEstoqueUseCase;
        private readonly IBuscarMovimentacaoPorProdutoUseCase _buscarMovimentacaoPorProdutoUseCase;
        public EstoqueController(IAdicionarEstoqueUseCase adicionarEstoqueUseCase,
            IBuscarMovimentacaoPorProdutoUseCase buscarMovimentacaoPorProdutoUseCase)
        {
            _adicionarEstoqueUseCase = adicionarEstoqueUseCase;
            _buscarMovimentacaoPorProdutoUseCase = buscarMovimentacaoPorProdutoUseCase;
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

    }
}

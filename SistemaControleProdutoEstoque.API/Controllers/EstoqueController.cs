using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarUltimaMovimentacaoDoProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.FiltrarPorPeriodoUseCase;

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
        private readonly IFiltrarPorPeriodoUseCase _filtrarPorPeriodoUseCase;
        public EstoqueController(IAdicionarEstoqueUseCase adicionarEstoqueUseCase,
            IBuscarMovimentacaoPorProdutoUseCase buscarMovimentacaoPorProdutoUseCase,
            IBuscarUltimaMovimentacaoDoProdutoUseCase buscarUltimaMovimentacaoDoProdutoUseCase,
            IBuscarTodasMovimentacoesUseCase buscarTodasMovimentacoesUseCase,
            IFiltrarPorPeriodoUseCase filtrarPorPeriodoUseCase)
        {
            _adicionarEstoqueUseCase = adicionarEstoqueUseCase;
            _buscarMovimentacaoPorProdutoUseCase = buscarMovimentacaoPorProdutoUseCase;
            _buscarUltimaMovimentacaoDoProdutoUseCase = buscarUltimaMovimentacaoDoProdutoUseCase;
            _buscarTodasMovimentacoesUseCase = buscarTodasMovimentacoesUseCase;
            _filtrarPorPeriodoUseCase = filtrarPorPeriodoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEstoque(AdicionarEstoqueRequest request)
        {
           
            var resultado = await _adicionarEstoqueUseCase.Executar(request);
            return Ok(resultado);
            
        }
        [HttpGet("buscar-movimentacoes/{produtoId}")]
        public async Task<IActionResult> BuscarMovimentacaoPorProduto(Guid produtoId)
        {
           
            var resultado = await _buscarMovimentacaoPorProdutoUseCase.Executar(produtoId);
            return Ok(new { message = "Movimentação encontrada", data = resultado });
          
            
        }
        [HttpGet("ultima-movimentacao/{produtoId}")]
        public async Task<IActionResult> BuscarUltimaMovimentacaoDoProduto(Guid produtoId)
        {
            var resultado = await _buscarUltimaMovimentacaoDoProdutoUseCase.Executar(produtoId);
            return Ok(new { message = "Última movimentação encontrada", data = resultado });
        }

        [HttpGet("todas-movimentacoes")]
        public async Task<IActionResult> BuscarTodasMovimentacoes()
        {
         
            var resultado = await _buscarTodasMovimentacoesUseCase.Executar();
            return Ok(new { message = "Todas as movimentações encontradas", data = resultado });


        }
        [HttpGet("filtrar-por-periodo")]
        public async Task<IActionResult> FiltrarPorPeriodo([FromQuery]FiltrarPorPeriodoRequest request)
        {
           
            var resultado = await _filtrarPorPeriodoUseCase.Executar(request);
            return Ok(new {message="Movimentações filtradas com sucesso.", dados=resultado});
           
        }

    }
}

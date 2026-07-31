using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    { 
        private readonly ICriarProdutoUseCase _criarProdutoUseCase;
        private readonly IAlterarProdutoUseCase _alterarProdutoUseCase;
        private readonly IBuscarProdutoPorIdUseCase _buscarProdutoPorIdUseCase;
        private readonly IListarTodosOsProdutosUseCase _listarTodosOsProdutosUseCase;
        public ProdutosController(ICriarProdutoUseCase criarProdutoUseCase,
            IAlterarProdutoUseCase alterarProdutoUseCase, IBuscarProdutoPorIdUseCase
            buscarProdutoPorIdUseCase, IListarTodosOsProdutosUseCase listarTodosOsProdutosUseCase)
        {
            _criarProdutoUseCase = criarProdutoUseCase;
            _alterarProdutoUseCase = alterarProdutoUseCase;
            _buscarProdutoPorIdUseCase = buscarProdutoPorIdUseCase;
            _listarTodosOsProdutosUseCase = listarTodosOsProdutosUseCase;
        }
        [HttpPost]
        public async Task<IActionResult> CriarProduto(CriarProdutoRequest request)
        {
            try
            {
                var produto = await _criarProdutoUseCase.Executar(request);
                return Created(string.Empty, produto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarProduto(Guid id, AlterarProdutoRequest request)
        {
            try
            {
                var produtoAlterado = await _alterarProdutoUseCase.Executar(id, request);
                return Ok(produtoAlterado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>BuscarProdutoPorId(Guid id)
        {
            try
            {
                var produto = await _buscarProdutoPorIdUseCase.Executar(id);
                return (Ok(new { message = "Produto encontrado", data = produto }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ListarTodasOsProdutos()
        {
            try
            {
                var produtos = await _listarTodosOsProdutosUseCase.Executar();

                return Ok(new { message = "Produtos encontrados", data = produtos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

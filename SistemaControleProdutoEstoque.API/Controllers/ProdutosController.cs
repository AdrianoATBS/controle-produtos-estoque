using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.DeletarCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutosPorCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DeletarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ReativarProdutoUseCase;

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
        private readonly IDesativarProdutoUseCase _desativarProdutoUseCase;
        private readonly IReativarProdutoUseCase _reativarProdutoUseCase;
        private readonly IDeletarProdutoUseCase _deletarProdutoUseCase;
        private readonly IBuscarProdutosPorCategoriaUseCase _buscarProdutosPorCategoriaUseCase;
        public ProdutosController(ICriarProdutoUseCase criarProdutoUseCase,
            IAlterarProdutoUseCase alterarProdutoUseCase, IBuscarProdutoPorIdUseCase
            buscarProdutoPorIdUseCase, IListarTodosOsProdutosUseCase listarTodosOsProdutosUseCase,
            IDesativarProdutoUseCase desativarProdutoUseCase, 
            IReativarProdutoUseCase reativarProdutoUseCase, IDeletarProdutoUseCase deletarProdutoUseCase,
            IBuscarProdutosPorCategoriaUseCase buscarProdutosPorCategoriaUseCase)
        {
            _criarProdutoUseCase = criarProdutoUseCase;
            _alterarProdutoUseCase = alterarProdutoUseCase;
            _buscarProdutoPorIdUseCase = buscarProdutoPorIdUseCase;
            _listarTodosOsProdutosUseCase = listarTodosOsProdutosUseCase;
            _desativarProdutoUseCase = desativarProdutoUseCase;
            _reativarProdutoUseCase = reativarProdutoUseCase;
            _deletarProdutoUseCase = deletarProdutoUseCase;
            _buscarProdutosPorCategoriaUseCase = buscarProdutosPorCategoriaUseCase;

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
        [HttpPut("{id}/desativar")]
      
        public async Task<IActionResult> DesativarProduto(Guid id)
        {
            try
            {
                await _desativarProdutoUseCase.Executar(id);
                return Ok(new { message = "Produto desativado com sucesso"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}/reativar")]
        public async Task<IActionResult> ReativarProduto(Guid id)
        {
            try
            {
                await _reativarProdutoUseCase.Executar(id);
                return Ok(new { message = "Produto reativado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(Guid id)
        {
            try
            {
                await _deletarProdutoUseCase.Executar(id);
                return Ok(new { message = "Produto deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("buscar-categoria/{categoriaId}")]
        public async Task<IActionResult> BuscarProdutosPorCategoriaResponse(Guid categoriaId)
        {
            try
            {
                var produtos = await _buscarProdutosPorCategoriaUseCase.Executar(categoriaId);
                return Ok(new { message = "Produtos encontrados", data = produtos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    { 
        private readonly ICriarProdutoUseCase _criarProdutoUseCase;
        private readonly IAlterarProdutoUseCase _alterarProdutoUseCase;
        public ProdutosController(ICriarProdutoUseCase criarProdutoUseCase,
            IAlterarProdutoUseCase alterarProdutoUseCase)
        {
            _criarProdutoUseCase = criarProdutoUseCase;
            _alterarProdutoUseCase = alterarProdutoUseCase;
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

    }
}

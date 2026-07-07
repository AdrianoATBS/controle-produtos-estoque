using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.UseCases;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICriarCategoriaUseCase  _criarCategoriaUseCase;
        public CategoriasController(ICriarCategoriaUseCase criarCategoriaUseCase)
        {
            _criarCategoriaUseCase = criarCategoriaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaRequest request)
        {
            var resultado = await _criarCategoriaUseCase.Executar(request);

            
            return Created(string.Empty, resultado);
        }
    }
}

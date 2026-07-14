using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.UseCases;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICriarCategoriaUseCase  _criarCategoriaUseCase;
        private readonly IAlterarNomeCategoriaUseCase _alterarNomeCategoriaUseCase;
        private readonly IBuscarCategoriaPorIdUseCase _buscarCategoriaPorIdUseCase;
        public CategoriasController(ICriarCategoriaUseCase criarCategoriaUseCase,
            IAlterarNomeCategoriaUseCase alterarNomeCategoriaUseCase,
            IBuscarCategoriaPorIdUseCase buscarCategoriaPorIdUseCase)
        {
            _criarCategoriaUseCase = criarCategoriaUseCase;
            _alterarNomeCategoriaUseCase = alterarNomeCategoriaUseCase;
            _buscarCategoriaPorIdUseCase = buscarCategoriaPorIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaRequest request)
        {
            try
            {
                var resultado = await _criarCategoriaUseCase.Executar(request);

                return Created(string.Empty, resultado);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarNomeCategoria(Guid id, AlterarNomeCategoriaRequest request)
        {
            try
            {
                var resultado = await _alterarNomeCategoriaUseCase.Executar(id, request);
                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCategoriaPorId(Guid id)
        {
            try
            {
                var resultado = await _buscarCategoriaPorIdUseCase.Executar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

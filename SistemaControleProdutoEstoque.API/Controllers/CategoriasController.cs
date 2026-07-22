using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.UseCases;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.DeletarCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.DesativarCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.ListarTodasCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.ReativarCategoriaUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICriarCategoriaUseCase  _criarCategoriaUseCase;
        private readonly IAlterarNomeCategoriaUseCase _alterarNomeCategoriaUseCase;
        private readonly IBuscarCategoriaPorIdUseCase _buscarCategoriaPorIdUseCase;
        private readonly IListaTodasCategoriaUseCase _listaTodasCategoriaUseCase;
        private readonly IDesativarCategoriaUseCase _desativarCategoriaUseCase;
        private readonly IReativarCategoriaUseCase _reativarCategoriaUseCase;
        private readonly IDeletarCategoriaUseCase _deletarCategoriaUseCase;
        public CategoriasController(ICriarCategoriaUseCase criarCategoriaUseCase,
            IAlterarNomeCategoriaUseCase alterarNomeCategoriaUseCase,
            IBuscarCategoriaPorIdUseCase buscarCategoriaPorIdUseCase,
            IListaTodasCategoriaUseCase listaTodasCategoriaUseCase,
            IDesativarCategoriaUseCase desativarCategoriaUseCase,
            IReativarCategoriaUseCase reativarCategoriaUseCase,
            IDeletarCategoriaUseCase deletarCategoriaUseCase)
        {
            _criarCategoriaUseCase = criarCategoriaUseCase;
            _alterarNomeCategoriaUseCase = alterarNomeCategoriaUseCase;
            _buscarCategoriaPorIdUseCase = buscarCategoriaPorIdUseCase;
            _listaTodasCategoriaUseCase = listaTodasCategoriaUseCase;
            _desativarCategoriaUseCase = desativarCategoriaUseCase;
            _reativarCategoriaUseCase = reativarCategoriaUseCase;
            _deletarCategoriaUseCase = deletarCategoriaUseCase;
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

        [HttpGet]
        public async Task<IActionResult> ListaTodasCategorias()
        {
            try
            {
                var resultado = await _listaTodasCategoriaUseCase.Executar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}/desativar")]
        public async Task<IActionResult> DesativarCategoria(Guid id)
        {
            try
            {
                await _desativarCategoriaUseCase.Executar(id);
                return Ok(new { mensagem = "Categoria desativada com sucesso"});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}/reativar")]
        public async Task<IActionResult> ReativarCategoria(Guid id)
        {
            try
            {
                await _reativarCategoriaUseCase.Executar(id);
                return Ok(new { message = "Categoria reativada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}/deletar")]
        public async Task<IActionResult> DeletarCategoria(Guid id)
        {
            try
            {
                await _deletarCategoriaUseCase.Executar(id);
                return Ok(new { message = "Categoria deletada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

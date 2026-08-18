using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;

namespace SistemaControleProdutoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IAdicionarEstoqueUseCase _adicionarEstoqueUseCase;
        public EstoqueController(IAdicionarEstoqueUseCase adicionarEstoqueUseCase)
        {
            _adicionarEstoqueUseCase = adicionarEstoqueUseCase;
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
    }
}

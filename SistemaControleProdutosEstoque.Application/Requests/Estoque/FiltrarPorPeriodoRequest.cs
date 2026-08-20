namespace SistemaControleProdutosEstoque.Application.Requests.Estoque;

public class FiltrarPorPeriodoRequest
{
    public DateOnly DataInicio { get; set; } 
    public DateOnly DataFim { get; set; } 
}

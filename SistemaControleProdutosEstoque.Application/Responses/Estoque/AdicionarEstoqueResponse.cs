using SistemaControleProdutosEstoque.Domain.Enums;

namespace SistemaControleProdutosEstoque.Application.Responses.Estoque;

public class AdicionarEstoqueResponse
{
    public  Guid Id { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeAtual { get; set; } 
    public TipoMovimentacao TipoEstoque { get; set; }
    public string DataCriacao {  get; set; } = string.Empty;
    

}

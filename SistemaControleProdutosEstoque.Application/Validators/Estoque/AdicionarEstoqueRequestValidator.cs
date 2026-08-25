using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;

namespace SistemaControleProdutosEstoque.Application.Validators.Estoque;

public class AdicionarEstoqueRequestValidator : AbstractValidator<AdicionarEstoqueRequest>
{
    public AdicionarEstoqueRequestValidator()
    {
        RuleFor(request => request.ProdutoId)
            .NotEmpty().WithMessage("O ID do produto é obrigatório.");
        RuleFor(request => request.Quantidade)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
    }
}

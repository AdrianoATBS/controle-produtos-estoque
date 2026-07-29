using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Produto;

namespace SistemaControleProdutosEstoque.Application.Validators.Produtos;

public class AlterarProdutoRequestValidator : AbstractValidator<AlterarProdutoRequest>
{
    public AlterarProdutoRequestValidator()
    {
        RuleFor(request => request.NovoNome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do produto deve ter no mínimo 3 catacteres")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres");
        RuleFor(request => request.NovaDescricao)
            .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
            .MinimumLength(3).WithMessage("A descrição do produto deve ter no mínimo 3 catacteres")
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres");
        RuleFor(request => request.NovoPreco)
            .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        RuleFor(request => request.NovoEstoque)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque do produto deve ser maior ou igual a zero.");
    }

        
}

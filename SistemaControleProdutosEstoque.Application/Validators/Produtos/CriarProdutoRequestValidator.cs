using FluentValidation;
using FluentValidation.Validators;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Requests.Produto;

namespace SistemaControleProdutosEstoque.Application.Validators.Produtos;

public class CriarProdutoRequestValidator : AbstractValidator<CriarProdutoRequest>
{
    public CriarProdutoRequestValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do produto deve ter no mínimo 3 catacteres")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres");

        RuleFor(request => request.Descricao)
            .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
            .MinimumLength(3).WithMessage("A descrição do produto deve ter no mínimo 3 catacteres")
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres");

        RuleFor(request => request.Preco)
            .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

        RuleFor(request => request.QuantidadeEstoque)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque do produto não pode ser negativa.");
    
    }

}

using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;

namespace SistemaControleProdutosEstoque.Application.Validators.Categorias;

public class CriarCategoriaRequestValidator : AbstractValidator<CriarCategoriaRequest>
{
    public CriarCategoriaRequestValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
            .MinimumLength(3).WithMessage("O nome da categoria deve ter no mínimo 3 catacteres")
            .MaximumLength(100).WithMessage("O nome da categoria deve ter no máximo 100 caracteres");
    }
}

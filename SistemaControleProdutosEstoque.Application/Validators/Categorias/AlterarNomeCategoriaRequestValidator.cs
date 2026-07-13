using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;

namespace SistemaControleProdutosEstoque.Application.Validators.Categorias;

public class AlterarNomeCategoriaRequestValidator : AbstractValidator<AlterarNomeCategoriaRequest>
{
    public AlterarNomeCategoriaRequestValidator()
    {
        RuleFor(request => request.NovoNome)
            .NotEmpty().WithMessage("O novo nome da categoria é obrigatório.")
            .MinimumLength(3).WithMessage("O novo nome da categoria deve ter no mínimo 3 caracteres.")
            .MaximumLength(100).WithMessage("O novo nome da categoria deve ter no máximo 100 caracteres.");
    }
}

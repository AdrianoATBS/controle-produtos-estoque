using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;

namespace SistemaControleProdutosEstoque.Application.Validators.Estoque;

public class FiltrarPorPeriodoRequestValidator : AbstractValidator<FiltrarPorPeriodoRequest>
{
    public FiltrarPorPeriodoRequestValidator()
    {
        RuleFor(x => x.DataInicio)
              .NotEmpty()
              .WithMessage("A data de início é obrigatória.");
        RuleFor(x => x.DataFim)
            .NotEmpty()
            .WithMessage("A data de fim é obrigatória.");
        RuleFor(x => x)
            .Must(x => x.DataInicio <= x.DataFim)
            .WithMessage("A data de inicio não pode ser maior que a data de fim");
    }
}

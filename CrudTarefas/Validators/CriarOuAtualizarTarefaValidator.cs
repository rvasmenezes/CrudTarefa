using CrudTarefas.Domain.Aggregates.Resquests;
using FluentValidation;
using CrudTarefas.Domain.Helpers;

namespace CrudTarefas.API.Validators
{
    public class CriarOuAtualizarTarefaValidator : AbstractValidator<CriarOuAtualizarTarefaRequest>
    {
        public CriarOuAtualizarTarefaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotNull().WithMessage("Titulo inválido")
                .NotEmpty().WithMessage("Titulo é obrigatório")
                .MaximumLength(50).WithMessage("Titulo deve ter no máximo 50 caracteres");

            RuleFor(x => x.DataEntrega)
                .GreaterThan(DateTime.Now.TimeZoneBrasil()).WithMessage("A data de entrega deve ser futura");
        }
    }
}

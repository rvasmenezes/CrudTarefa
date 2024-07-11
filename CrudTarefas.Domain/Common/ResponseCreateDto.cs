using CrudTarefas.Domain.Helpers;

namespace CrudTarefas.Domain.Common
{
    public class ResponseCreateDto<T> : Validator
    {
        public object Entity { get; set; }

        public override bool IsValid() => ValidationResult.IsValid;
    }
}

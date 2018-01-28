using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amigo.API.Model
{
    public class Amigo : IValidatableObject
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resultados = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Nome))
            {
                resultados.Add(new ValidationResult("O nome é obrigatório", new []{nameof(Nome) }));
            }

            return resultados;
        }
    }
}
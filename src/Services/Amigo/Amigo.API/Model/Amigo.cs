using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.Services.API.Model
{
    public class Amigo : IValidatableObject
    {
        public Amigo(int id, string nome, string telefone)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
        }

        protected Amigo()
        {
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Telefone { get; private set; }

        public Amigo SetTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public Amigo SetId(int id)
        {
            Id = id;
            return this;
        }

        public Amigo SetNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resultados = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Nome))
            {
                resultados.Add(new ValidationResult("O nome é obrigatório", new[] { nameof(Nome) }));
            }

            return resultados;
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.Services.Game.API.Model
{
    public class Game : IValidatableObject
    {
        public Game(int id, string nome, bool disponivel)
        {
            Id = id;
            Nome = nome;
            Disponivel = disponivel;
        }

        protected Game()
        {
        }

        public int Id
        {
            get;
            private set;
        }

        public string Nome
        {
            get;
            private set;
        }

        public Game SetNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public bool Disponivel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resultados = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Nome))
            {
                resultados.Add(new ValidationResult("O nome é obrigatório",
                                                    new[] { nameof(Nome) }));
            }

            return resultados;
        }
    }
}
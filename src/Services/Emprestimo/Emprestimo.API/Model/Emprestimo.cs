using System;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Model
{
    public class Emprestimo
    {
        protected Emprestimo()
        {
        }

        public Emprestimo(int id, int gameId, string gameNome, int amigoId, string amigoNome, bool devolvido, DateTime dataDoEmprestimo)
        {
            Id = id;
            GameNome = gameNome;
            GameId = gameId;
            AmigoId = amigoId;
            AmigoNome = amigoNome;
            Devolvido = devolvido;
            DataDoEmprestimo = dataDoEmprestimo;
        }

        public Emprestimo SetId(int id)
        {
            Id = id;
            return this;
        }

        public int Id { get; private set; }

        public int GameId { get; private set; }

        public string GameNome { get; private set; }

        public int AmigoId { get; private set; }

        public string AmigoNome { get; private set; }

        public bool Devolvido { get; private set; }

        public DateTime DataDoEmprestimo { get; private set; }
    }
}
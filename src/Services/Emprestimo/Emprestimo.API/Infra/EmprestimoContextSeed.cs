using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Infra
{
    public class EmprestimoContextSeed
    {
        public async Task SeedAsync(EmprestimoContext context)
        {
            if (!context.Emprestimos.Any())
            {
                context.Emprestimos.AddRange(GetEmprestimos());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<Model.Emprestimo> GetEmprestimos()
        {
            return new[]
            {
                new Model.Emprestimo(1, 1, "Game 1", 1, "Game 1", false, DateTime.Now),
                new Model.Emprestimo(2, 2, "Game 2", 2, "Game 2", true, DateTime.Now),
                new Model.Emprestimo(3, 3, "Game 3", 3, "Game 3", true, DateTime.Now),
                new Model.Emprestimo(4, 4, "Game 4", 4, "Game 4", false, DateTime.Now)
            };
        }
    }
}
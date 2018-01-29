using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Models
{
    public class EmprestimoFormViewModel : EmprestimoViewModel
    {
        public EmprestimoFormViewModel()
        {
            Amigos = new List<SelectListItem>();
            GamesDisponiveis = new List<SelectListItem>();
        }

        public ICollection<SelectListItem> Amigos { get; }
        public ICollection<SelectListItem> GamesDisponiveis { get; }

        public void AddAmigos(IEnumerable<AmigoViewModel> amigoViewModel)
        {
            foreach (var viewModel in amigoViewModel)
                Amigos.Add(new SelectListItem { Value = viewModel.Id.ToString(), Text = viewModel.Nome});
        }

        public void AddGames(IEnumerable<GameViewModel> gameViewModels)
        {
            foreach (var viewModel in gameViewModels)
                GamesDisponiveis.Add(new SelectListItem { Value = viewModel.Id.ToString(), Text = viewModel.Nome });
        }

        public static EmprestimoFormViewModel Clone(EmprestimoViewModel emprestimoViewModel)
        {
            return new EmprestimoFormViewModel
            {
                Id = emprestimoViewModel.Id,
                AmigoId = emprestimoViewModel.AmigoId,
                AmigoNome = emprestimoViewModel.AmigoNome,
                DataDoEmprestimo = emprestimoViewModel.DataDoEmprestimo,
                Devolvido = emprestimoViewModel.Devolvido,
                GameId = emprestimoViewModel.GameId,
                GameNome = emprestimoViewModel.GameNome
            };
        }
    }
}
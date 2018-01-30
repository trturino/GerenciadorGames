using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;
using trturino.GerenciadorGames.WebApps.WebMVC.Services;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Controllers
{
    [Route("emprestimo")]
    //[Authorize]
    public class EmprestimoController : Controller
    {
        private readonly IAmigoService _amigoService;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IGameService _gameService;

        public EmprestimoController(
            IEmprestimoService emprestimoService,
            IAmigoService amigoService,
            IGameService gameService
        )
        {
            _emprestimoService = emprestimoService;
            _amigoService = amigoService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var emprestimoViewModels = await _emprestimoService.GetAll();

                return View(emprestimoViewModels);
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }


        [Route("editar/{id}")]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var emprestimoViewModel = await GetForm(await _emprestimoService.GetById(id));

                return View(emprestimoViewModel);
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        [Route("editar/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar(EmprestimoViewModel emprestimoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(await GetForm(emprestimoViewModel));

                await _emprestimoService.Edit(emprestimoViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        [Route("novo")]
        public async Task<IActionResult> Novo()
        {
            var emprestimoViewModel = await GetForm(EmprestimoViewModel.Create());

            return View(emprestimoViewModel);
        }

        [Route("novo")]
        [HttpPost]
        public async Task<IActionResult> Novo(EmprestimoViewModel emprestimoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(await GetForm(emprestimoViewModel));

                await _emprestimoService.Add(emprestimoViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        [Route("devolver/{id}")]
        [HttpGet]
        public async Task<IActionResult> Devolver(int id)
        {
            try
            {
                var emprestimo = await _emprestimoService.GetById(id);
                emprestimo.Devolvido = true;
                await _emprestimoService.Edit(emprestimo);

                var game = await _gameService.GetById(emprestimo.GameId);
                game.Disponivel = true;
                await _gameService.Edit(game);

            }
            catch (Exception)
            {
                TratarErro();
            }

            return RedirectToAction(nameof(Index));
        }

        private void TratarErro()
        {
            ViewBag.Erro = "Emprestimos está inoperante no momento :(";
        }

        private async Task<EmprestimoFormViewModel> GetForm(EmprestimoViewModel emprestimoViewModel)
        {
            var form = EmprestimoFormViewModel.Clone(emprestimoViewModel);
            form.AddAmigos(await _amigoService.GetAll());
            form.AddGames(await _gameService.GetGamesDisponiveis());

            if (form.GameId > 0)
                form.AddGame(new GameViewModel() { Id = form.GameId, Nome = form.AmigoNome});

            if (form.AmigoId > 0)
                form.AddAmigo(new AmigoViewModel() { Id = form.GameId, Nome = form.AmigoNome });

            return form;
        }
    }
}
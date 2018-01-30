using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;
using trturino.GerenciadorGames.WebApps.WebMVC.Services;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Controllers
{
    [Route("game")]
    //[Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var amigos = await _gameService.GetAll();

                return View(amigos);
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
                var gameViewModel = await _gameService.GetById(id);

                return View(gameViewModel);
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        [Route("editar/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar(GameViewModel gameViewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View(gameViewModel);

                await _gameService.Edit(gameViewModel);

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
            return View();
        }

        [Route("novo")]
        [HttpPost]
        public async Task<IActionResult> Novo(GameViewModel gameViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(gameViewModel);

                gameViewModel.Disponivel = true;
                await _gameService.Add(gameViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        private void TratarErro()
        {
            ViewBag.Erro = "Games está inoperante no momento :(";
        }
    }
}

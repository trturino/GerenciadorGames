using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;
using trturino.GerenciadorGames.WebApps.WebMVC.Services;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Controllers
{
    [Route("amigo")]
    public class AmigoController : Controller
    {
        private readonly IAmigoService _amigoService;

        public AmigoController(IAmigoService amigoService)
        {
            _amigoService = amigoService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var amigos = await _amigoService.GetAll();

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
                var amigoViewModel = await _amigoService.GetById(id);

                return View(amigoViewModel);
            }
            catch (Exception)
            {
                TratarErro();
            }

            return View();
        }

        [Route("editar/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar(AmigoViewModel amigoViewModel)
        {
            try
            {
                await _amigoService.Edit(amigoViewModel);

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
        public async Task<IActionResult> Novo(AmigoViewModel amigoViewModel)
        {
            try
            {
                await _amigoService.Add(amigoViewModel);

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
            ViewBag.Erro = "Amigos está inoperante no momento :(";
        }
    }
}

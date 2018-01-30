using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Services;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IAmigoService _amigoService;
        private readonly IGameService _gameService;

        public HomeController(
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
            ViewBag.Emprestimos = await _emprestimoService.GetAll();
            ViewBag.Games = await _gameService.GetAll();
            ViewBag.Amigos = await _amigoService.GetAll();

            return View();
        }
    }
}
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;
using trturino.GerenciadorGames.WebApps.WebMVC.Services;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Controllers
{
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.Identity.API.Models;
using trturino.GerenciadorGames.Services.Identity.API.Models.ViewModels;
using trturino.GerenciadorGames.Services.Identity.API.Services;

namespace trturino.GerenciadorGames.Services.Identity.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService<Usuario> _loginService;
        private readonly IIdentityServerInteractionService _interaction;

        public AccountController(
            ILoginService<Usuario> loginService,
            IIdentityServerInteractionService interaction
            )
        {
            _loginService = loginService;
            _interaction = interaction;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            //var vm = await BuildLoginViewModelAsync(returnUrl, context);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.FindByUsername(model.Email);
                if (await _loginService.ValidateCredentials(user, model.Senha))
                {
                    AuthenticationProperties props = null;

                    if (_interaction.IsValidReturnUrl(model.UrlRetorno))
                    {
                        return Redirect(model.UrlRetorno);
                    }

                    return Redirect("~/");
                }

                ModelState.AddModelError("", "Usuario ou senha invalido.");
            }

            //var vm = await BuildLoginViewModelAsync(model);

            ViewData["ReturnUrl"] = model.UrlRetorno;

            return View(model);
        }
    }
}
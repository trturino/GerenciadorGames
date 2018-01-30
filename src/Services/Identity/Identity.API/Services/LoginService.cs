using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using trturino.GerenciadorGames.Services.Identity.API.Models;

namespace trturino.GerenciadorGames.Services.Identity.API.Services
{
    public class LoginService : ILoginService<Usuario>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public LoginService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Usuario> FindByUsername(string user)
        {
            return await _userManager.FindByEmailAsync(user);
        }

        public async Task<bool> ValidateCredentials(Usuario user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public Task SignIn(Usuario user)
        {
            return _signInManager.SignInAsync(user, true);
        }
    }
}
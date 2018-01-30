using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.Services.Identity.API.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string UrlRetorno { get; set; }
    }
}
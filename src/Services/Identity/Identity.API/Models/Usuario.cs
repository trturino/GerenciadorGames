using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.Services.Identity.API.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Nome { get; set; }
    }
}
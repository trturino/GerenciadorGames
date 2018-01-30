using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Models
{
    public class GameViewModel
    {
        [Required]
        public string Nome { get; set; }

        public int Id { get; set; }

        public bool Disponivel { get; set; }
    }
}
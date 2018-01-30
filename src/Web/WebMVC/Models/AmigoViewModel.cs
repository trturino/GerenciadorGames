using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Models
{
    public class AmigoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
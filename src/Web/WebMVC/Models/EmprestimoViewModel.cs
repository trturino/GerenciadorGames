using System;
using System.ComponentModel.DataAnnotations;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Models
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }

        [Range(1, Int32.MaxValue)]
        public int GameId { get; set; }

        [Required]
        public string GameNome { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AmigoId { get; set; }

        [Required]
        public string AmigoNome { get; set; }

        public bool Devolvido { get; set; }

        public DateTime DataDoEmprestimo { get; set; }

        public static EmprestimoViewModel Create()
        {
            return new EmprestimoViewModel
            {
                AmigoId = -1,
                Devolvido = false,
                GameId = -1
            };
        }
    }
}
using System;
namespace trturino.GerenciadorGames.WebApps.WebMVC.Models
{
    public class EmprestimoViewModel
    {

        public int Id
        {
            get;
            set;
        }

        public int GameId
        {
            get;
            set;
        }

        public string GameNome
        {
            get;
            set;
        }

        public int AmigoId
        {
            get;
            set;
        }

        public string AmigoNome
        {
            get;
            set;
        }

        public bool Devolvido
        {
            get;
            set;
        }

        public DateTime DataDoEmprestimo
        {
            get;
            set;
        }
    }
}

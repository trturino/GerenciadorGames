namespace trturino.GerenciadorGames.WebApps.WebMVC
{
    public class AppSettings
    {
        public Connectionstrings ConnectionStrings { get; set; }
        public string AmigoUrl { get; set; }
        public string EmprestimoUrl { get; set; }
        public string GameUrl { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }
}
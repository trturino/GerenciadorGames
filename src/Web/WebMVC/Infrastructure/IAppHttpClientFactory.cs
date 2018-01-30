namespace trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure
{
    public interface IAppHttpClientFactory
    {
        AppHttpClient CreateHttpClient();
    }
}
using System;
namespace trturino.GerenciadorGames.Services.API.Infra.Filters
{
    public class JsonErroResponse
    {
        public string[] Mensagens { get; set; }

        public object OutraMensagem { get; set; }
    }

}

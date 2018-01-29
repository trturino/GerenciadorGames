using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure
{
    public static class API
    {
        public static class Amigo
        {
            public static string GetAmigo(string baseUri) => baseUri;
            public static string GetAmigoById(string baseUri, int id) => $"{baseUri}/{id}";
            public static string PostAmigo(string baseUri) => baseUri;
            public static string PutAmigo(string baseUri) => baseUri;
        }

        public static class Emprestimo
        {
            public static string GetEmprestimo(string baseUri) => baseUri;
            public static string GetEmprestimoByAmigoId(string baseUri, int id) => $"{baseUri}/amigo/{id}";
            public static string GetEmprestimoByGameId(string baseUri, int id) => $"{baseUri}/game/{id}";
            public static string GetEmprestimoById(string baseUri, int id) => $"{baseUri}/{id}";
            public static string PostEmprestimo(string baseUri) => baseUri;
            public static string PutEmprestimo(string baseUri) => baseUri;
        }

        public static class Game
        {
            public static string GetGame(string baseUri) => baseUri;
            public static string GetDisponiveis(string baseUri) => $"{baseUri}/disponiveis";
            public static string GetGameById(string baseUri, int id) => $"{baseUri}/{id}";
            public static string PostGame(string baseUri) => baseUri;
            public static string PutGame(string baseUri) => baseUri;
        }
    }
}

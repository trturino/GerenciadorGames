using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace trturino.GerenciadorGames.Services.Identity.API.Configuracoes
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("amigos", "amigos Service"),
                new ApiResource("emprestimos", "emprestimos Service"),
                new ApiResource("games", "games Service"),
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "amigos",
                        "emprestimos",
                        "games"
                    },
                },
                new Client
                {
                    ClientId = "amigoswaggerui",
                    ClientName = "Amigos Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["AmigosApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["AmigosApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "amigos"
                    }
                },
                new Client
                {
                    ClientId = "gamegswaggerui",
                    ClientName = "Game Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["GamesApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["GamesApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "games"
                    }
                },
                new Client
                {
                    ClientId = "emprestimoswaggerui",
                    ClientName = "Empresitmo Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["EmprestimoApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["EmprestimoApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "emprestimos"
                    }
                }
            };
        }
    }
}

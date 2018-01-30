using Microsoft.AspNetCore.Http;
using Polly;
using System;
using System.Net.Http;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure
{
    public class AppHttpClientFactory : IAppHttpClientFactory
    {
        private readonly int _retryCount;
        private readonly int _exceptionsAllowedBeforeBreaking;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppHttpClientFactory(IHttpContextAccessor httpContextAccessor, int exceptionsAllowedBeforeBreaking = 5, int retryCount = 6)
        {
            _exceptionsAllowedBeforeBreaking = exceptionsAllowedBeforeBreaking;
            _retryCount = retryCount;
            _httpContextAccessor = httpContextAccessor;
        }

        public AppHttpClient CreateHttpClient()
            => new AppHttpClient((origin) => CreatePolicies(), _httpContextAccessor);

        private Policy[] CreatePolicies()
            => new Policy[]
            {
                Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(
                    _retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        var msg = $"Retry {retryCount} implemented with Polly's RetryPolicy " +
                            $"of {context.PolicyKey} " +
                            $"at {context.ExecutionKey}, " +
                            $"due to: {exception}.";
                    }),
                Policy.Handle<HttpRequestException>()
                .CircuitBreakerAsync(
                   _exceptionsAllowedBeforeBreaking,
                   TimeSpan.FromMinutes(1),
                   (exception, duration) =>
                   {
                   },
                   () =>
                   {
                   })
            };
    }
}
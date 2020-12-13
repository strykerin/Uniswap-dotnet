using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Uniswap.dotnet.Extensions
{
    public static class UniswapExtension
    {
        public static void AddUniswap(this IServiceCollection services)
        {
            services.AddSingleton<IGraphQLClient>(ctx =>
            {
                var graphQLOptions = new GraphQLHttpClientOptions
                {
                    EndPoint = new Uri("https://api.thegraph.com/subgraphs/name/uniswap/uniswap-v2")
                };
                return new GraphQLHttpClient(graphQLOptions, new SystemTextJsonSerializer());
            });

            services.AddSingleton<IUniswap>(ctx => 
            {
                IGraphQLClient graphQLClient = ctx.GetRequiredService<IGraphQLClient>();
                return new Uniswap(graphQLClient);
            });
        }
    }
}

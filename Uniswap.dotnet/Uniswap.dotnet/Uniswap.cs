using System.Threading.Tasks;
using System;
using GraphQL;
using Uniswap.dotnet.Entities;
using GraphQL.Client.Abstractions;

namespace Uniswap.dotnet
{
    public class Uniswap : IUniswap
    {
        private readonly IGraphQLClient _graphQLClient;

        public Uniswap(IGraphQLClient graphQLHttpClient)
        {
            _graphQLClient = graphQLHttpClient ?? throw new ArgumentNullException(nameof(graphQLHttpClient));
        }

        public async Task<Pools> GetMostLiquidMarketPairs()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    {
                      pairs {
                        token0 {
                          symbol
                        }
                        token1 {
                          symbol
                        }
                        reserveETH
                        reserveUSD
                      }
                    }
                "
            };

            var response = await _graphQLClient.SendQueryAsync<Pools>(query);
            return response.Data;
        }
    }
}

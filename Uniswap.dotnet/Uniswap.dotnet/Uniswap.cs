using System.Collections.Generic;
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

        /// <summary>
        /// Get the first 150 most liquid market pairs ordered by desc
        /// </summary>
        /// <returns></returns>
        public async Task<Pools> GetMostLiquidMarketPairs()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                {
                    pairs(first: 150, orderBy: reserveETH orderDirection: desc){
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

            GraphQLResponse<Pools> response = await _graphQLClient.SendQueryAsync<Pools>(query);
            return response.Data;
        }

        public async Task<TopTokens> GetTopTokens()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                {
                  tokens (first: 150, orderBy: tradeVolumeUSD orderDirection: desc){
                    symbol
                    name
                    tradeVolume
                    tradeVolumeUSD
                    totalSupply
                    totalLiquidity
                  }
                }
                "
            };

            GraphQLResponse<TopTokens> response = await _graphQLClient.SendQueryAsync<TopTokens>(query);
            return response.Data;
        }
    }
}

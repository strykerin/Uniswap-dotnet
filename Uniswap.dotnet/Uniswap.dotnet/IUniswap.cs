using System.Threading.Tasks;
using Uniswap.dotnet.Entities;

namespace Uniswap.dotnet
{
    public interface IUniswap
    {
        Task<Pools> GetMostLiquidMarketPairs();
        Task<TopTokens> GetTopTokens();
    }
}

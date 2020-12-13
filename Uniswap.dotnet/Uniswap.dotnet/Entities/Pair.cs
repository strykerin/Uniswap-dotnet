namespace Uniswap.dotnet.Entities
{
    public class Pair
    {
        public string ReserveETH { get; set; }
        public string ReserveUSD { get; set; }
        public Token Token0 { get; set; }
        public Token Token1 { get; set; }
    }
}

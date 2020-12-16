# Uniswap dotnet
[![NuGet version (DeFiPulse)](https://img.shields.io/nuget/v/Uniswap.dotnet.svg)](https://www.nuget.org/packages/Uniswap.dotnet/) ![Nuget downloads](https://img.shields.io/nuget/dt/Uniswap.dotnet.svg)

A dotnet standard wrapper for the Uniswap V2 Subgraph on The Graph GraphQL API.

## Installation
Available on [Nuget](https://www.nuget.org/packages/Uniswap.dotnet).

``` PowerShell
Install-Package Uniswap.dotnet -Version 1.0.0
```

## Register service in your DI container
In order to use this package, simply add in the `ConfigureServices` method in your `Startup.cs` class:

```csharp
services.AddUniswap();
```

## Usage
To have access to the Uniswap service, simply get it by constructor injection:

```csharp
private readonly IUniswap _uniswap;

public WeatherForecastController(IUniswap uniswap)
{
    _uniswap = uniswap;
}
```

## Example - Get Most Liquid Market Pairs
The following example shows how to get the most liquid market pairs:

```csharp
Pools pools = await _uniswap.GetMostLiquidMarketPairs();
```

We get the following JSON response:
```json
{
  "pairs": [
    {
      "reserveETH": "0.000000000000000282",
      "reserveUSD": "0.00000000000009764515173366604499968328796917891",
      "token0": {
        "symbol": "HORE"
      },
      "token1": {
        "symbol": "WETH"
      }
    },
    {
      "reserveETH": "0.000367774762347336",
      "reserveUSD": "0.1469467966437433309224845826987036",
      "token0": {
        "symbol": "DATCx"
      },
      "token1": {
        "symbol": "WETH"
      }
    }
    ...
}
``` 

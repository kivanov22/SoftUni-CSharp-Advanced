using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        coins = coins.OrderByDescending(c => c).ToList();
        int currentSum = 0;
        Dictionary<int, int> wallet = new Dictionary<int, int>();
        for (int i = 0; i < coins.Count; i++)
        {
            int currCoin = coins[i];

            if (currentSum + currCoin > targetSum)
            {
                continue;
            }
            
            int coinsToTake = (targetSum - currentSum) / currCoin;

            currentSum += currCoin * coinsToTake;

            wallet.Add(currCoin, coinsToTake);

            //wallet[currCoin]++;
            if (currentSum == targetSum)
            {
                break;
            }
        }
        if (currentSum != targetSum)
        {
            throw new InvalidOperationException("Error");
        }
        return wallet;
    }
}
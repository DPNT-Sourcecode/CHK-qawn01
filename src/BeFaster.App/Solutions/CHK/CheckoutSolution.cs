using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            try
            {
                int totalBeforeDiscount = 0;
                var skuPrices = new Dictionary<char, int>
                {
                    { 'A', 50 },
                    { 'B', 30 },
                    { 'C', 20 },
                    { 'D', 15 },
                    { 'E', 40 },
                    { 'F', 10 },
                };
                var skuCounts = new Dictionary<char, int>();
                foreach (char sku in skuPrices.Keys)
                {
                    skuCounts[sku] = 0;
                }

                foreach (char sku in skus)
                {
                    totalBeforeDiscount += GetPrice(sku, skuPrices);
                    skuCounts[sku]++;
                }
                int aLargeDiscounts = skuCounts['A'] / 5;
                int aSmallDiscounts = (skuCounts['A'] % 5) / 3;
                int bFreeCount = Math.Min(skuCounts['E'] / 2, skuCounts['B']);
                int bDiscounts = (skuCounts['B'] - bFreeCount) / 2;
                int fFreeCount = (skuCounts['F'] / 3);

                int aDiscount = 50 * aLargeDiscounts + 20 * aSmallDiscounts;
                int bDiscount = 30 * bFreeCount + 15 * bDiscounts;
                int fDiscount = 10 * fFreeCount;
                return totalBeforeDiscount - aDiscount - bDiscount - fDiscount;
            }
            catch (InvalidSkuException)
            {
                return -1;
            }
        }

        private static int GetPrice(char sku, Dictionary<char, int> skuPrices)
        {
            int price;
            if(skuPrices.TryGetValue(sku, out price))
            {
                return price;
            }
            else
            {
                throw new InvalidSkuException(sku);
            }
        }
    }
}




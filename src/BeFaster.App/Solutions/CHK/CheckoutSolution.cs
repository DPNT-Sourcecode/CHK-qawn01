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
                var skuPrices = new Dictionary<char, int>
                {
                    { 'A', 50 },
                    { 'B', 30 },
                    { 'C', 20 },
                    { 'D', 15 },
                    { 'E', 40 },
                    { 'F', 10 },
                };
                var discountConfigs = new List<DiscountConfig>
                {
                    new DiscountConfig(50, new DiscountQualifyingSku('A', 5)),
                    new DiscountConfig(20, new DiscountQualifyingSku('A', 3)),
                    new DiscountConfig(30, new DiscountQualifyingSku('E', 2), new DiscountQualifyingSku('B', 1)),
                    new DiscountConfig(15, new DiscountQualifyingSku('B', 2)),
                    new DiscountConfig(10, new DiscountQualifyingSku('F', 3)),
                };

                var skuCounts = new Dictionary<char, int>();
                foreach (char sku in skuPrices.Keys)
                {
                    skuCounts[sku] = 0;
                }

                int total = 0;
                foreach (char sku in skus)
                {
                    total += GetPrice(sku, skuPrices);
                    skuCounts[sku]++;
                }

                foreach(DiscountConfig discount in discountConfigs)
                {
                    total -= discount.CalculateDiscount(skuCounts);
                }
                return total;
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


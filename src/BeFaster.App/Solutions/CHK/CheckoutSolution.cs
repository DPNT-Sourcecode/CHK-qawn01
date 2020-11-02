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
                    { 'G', 20 },
                    { 'H', 10 },
                    { 'I', 35 },
                    { 'J', 60 },
                    { 'K', 80 },
                    { 'L', 90 },
                    { 'M', 15 },
                    { 'N', 40 },
                    { 'O', 10 },
                    { 'P', 50 },
                    { 'Q', 30 },
                    { 'R', 50 },
                    { 'S', 30 },
                    { 'T', 20 },
                    { 'U', 40 },
                    { 'V', 50 },
                    { 'W', 20 },
                    { 'X', 90 },
                    { 'Y', 10 },
                    { 'Z', 50 },
                };
                var discountConfigs = new List<DiscountConfig>
                {
                    new DiscountConfig(50, new DiscountQualifyingSku('A', 5)),
                    new DiscountConfig(20, new DiscountQualifyingSku('A', 3)),
                    new DiscountConfig(30, new DiscountQualifyingSku('E', 2), new DiscountQualifyingSku('B', 1)),
                    new DiscountConfig(15, new DiscountQualifyingSku('B', 2)),
                    new DiscountConfig(10, new DiscountQualifyingSku('F', 3)),
                    new DiscountConfig(20, new DiscountQualifyingSku('H', 10)),
                    new DiscountConfig(5, new DiscountQualifyingSku('H', 5)),
                    new DiscountConfig(10, new DiscountQualifyingSku('K', 2)),
                    new DiscountConfig(15, new DiscountQualifyingSku('N', 3), new DiscountQualifyingSku('M', 1)),
                    new DiscountConfig(50, new DiscountQualifyingSku('P', 5)),
                    new DiscountConfig(30, new DiscountQualifyingSku('R', 3), new DiscountQualifyingSku('Q', 1)),
                    new DiscountConfig(10, new DiscountQualifyingSku('Q', 3)),
                    new DiscountConfig(40, new DiscountQualifyingSku('U', 4)),
                    new DiscountConfig(20, new DiscountQualifyingSku('V', 3)),
                    new DiscountConfig(10, new DiscountQualifyingSku('V', 2)),
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


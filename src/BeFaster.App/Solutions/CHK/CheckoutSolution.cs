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
                    { 'K', 70 },
                    { 'L', 90 },
                    { 'M', 15 },
                    { 'N', 40 },
                    { 'O', 10 },
                    { 'P', 50 },
                    { 'Q', 30 },
                    { 'R', 50 },
                    { 'S', 20 },
                    { 'T', 20 },
                    { 'U', 40 },
                    { 'V', 50 },
                    { 'W', 20 },
                    { 'X', 17 },
                    { 'Y', 20 },
                    { 'Z', 21 },
                };
                var discountConfigs = new List<DiscountConfig>
                {
                    new DiscountConfig(200, new DiscountQualifyingSku('A', 5)),
                    new DiscountConfig(130, new DiscountQualifyingSku('A', 3)),
                    new DiscountConfig(80, new DiscountQualifyingSku('E', 2), new DiscountQualifyingSku('B', 1)),
                    new DiscountConfig(45, new DiscountQualifyingSku('B', 2)),
                    new DiscountConfig(20, new DiscountQualifyingSku('F', 3)),
                    new DiscountConfig(80, new DiscountQualifyingSku('H', 10)),
                    new DiscountConfig(45, new DiscountQualifyingSku('H', 5)),
                    new DiscountConfig(120, new DiscountQualifyingSku('K', 2)),
                    new DiscountConfig(120, new DiscountQualifyingSku('N', 3), new DiscountQualifyingSku('M', 1)),
                    new DiscountConfig(200, new DiscountQualifyingSku('P', 5)),
                    new DiscountConfig(150, new DiscountQualifyingSku('R', 3), new DiscountQualifyingSku('Q', 1)),
                    new DiscountConfig(80, new DiscountQualifyingSku('Q', 3)),
                    new DiscountConfig(120, new DiscountQualifyingSku('U', 4)),
                    new DiscountConfig(130, new DiscountQualifyingSku('V', 3)),
                    new DiscountConfig(90, new DiscountQualifyingSku('V', 2)),
                    new DiscountConfig(45, new DiscountQualifyingSku("ZYSTX", 2))
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
                    total -= discount.CalculateDiscount(skuCounts, skuPrices);
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    internal class DiscountConfig
    {
        internal DiscountConfig(int fixedPrice, params DiscountQualifyingSku[] qualifyingSkus)
        {
            FixedPrice = fixedPrice;
            QualifyingSkus = qualifyingSkus;
        }

        internal DiscountQualifyingSku[] QualifyingSkus { get; }
        internal int FixedPrice { get;  }

        internal int CalculateDiscount(Dictionary<char, int> skuCounts, Dictionary<char, int> fullPrices)
        {
            int discountCount = QualifyingSkus.Min(qs => qs.CalculateQualifyingQuota(skuCounts));
            int totalOriginalPrice = 0;
            foreach(DiscountQualifyingSku qs in QualifyingSkus)
            {
                totalOriginalPrice += qs.RemoveFromBasket_ReturnOriginalPrice(skuCounts, discountCount * qs.QualifyingCount, fullPrices);
            }
            return totalOriginalPrice - FixedPrice * discountCount;
        }
    }

    internal class DiscountQualifyingSku
    {
        internal DiscountQualifyingSku(char sku, int qualifyingCount)
        {
            Skus = sku.ToString();
            QualifyingCount = qualifyingCount;
        }
        internal DiscountQualifyingSku(string skus, int qualifyingCount)
        {
            Skus = skus;
            QualifyingCount = qualifyingCount;
        }

        internal string Skus { get; }
        internal int QualifyingCount { get; }

        internal int CalculateQualifyingQuota(Dictionary<char, int> skuCounts)
        {
            int qualifyingItemCount = Skus.Sum(sku => skuCounts[sku]);
            return qualifyingItemCount / QualifyingCount;
        }

        internal int RemoveFromBasket_ReturnOriginalPrice(Dictionary<char, int> skuCounts, int totalToRemove, Dictionary<char, int> fullPrices)
        {
            int totalOriginalPrice = 0;
            foreach(char sku in Skus)
            {
                if(skuCounts[sku] > 0)
                {
                    int countToRemove = Math.Min(skuCounts[sku], totalToRemove);
                    skuCounts[sku] -= countToRemove;
                    totalToRemove -= countToRemove;
                    totalOriginalPrice += fullPrices[sku] * countToRemove;
                    if(countToRemove == 0)
                    {
                        break;
                    }
                }
            }
            return totalOriginalPrice;
        }
    }
}
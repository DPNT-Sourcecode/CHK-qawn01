using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    internal class DiscountConfig
    {
        internal DiscountConfig(int discount, params DiscountQualifyingSku[] qualifyingSkus)
        {
            Discount = discount;
            QualifyingSkus = qualifyingSkus;
        }

        internal DiscountQualifyingSku[] QualifyingSkus { get; }
        internal int Discount { get;  }

        internal int CalculateDiscount(Dictionary<char, int> skuCounts)
        {
            int discountCount = QualifyingSkus.Min(qs => skuCounts[qs.Sku] / qs.QualifyingCount);
            foreach(DiscountQualifyingSku qs in QualifyingSkus)
            {
                skuCounts[qs.Sku] -= qs.QualifyingCount * discountCount;
            }
            return Discount * discountCount;
        }
    }

    internal class DiscountQualifyingSku
    {
        internal DiscountQualifyingSku(char sku, int qualifyingCount)
        {
            Sku = sku;
            QualifyingCount = qualifyingCount;
        }

        internal char Sku { get; }
        internal int QualifyingCount { get; }
    }
}
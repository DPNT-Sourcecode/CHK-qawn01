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
            return Discount * QualifyingSkus.Min(qs => skuCounts[qs.Sku] / qs.QualifyingCount);
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
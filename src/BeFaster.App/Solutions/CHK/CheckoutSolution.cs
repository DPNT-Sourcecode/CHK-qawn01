using BeFaster.Runner.Exceptions;
using System;
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
                int aCount = 0;
                int bCount = 0;
                int eCount = 0;
                int fCount = 0;
                foreach (char sku in skus)
                {
                    totalBeforeDiscount += GetPrice(sku);
                    if (sku == 'A') { aCount++; }
                    if (sku == 'B') { bCount++; }
                    if (sku == 'E') { eCount++; }
                    if (sku == 'F') { fCount++; }
                }
                int aLargeDiscounts = aCount / 5;
                int aSmallDiscounts = (aCount % 5) / 3;
                int bFreeCount = Math.Min(eCount / 2, bCount);
                int bDiscounts = (bCount - bFreeCount) / 2;
                int fFreeCount = (fCount / 3);

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

        private static int GetPrice(char sku)
        {
            switch (sku)
            {
                case 'A': return 50;
                case 'B': return 30;
                case 'C': return 20;
                case 'D': return 15;
                case 'E': return 40;
                case 'F': return 10;
                default: throw new InvalidSkuException(sku);
            }
        }
    }
}




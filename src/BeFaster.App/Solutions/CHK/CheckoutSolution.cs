using BeFaster.Runner.Exceptions;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            int totalBeforeDiscount = 0;
            int aCount = 0;
            int bCount = 0;
            foreach(char sku in skus)
            {
                totalBeforeDiscount += GetPrice(sku);
                if (sku == 'A') { aCount++; }
                if (sku == 'B') { bCount++; }
            }
            int aDiscount = 20 * (aCount / 3);
            int bDiscount = 15 * (bCount / 2);
            return totalBeforeDiscount - aDiscount - bDiscount;
        }

        private static int GetPrice(char sku)
        {
            switch (sku)
            {
                case 'A': return 50;
                case 'B': return 30;
                case 'C': return 20;
                case 'D': return 15;
                default: return 0;
            }
        }
    }
}





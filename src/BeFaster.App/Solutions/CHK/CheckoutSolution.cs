using BeFaster.Runner.Exceptions;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            return skus.Sum(c => GetPrice(c))
                - ((skus.Count(c => c == 'A')) / 3) * 20
                - ((skus.Count(c => c == 'B')) / 2) * 15;
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




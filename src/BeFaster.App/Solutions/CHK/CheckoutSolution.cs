using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            return GetPrice(skus[0]);
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


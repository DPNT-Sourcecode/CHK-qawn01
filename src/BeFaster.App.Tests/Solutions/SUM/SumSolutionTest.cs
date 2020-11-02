using BeFaster.App.Solutions.SUM;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class SumSolutionTest
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 6, ExpectedResult = 6)]
        [TestCase(6, 0, ExpectedResult = 6)]
        [TestCase(17, -23, ExpectedResult = -6)]
        public int ComputeSum(int x, int y)
        {
            return SumSolution.Sum(x, y);
        }
    }
}


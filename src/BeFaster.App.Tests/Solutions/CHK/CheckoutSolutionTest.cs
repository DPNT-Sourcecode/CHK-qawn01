using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [TestCase("", 0)]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void TestCheckout(string skus, int expectedTotal)
        {
            int actualTotal = CheckoutSolution.ComputePrice(skus);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal), skus);
        }
    }
}


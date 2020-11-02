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
        [TestCase("AA", 100)]
        [TestCase("BB", 45)]
        [TestCase("CC", 40)]
        [TestCase("DD", 30)]
        [TestCase("AB", 80)]
        [TestCase("BC", 50)]
        [TestCase("CD", 35)]
        [TestCase("AC", 70)]
        [TestCase("BD", 45)]
        [TestCase("AD", 65)]
        [TestCase("ABCD", 115)]
        [TestCase("ABCB", 115)]
        [TestCase("AAA", 130)]
        [TestCase("AAABB", 175)]
        [TestCase("AAAA", 180)]
        [TestCase("BBB", 75)]
        [TestCase("BBBB", 90)]
        [TestCase("x", -1)]
        [TestCase("ABCaBC", -1)]
        [TestCase("E", 40)]
        [TestCase("EE", 80)]
        [TestCase("EEE", 120)]
        [TestCase("EEEE", 160)]
        [TestCase("EB", 70)]
        [TestCase("EEB", 80)]
        [TestCase("EEEBBB", 165)]
        [TestCase("EEEEBBB", 190)]
        [TestCase("AAAAA", 200)]
        [TestCase("AAAAAA", 250)]
        [TestCase("F", 10)]
        [TestCase("FF", 20)]
        [TestCase("FFF", 20)]
        [TestCase("FFFF", 30)]
        [TestCase("FFFFF", 40)]
        [TestCase("FFFFFF", 40)]
        [TestCase("G", 20)]
        [TestCase("H", 10)]
        [TestCase("I", 35)]
        [TestCase("J", 60)]
        [TestCase("K", 80)]
        [TestCase("L", 90)]
        [TestCase("M", 15)]
        [TestCase("N", 40)]
        [TestCase("O", 10)]
        [TestCase("P", 50)]
        [TestCase("Q", 30)]
        [TestCase("R", 50)]
        [TestCase("S", 30)]
        [TestCase("T", 20)]
        [TestCase("U", 40)]
        [TestCase("V", 50)]
        [TestCase("W", 20)]
        [TestCase("X", 90)]
        [TestCase("Y", 10)]
        [TestCase("Z", 50)] 
        [TestCase("HHHHH", 45)]
        [TestCase("HHHHHHHHHH", 80)]
        [TestCase("KK", 150)]
        [TestCase("NNNM", 120)]
        [TestCase("PPPPP", 200)]
        [TestCase("QQQ", 80)]
        [TestCase("RRRQ", 150)]
        [TestCase("RRRQQQ", 210)]
        [TestCase("RRRQQQQ", 230)]
        [TestCase("UUU", 120)]
        [TestCase("UUUU", 120)]
        [TestCase("VV", 90)]
        [TestCase("VVV", 130)]
        [TestCase("VVVV", 180)]
        public void TestCheckout(string skus, int expectedTotal)
        {
            int actualTotal = CheckoutSolution.ComputePrice(skus);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal), skus);
        }
    }
}



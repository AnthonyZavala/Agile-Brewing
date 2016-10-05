using System;
using Core;
using NUnit.Framework;

namespace Core.UnitTests
{
    [TestFixture]
    public class ConversionEquations
    {
        [TestCase(10, 1.040)]
        [TestCase(20, 1.083)]
        [TestCase(30, 1.129)]
        [TestCase(15.67, 1.064)]
        public void ConvertBrixToSg(decimal brix, decimal expectedSG)
        {
            decimal actualSG = Core.ConversionEquations.BrixToSg(brix);

            Assert.AreEqual(expectedSG, actualSG);
        }

        [TestCase(1.040, 10)]
        [TestCase(1.083, 20)]
        [TestCase(1.129, 30)]
        [TestCase(1.064, 15.7)]
        public void ConvertSgToBrix(decimal sg, decimal expectedBrix)
        {
            decimal actualBrix = Core.ConversionEquations.SgToBrix(sg);

            Assert.AreEqual(expectedBrix, actualBrix);
        }

        [TestCase(1.040, 1.007, 4.3)]
        [TestCase(1.083, 1.020, 8.9)]
        [TestCase(1.129, 1.051, 12.2)]
        public void CalculateSpecificGravityAbv(decimal og, decimal fg, decimal expectedAbv)
        {
            decimal actualAbv = Core.ConversionEquations.SpecificGravityAbv(og, fg);

            Assert.AreEqual(expectedAbv, actualAbv);
        }

        [TestCase(14, 7, 6.2)]
        [TestCase(15, 8, 6.5)]
        [TestCase(20, 9, 10.7)]
        public void CalculateBrixAbv(decimal orginialBrix, decimal finalBrix, decimal expectedABV)
        {
            decimal actualABV = Core.ConversionEquations.BrixAbv(orginialBrix, finalBrix);

            Assert.AreEqual(expectedABV, actualABV);
        }
    }
}

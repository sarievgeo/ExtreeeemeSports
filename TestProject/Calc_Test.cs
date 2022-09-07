using CalculatorEX.App;
using HomeWork.App;

namespace TestProject
{
    [TestClass]
    public class Calc_Test
    {
        [TestMethod]
        public void CalcTest()
        {
            var calc = new Calc();

            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.Parse("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("LV"), 55);
            Assert.AreEqual(RomanNumber.Parse("XL"), 40);
        }
        
        [TestMethod]
        public void RomanNumberParseN()
        {
            Assert.AreEqual("N among us", 
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XN")).Message
            );
            Assert.AreEqual("N among us", 
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XNX")).Message
            );
            Assert.AreEqual("N among us", 
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("NVII")).Message
            );
            Assert.AreEqual("N among us", 
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("NN")).Message
            );
        }
    }
}
using CalculatorEX.App;
using HomeWork.App;

namespace HomeWork_Tests
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
        public void ConstructNewObject()
        {
            var obj = new HomeWork.App.Calc();
            Assert.IsNotNull(obj);
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
        public void RomanNumberNegativeDigitCrosTest()
        {
            Assert.AreEqual(-1, RomanNumber.Parse("-I"), "-I == -1");
            Assert.AreEqual(-4, RomanNumber.Parse("-IV"), "-IV == -4");
            Assert.AreEqual(-15, RomanNumber.Parse("-XV"), "-XV == -15");
            Assert.AreEqual(-30, RomanNumber.Parse("-XXX"), "-XXX == -30");
            Assert.AreEqual(-900, RomanNumber.Parse("-CM"), "-CM == -900");
            Assert.AreEqual(-1999, RomanNumber.Parse("-MCMXCIX"), "-MCMXCIX == -1999");
            Assert.AreEqual(-400, RomanNumber.Parse("-CD"), "-CD == -400");
            Assert.AreEqual(-401, RomanNumber.Parse("-CDI"), "-CDI == -401");
            Assert.AreEqual(-55, RomanNumber.Parse("-LV"), "-LV == -55");
            Assert.AreEqual(-40, RomanNumber.Parse("-XL"), "-XL == -40");

            RomanNumber romanNumber = new(-1);
            Assert.AreEqual("-I", romanNumber.ToString());
        }

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            Assert.AreEqual(30, RomanNumber.Parse("XXX"));
            Assert.AreEqual(401, RomanNumber.Parse("CDI"));
            Assert.AreEqual(1999, RomanNumber.Parse("MCMXCIX"));
        }

        [TestMethod]
        public void RomeWhiske()
        {
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); });
            var exp = new ArgumentException("Invalid char A");
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); });
            var exp_1 = new ArgumentException("Invalid space");
            Assert.AreEqual(exp.Message, exc.Message);

        }

        [TestMethod]
        public void ParseEmptyString()
        {
            //Assert.ThrowsException<Exception>(() => RomanNumber.Parse(""));
            //Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
            Assert.AreEqual("Empty string not allowed",
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(string.Empty)).Message);
        }

        [TestMethod]
        public void ParseNullInputString()
        {
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }

        [TestMethod]
        public void ParseInvalidDigit()
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("N"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XP"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XVIIQ"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XVIPI"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("PCD"));
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

using CalculatorEX.App;
using HomeWork.App;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

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
        public void ToStringNegative()
        {
            RomanNumber rn = new() { Value = -10 };
            Assert.AreEqual("-X", rn.ToString());
            rn.Value = -90;
            Assert.AreEqual("-XC", rn.ToString());
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

        [TestMethod]
        public void AddRomanNumber()
        {
            RomanNumber rn2 = new(2);
            RomanNumber rn5 = new(5);
            RomanNumber rn7 = new(7);
            RomanNumber rn10 = new() { Value = 10 };
            RomanNumber rn_5 = new() { Value = -5 };
            RomanNumber rn_7 = new() { Value = -7 };

            Assert.AreEqual(9, rn2.Add(rn7).Value);
            Assert.AreEqual(20, rn10.Add(rn10).Value);
            Assert.AreEqual(5, rn10.Add(rn_5).Value);
            Assert.AreEqual(3, rn10.Add(rn_7).Value);
            Assert.AreEqual(10, rn5.Add(rn5).Value);
            Assert.AreEqual(7, rn7.Add(new RomanNumber(0)).Value);
            Assert.AreEqual(5, rn5.Add(new RomanNumber()).Value);
            Assert.AreEqual(25, rn5.Add(new RomanNumber(20)).Value);
            Assert.AreEqual(6, rn5.Add(new RomanNumber(1)).Value);
            Assert.AreEqual(19, rn10.Add(new RomanNumber(9)).Value);
            Assert.AreEqual(-5, rn5.Add(new RomanNumber(-10)).Value);
            Assert.AreEqual(rn7, rn2.Add(rn5));
            Assert.AreEqual(rn_5, rn_7.Add(rn2));
            Assert.AreEqual("XVII", rn7.Add(rn10).ToString());
            Assert.AreEqual("III", rn_7.Add(rn10).ToString());
            Assert.AreEqual("-V", rn_7.Add(rn2).ToString());
            Assert.AreEqual("-XII", rn_7.Add(rn_5).ToString());
        }

        [TestMethod]
        public void AddRomanInteger()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(20, rn.Add(10).Value);
            Assert.AreEqual("V", rn.Add(-5).ToString());
            Assert.AreEqual(rn, rn.Add(0));
        }

        [TestMethod]
        public void AddRomanString()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(30, rn.Add("XX").Value);
            Assert.AreEqual("-XL", rn.Add("-L").ToString());
            Assert.AreEqual(rn, rn.Add("N"));

            Assert.ThrowsException<ArgumentException>(() => rn.Add(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("-"));
        }

        [TestMethod]
        public void AddRomanStatic()
        {
            var rn5 = RomanNumber.Add(2, 3);
            var rn8 = RomanNumber.Add(rn5, 3);
            var rn10 = RomanNumber.Add("I", "IX");
            var rn9 = RomanNumber.Add(rn5, "IV");
            var rn13 = RomanNumber.Add(rn5, rn8);

            Assert.AreEqual(5, rn5.Value);
            Assert.AreEqual(8, rn8.Value);
            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(9, rn9.Value);
            Assert.AreEqual(13, rn13.Value);

            Assert.AreEqual(20, RomanNumber.Add(rn5, "V", 5, "5").Value);
            Assert.AreEqual(0, RomanNumber.Add("0").Value);
            Assert.AreEqual(0, RomanNumber.Add().Value);

            Assert.AreEqual(0, RomanNumber.Add(0, "N").Value);
            Assert.AreEqual(1, RomanNumber.Add(rn5, "-IV").Value);

            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("G"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add(9.74));
        }

        [TestMethod]
        public void Sub()
        {
            var rn3 = new RomanNumber(3);
            var rn10 = new RomanNumber(10);
            var rn15 = new RomanNumber(15);
            var rn_7 = new RomanNumber(-7);
            var rn_9 = new RomanNumber(-9);

            Assert.AreEqual(-7, rn3.Sub(rn10).Value);
            Assert.AreEqual(5, rn15.Sub(rn10).Value);
            Assert.AreEqual(22, rn15.Sub(rn_7).Value);
            Assert.AreEqual(2, rn_7.Sub(rn_9).Value);

            Assert.AreEqual(10, rn_7.Sub("-XVII").Value);
            Assert.AreEqual(-7, rn3.Sub("X").Value);
            Assert.AreEqual(5, rn10.Sub("V").Value);

            Assert.AreEqual(22, rn15.Sub(-7).Value);
            Assert.AreEqual(-17, rn3.Sub(20).Value);
            Assert.AreEqual(8, rn15.Sub(7).Value);
        }

        [TestMethod]
        public void SubStatic()
        {
            var rn10 = RomanNumber.Sub(32, 22);
            var rn12 = RomanNumber.Sub("XX", 8);
            var rn18 = RomanNumber.Sub(30, rn12);
            var rn15 = RomanNumber.Sub(rn10, "-V");
            var rn_10 = RomanNumber.Sub("V", rn15);
            var rn_13 = RomanNumber.Sub(rn_10, 3);

            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(12, rn12.Value);
            Assert.AreEqual(18, rn18.Value);
            Assert.AreEqual(15, rn15.Value);
            Assert.AreEqual(-10, rn_10.Value);
            Assert.AreEqual(-13, rn_13.Value);
        }

    }
}

using NUnit.Framework;

namespace TestProjectCommon
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void MyFirstTest()
        {
            var a = 26;
            var b = 19;
            Assert.AreEqual(45, a+b);
        }

        [Test]
        [TestCase(1,5,6)]
        [TestCase(5, 5, 12)]
        [TestCase(17, 6, 23)]
        [TestCase(11, 8, 19)]
        [TestCase(0, 4, 4)]
        [TestCase(null, 5, 5)]
        public void DziwnyTest(int? a = 1, int b = 5, int result = 6)
        {
            Assert.AreEqual(result, (a ?? 0) + b);
        }




    }
}
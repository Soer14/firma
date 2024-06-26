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
        [TestCase(5, 5, 19)]
        [TestCase(17, 9, 19)]
        [TestCase(11, 8, 24)]
        [TestCase(0, 4, 53)]
        [TestCase(null, 8, 7)]
        public void DziwnyTest(int? a = 1, int b = 5, int result = 6)
        {
            Assert.AreEqual(result, (a ?? 0) + b);
        }

        


    }
}
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




    }
}
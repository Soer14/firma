using NBPClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class NPBTest
    {
        [Test]
        public void DupaTest()
        {
            var rates = NBPClient.NBPClient.GetRates();
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }
        [Test]
        public void DupaTest100()
        {
            var rates = NBPClient.NBPClient.GetRates(100);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }

        [Test]
        public void DupaTestEuro()
        {
            var rates = NBPClient.NBPClient.GetRates("EUR",50);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }
        [Test]
        public void DupaTestEuroC()
        {
            var rates = NBPClient.NBPClient.GetRates("C","EUR", 50);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }
        [Test]
        public void DupaTestEuroB()
        {
            var rates = NBPClient.NBPClient.GetRates("B", "EUR", 50);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }
        [Test]
        public void DupaTestAFNB()
        {
            var rates = NBPClient.NBPClient.GetRates("B", "AFN", 50);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
        }
    }

}

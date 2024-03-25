using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUS_lib;
using GUS_lib.Models;
using NUnit.Framework;

namespace TestProjectCommon
{
    internal class GusTest
    {
        [Test]
        public void GusTest1()
        {
            //Klient środowiska produkcyjnego
            GUS gusClient = new GUS("f3ccc9d63a3243bba830");
            //Klient środowiska SANDBOX
            GUS gusClientSanbox = new GUS("abcde12345abcde12345", true);
            gusClient.Login(true);
            Podmiot pNIP = gusClient.SzukajPodmiotNip("6971061467");
            Console.WriteLine($"{pNIP.Nazwa}{pNIP.Miejscowosc}{pNIP.KodPocztowy}{pNIP.Ulica}{pNIP.NrLokalu}{pNIP.Typ}");
            
            
            Assert.AreEqual("Dupa", pNIP.Nazwa);
        }

        [Test]
        public void GusTest2()
        {
            var gusClient = new GUS("f3ccc9d63a3243bba830");
            gusClient.Login(true);
          
                string input = "6971061467;1050001019,1070012316 5223218738, 522321873";
            char[] separators = { ';', ',', '.', ' ' };

            string[] stringArray = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var klienci = gusClient.SzukajPodmiotyNip(stringArray);
            Assert.IsTrue(klienci.Count > 0);
            foreach (var client in klienci)
            {
                Console.WriteLine($"{client.Nazwa}{client.Miejscowosc}{client.KodPocztowy}{client.Ulica}{client.NrLokalu}{client.Typ}");
            }
                
        }
}
}

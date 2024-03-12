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
        
}
}

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using GasStationApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    public class ImportDeliveryTest : BaseTestOnDB
    {
        string login = "UtaPlTest";
        string haslo = "N!Ezapominajka1";
        int numerKlienta = 6221850;
        string synchronizationId = "8b581f16-a6c1-4500-8d7e-3da2f64f37db";


        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
        }
        /// plan gry 
        /// Autoryzacja do serwisu aby otrzymać token
        /// pobrać dane z serwisu
        /// zapisać otrzymane dane do bazy
        [Test]
        public async System.Threading.Tasks.Task GettingDeliveryDataTest()
        {
            var token = await UTAHttpClient.AuthenticateAsync(login, haslo);
            var transactions = await UTAHttpClient.DostawyAsync(token, numerKlienta, synchronizationId);
           // Assert.AreEqual(113, transactions.Count);
            UTAHttpClient.SaveDeliveryToDataBase(objectSpace,transactions);
            var records = objectSpace.GetObjectsQuery<Delivery>();
           // Assert.AreEqual(339, records.Count());
        }

    }
}

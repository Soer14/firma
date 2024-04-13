using ApplicationCommon;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
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
            var token = await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);
            var transactions = await UTAHttpClient.DostawyAsync(token, CustomerSettings.numerKlienta, CustomerSettings.synchronizationId);
            // Assert.AreEqual(113, transactions.Count);
            GastStationsImporter.SaveDeliveryToDataBase(objectSpace,transactions);
            var records = objectSpace.GetObjectsQuery<Delivery>();
           // Assert.AreEqual(339, records.Count());
        }

    }
}

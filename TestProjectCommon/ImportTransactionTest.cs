using ApplicationCommon;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
using GasStationApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class ImportTransactionTest : BaseTestOnDB
    {
        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
        }

        [Test]
        public async System.Threading.Tasks.Task GettingDeliveryDataTest()
        {
            var invoiceDate = new DateTime(2024, 1, 15);
            var token = await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);
            Assert.IsNotNull(token);
            var transactions = await UTAHttpClient.GetTransactionsAsync(token, CustomerSettings.numerKlienta, CustomerSettings.synchronizationId, invoiceDate);
            
            // Assert.AreEqual(186, transactions.Count);
            GastStationsImporter.SaveTransactionsToDataBase(objectSpace, transactions);
            var records = objectSpace.GetObjectsQuery<Delivery>();
            // Assert.AreEqual(339, records.Count());
        }
    }
}

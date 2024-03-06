using Firma.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class TestyXPOMem : BaseTestMem
    {
        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
        }

        [Test]
        public void DodawanieProduktuTest()
        {
            var  product = objectSpace.CreateObject<Product>();
            Assert.IsNotNull(product);
            product.Price = 100;
            product.ProductName = "nuggets 6 sztuk";
            


            Assert.AreEqual(100, product.Price);


            var vatRate = objectSpace.CreateObject<VatRate>();
            Assert.IsNotNull(vatRate);
            vatRate.RateValue = 23;
            vatRate.Symbol = "23%";

            product.VatRate = vatRate;
            objectSpace.CommitChanges();



            var invoiceItem = objectSpace.CreateObject<InvoiceItem>();
            invoiceItem.Product = product;
            Assert.IsNotNull(invoiceItem.VatRate);
            Assert.AreEqual(100, invoiceItem.UnitPrice);



            invoiceItem.Quantity = 10;
            Assert.AreEqual(1000, invoiceItem.Gross);
        }
    }
}

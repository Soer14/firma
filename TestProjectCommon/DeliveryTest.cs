
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Firma.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    [DefaultClassOptions]
    public class DeliveryTest : BaseTestOnDB
    {
        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
            var countrys = objectSpace.GetObjectsQuery<Country>();
            Assert.AreEqual(245, countrys.Count());
        }


    }
}

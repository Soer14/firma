using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{ 
        [TestFixture]
        public class BaseTestMem
        {
            #region setup
            public IObjectSpace objectSpace;
            private XPObjectSpaceProvider directProvider;
            private string connectionString;


            [OneTimeSetUp]
            public void OneTimeSetUp() { XpoDefault.Session = null; }

            [SetUp]
            public virtual void SetUp()
            {
                connectionString = InMemoryDataStoreProvider.ConnectionString;
                directProvider = new XPObjectSpaceProvider(connectionString, null);
                objectSpace = directProvider.CreateObjectSpace();
            }

            [TearDown]
            public void TearDown()
            {
                directProvider.Dispose();
                objectSpace.Dispose();
                //  generator.Dispose();
            }
            #endregion
        }
    
}

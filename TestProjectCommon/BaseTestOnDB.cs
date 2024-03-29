using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using ApplicationCommon;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;

namespace TestProjectCommon
{
    public class BaseTestOnDB
    {
        #region setup
        internal IObjectSpace objectSpace;
        internal XPObjectSpaceProvider directProvider;
        internal string connectionString;

        [OneTimeSetUp]
        public void OneTimeSetUp() { XpoDefault.Session = null; }

        [SetUp]
        public void SetUp()
        {
            directProvider = new XPObjectSpaceProvider(ApplicationSettings.ConnectionString, null);

            using (IObjectSpace directObjectSpace = directProvider.CreateObjectSpace())
                objectSpace = directProvider.CreateObjectSpace();
            XafTypesInfo.Instance.RegisterEntity(typeof(Customer));
            XafTypesInfo.Instance.RegisterEntity(typeof(Product));
            XafTypesInfo.Instance.RegisterEntity(typeof(Country));
            XafTypesInfo.Instance.RegisterEntity(typeof(Currency));
            XafTypesInfo.Instance.RegisterEntity(typeof(GasStation));
        }

        [TearDown]
        public void TearDown()
        {
            directProvider.Dispose();
            objectSpace.Dispose();
        }
        #endregion
    }


}

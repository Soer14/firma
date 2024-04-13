using ApplicationCommon;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
using GasStationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Controllers
{
    public class DeliveryLVController : ObjectViewController<ListView,Delivery>
    {
        SimpleAction mySimpleAction;
        public DeliveryLVController() : base()
        {
            //TargetObjectType = typeof(Delivery);
            //TargetViewType = ViewType.ListView;

            // Target required Views (use the TargetXXX properties) and create their Actions.
            mySimpleAction = new SimpleAction(this, $"{GetType().FullName}-{nameof(mySimpleAction)}", DevExpress.Persistent.Base.PredefinedCategory.Unspecified) 
            { 
            Caption = "Importuj dane",
            ImageName = "BO_Skull"
            };
            mySimpleAction.Execute += mySimpleAction_Execute;
            
        }
        private async void mySimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
            var token =  await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);
            var transactions = await UTAHttpClient.DostawyAsync(token, CustomerSettings.numerKlienta, CustomerSettings.synchronizationId);
           
            GastStationsImporter.SaveDeliveryToDataBase(ObjectSpace, transactions);
           View.ObjectSpace.Refresh();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }

}

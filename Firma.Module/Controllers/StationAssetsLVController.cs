using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Controllers
{
    public class StationAssetsLVController : ObjectViewController<ListView,GasStationAssets>
    {
        SimpleAction MySimpleAction;
        public StationAssetsLVController() : base()
        {
            MySimpleAction = new SimpleAction(this, $"{GetType().FullName}-{nameof(MySimpleAction)}", DevExpress.Persistent.Base.PredefinedCategory.Unspecified)
            {
                Caption = "Importuj Dane",
                ImageName = "BO_Skull"

            };
            MySimpleAction.Execute += MySimpleAction_Execute;
            

        }
        private async void MySimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

               
            
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

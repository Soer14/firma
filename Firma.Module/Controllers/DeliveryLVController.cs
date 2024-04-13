using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Controllers
{
    public class DeliveryLVController : ViewController<ListView>
    {
        SimpleAction mySimpleAction;
        public DeliveryLVController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            mySimpleAction = new SimpleAction(this, $"{GetType().FullName}-{nameof(mySimpleAction)}", DevExpress.Persistent.Base.PredefinedCategory.Unspecified) 
            { 
            Caption = "Importuj dane",
            ImageName = "BO_Skull"
            };
            mySimpleAction.Execute += mySimpleAction_Execute;
            
        }
        private void mySimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
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

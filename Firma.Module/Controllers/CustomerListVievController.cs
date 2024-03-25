using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using Firma.Module.BusinessObjects;
using GUS_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Controllers
{
    public class CustomerListVievController : ViewController<ListView>
    {
        PopupWindowShowAction getCustomerFromGusAction;
        public CustomerListVievController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Customer);
            getCustomerFromGusAction = new PopupWindowShowAction(this, "MyAction", "View")
            {Caption = "Pobierz Klientów",
            ImageName = "BO_Skull"
            };
            getCustomerFromGusAction.Execute += getCustomerFromGusAction_Execute;
            getCustomerFromGusAction.CustomizePopupWindowParams += getCustomerFromGusAction_CustomizePopupWindowParams;
            
        }
        private void getCustomerFromGusAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            var currentObject = e.PopupWindowViewCurrentObject;


            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
            var nipy = currentObject as MySimpleWindow;
            if (nipy != null)
            {
                var gusClient = new GUS("f3ccc9d63a3243bba830");
                gusClient.Login(true);

                string input = nipy.ListaNipow.Replace("-", "");
                
                char[] separators = { ';', ',', '.', ' ', };

                string[] stringArray = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var klienci = gusClient.SzukajPodmiotyNip(stringArray);
                foreach (var client in klienci)
                {
                    Console.WriteLine($"{client.Nazwa}{client.Miejscowosc}{client.KodPocztowy}{client.Ulica}{client.NrLokalu}{client.Typ}");
                    var nip = client.Nip;
                    var customer = ObjectSpace.GetObjectsQuery<Customer>().Where(c => c.VatNumber == nip).FirstOrDefault();
                    if (customer == null ) 
                    {
                        customer = ObjectSpace.CreateObject<Customer>();
                        customer.FillCustomerData(client);
                    }
                }
                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();
                View.Refresh();
            }


           
        }
        private void getCustomerFromGusAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Customer));
            //var dupa = objectSpace.CreateObject<MySimpleWindow>();
            var dupa = new MySimpleWindow();
            e.View = Application.CreateDetailView(objectSpace ,dupa);
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
    [XafDisplayName("Szukanie kontrachentów w GUS")]
    [DomainComponent]
    public class MySimpleWindow
    {
        [XafDisplayName("Lista nipów")]
        public string ListaNipow { get; set; }
    }

}

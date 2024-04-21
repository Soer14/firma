using ApplicationCommon;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
using GasStationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Firma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DetailTransactionVievController : ViewController
    {
        PopupWindowShowAction getTransactionsPopupAction;
        ParametrizedAction getTransactionByDateAction;

        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public DetailTransactionVievController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(DetailTransaction);
            getTransactionByDateAction = new ParametrizedAction(this, $"{GetType().FullName}-{nameof(getTransactionByDateAction)}", PredefinedCategory.Unspecified, typeof(DateTime))
            {
                Caption = "Podaj Datę Faktury",
                ImageName = "BO_Skull",
                PaintStyle = ActionItemPaintStyle.CaptionAndImage,
            };
            getTransactionByDateAction.Execute += getTransactionByDateAction_Execute;

            getTransactionsPopupAction = new PopupWindowShowAction(this, $"{GetType().FullName}-{nameof(getTransactionsPopupAction)}", PredefinedCategory.Unspecified)
            {
                Caption = "Podaj Datę Faktury",
                ImageName = "BO_Skull",
                PaintStyle = ActionItemPaintStyle.CaptionAndImage,
            };
            getTransactionsPopupAction.Execute += getTransactionsPopupAction_Execute;
            getTransactionsPopupAction.CustomizePopupWindowParams += getTransactionsPopupAction_CustomizePopupWindowParams;
            
        }
        private async void getTransactionsPopupAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            
            try
            {

                var selectedSourceViewObjects = (PodajDate)e.PopupWindowViewCurrentObject;
                if (selectedSourceViewObjects != null)
                {
                    var invoiceDate = selectedSourceViewObjects.DataFaktury;
                   
                    _ = await WczytajDaneTransakcji(invoiceDate);

                    View.ObjectSpace.Refresh();
                    Application.ShowViewStrategy.ShowMessage("Dane zostały zsychronizowane.");
                }
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException("Coś się zjebsuło", ex);
            }
        }
        private void getTransactionsPopupAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(DetailTransaction));
            PodajDate objectToShow = new PodajDate();
            if (objectToShow != null)
            {
                DetailView createdView = Application.CreateDetailView(objectSpace, objectToShow);
                createdView.ViewEditMode = ViewEditMode.Edit;
                e.View = createdView;
            }
            //Optionally customize the window display settings.
            //e.Size = new System.Drawing.Size(600, 400);
            //e.Maximized = true;
            //e.IsSizeable = false;
        }
        private async void getTransactionByDateAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            try
            {

                var invoiceDate = (DateTime)e.ParameterCurrentValue;
                // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
                invoiceDate = await WczytajDaneTransakcji(invoiceDate);

                View.ObjectSpace.Refresh();
                Application.ShowViewStrategy.ShowMessage("Dane zostały zsychronizowane.");
            }
            catch ( Exception ex )
            {

                throw new UserFriendlyException("Coś się zjebsuło" , ex);
            }
        }

        private async Task<DateTime> WczytajDaneTransakcji(DateTime invoiceDate)
        {
            if (invoiceDate < new DateTime(2024, 1, 1))
            {
                invoiceDate = DateTime.Now;
            }
            var token = await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);
            var transactions = await UTAHttpClient.GetTransactionsAsync(token, CustomerSettings.numerKlienta, CustomerSettings.synchronizationId, invoiceDate);


            GastStationsImporter.SaveTransactionsToDataBase(ObjectSpace, transactions);
            var records = ObjectSpace.GetObjectsQuery<Delivery>();
            return invoiceDate;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
    [DomainComponent]
    public class PodajDate
    {
        public DateTime DataFaktury { get; set; }
    }
}

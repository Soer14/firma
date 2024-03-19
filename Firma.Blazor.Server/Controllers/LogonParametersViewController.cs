using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Security;

namespace Firma.Blazor.Server.Controllers
{
    public class LogonParametersViewController : ObjectViewController<DetailView, AuthenticationStandardLogonParameters>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            StringPropertyEditor userNamePropertyEditor = (StringPropertyEditor)View.FindItem("UserName");
            userNamePropertyEditor.NullText = "Sam or John";
        }
    }
}

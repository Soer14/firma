using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;

namespace Firma.Blazor.Server;

public class FirmaBlazorApplication : BlazorApplication
{
    public FirmaBlazorApplication()
    {
        ApplicationName = "Firma";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += FirmaBlazorApplication_DatabaseVersionMismatch;
    }
    protected override void OnSetupStarted()
    {
        base.OnSetupStarted();

        if (System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
        {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }

    }
    private void FirmaBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
    {

        e.Updater.Update();
        e.Handled = true;
    }
}

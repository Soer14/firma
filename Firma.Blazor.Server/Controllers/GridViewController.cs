using DevExpress.ExpressApp.Blazor.Editors.Grid;
using DevExpress.ExpressApp;

namespace Firma.Blazor.Server.Controllers
{
    public class GridViewController :ViewController<ListView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (View.Editor is GridListEditor gridListEditor)
            {
                IDxDataGridAdapter dataGridAdapter =
                gridListEditor.GetDataGridAdapter();
                dataGridAdapter.DataGridModel.CssClass
                += " table-striped";
            }
        }
    }
}

using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;

namespace Firma.Win.Controllers
{
    public class GridViewController :ViewController<ListView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (View.Editor is GridListEditor gridListEditor)
            {
                GridView gridView = gridListEditor.GridView;
                gridView.OptionsView.EnableAppearanceOddRow
                = true;
                gridView.Appearance.OddRow.BackColor
                = Color.FromArgb(244, 244, 244);
            }
        }
    }
}

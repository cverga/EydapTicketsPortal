using System.Drawing;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace EydapTickets.Helpers
{
    public static class GridViewFeaturesHelper
    {
        public static void SetupGlobalGridViewBehavior<TEntity>(GridViewSettings<TEntity> settings)
        {
            // Basic configuration
            settings.Width = Unit.Percentage(100);

            // Settings configuration
            //settings.Settings.ShowTitlePanel = true;
            settings.Settings.ShowGroupPanel = true;
            settings.Settings.ShowFilterRow = true;

            settings.Settings.VerticalScrollBarMode = ScrollBarMode.Auto;
            //settings.Settings.VerticalScrollableHeight = 480;

            // Style configuration
            //settings.Styles.AlternatingRow.Enabled = DefaultBoolean.True;
            //settings.Styles.TitlePanel.HorizontalAlign = HorizontalAlign.Left;
            //settings.Styles.TitlePanel.BackColor = Color.White;
            //settings.Styles.TitlePanel.Paddings.Padding = Unit.Pixel(8);

            // Behavior configuration
            settings.SettingsBehavior.AllowFocusedRow = true;
            settings.SettingsBehavior.AllowGroup = true;
            settings.SettingsBehavior.AllowSelectByRowClick = true;
            settings.SettingsBehavior.AllowSelectSingleRowOnly = true;
            settings.SettingsBehavior.AllowSort = true;
            settings.SettingsBehavior.AutoFilterRowInputDelay = 2000;
            settings.SettingsBehavior.ConfirmDelete = true;

            // Cookies configuration
            settings.SettingsCookies.Enabled = false;
            settings.SettingsCookies.StoreColumnsWidth = false;

            // Editing configuration
            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow;
            settings.SettingsEditing.ShowModelErrorsForEditors = true;

            // Command button configuration
            settings.SettingsCommandButton.NewButton.Text = "Προσθήκη";
            settings.SettingsCommandButton.EditButton.Text = "Επεξεργασία";
            settings.SettingsCommandButton.DeleteButton.Text = "Διαγραφή";
            settings.SettingsCommandButton.UpdateButton.Text = "Αποθήκευση";
            settings.SettingsCommandButton.CancelButton.Text = "Ακύρωση";

            // Resizing configuration
            settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.NextColumn;
            // settings.SettingsResizing.Visualization = ColumnResizingOptions.Visualization;

            // Adaptivity configuration
            settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off;
            settings.SettingsAdaptivity.AdaptiveColumnPosition = GridViewAdaptiveColumnPosition.Right;
            settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 1;
            settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = false;
            settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 0;

            // Expand row details image configuration
            //settings.Images.DetailCollapsedButton.Url = "~/Content/Images/1.png";
            //settings.Images.DetailExpandedButton.Url = "~/Content/Images/2.png";

            // Pager configuration
            settings.SettingsPager.Visible = true;
            settings.SettingsPager.PageSize = 30;
        }
    }
}

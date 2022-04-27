using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxThemes;
using DevExpress.Web.Mvc;

namespace EydapTickets.Helpers
{
    // ReSharper disable once InconsistentNaming
    public static class MVCxGridViewToolbarItemCollectionExtensions
    {
        public static MVCxGridViewToolbarItemCollection AddTitle(this MVCxGridViewToolbarItemCollection items, string title)
        {
            var item = items.Add(GridViewToolbarCommand.Custom);
            item.ItemStyle.CssClass += "dxm-title";
            item.Text = title;
            item.Enabled = false;
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddSpring(
            this MVCxGridViewToolbarItemCollection items)
        {
            return AddSpring(items, default(Action<MVCxGridViewToolbarItem>));
        }

        public static MVCxGridViewToolbarItemCollection AddSpring(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(GridViewToolbarCommand.Custom);
            item.Enabled = false;
            item.ItemStyle.CssClass += "dxm-spring";
            item.ItemStyle.Width = Unit.Percentage(100);
            configurator?.Invoke(item);
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddNewRowCommand(this MVCxGridViewToolbarItemCollection items)
        {
            return AddNewRowCommand(items, default(Action<MVCxGridViewToolbarItem>));
        }

        public static MVCxGridViewToolbarItemCollection AddNewRowCommand(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(GridViewToolbarCommand.New);
            item.Text = "Προσθήκη";
            item.Image.IconID = IconID.ActionsAdditem16x16office2013;
            configurator?.Invoke(item);
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddEditRowCommand(this MVCxGridViewToolbarItemCollection items)
        {
            return AddEditRowCommand(items, default(Action<MVCxGridViewToolbarItem>));
        }

        public static MVCxGridViewToolbarItemCollection AddEditRowCommand(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(GridViewToolbarCommand.Edit);
            item.Text = "Επεξεργασία";
            item.Image.IconID = IconID.EditEdit16x16office2013;
            configurator?.Invoke(item);
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddDeleteRowCommand(this MVCxGridViewToolbarItemCollection items)
        {
            return AddDeleteRowCommand(items, default(Action<MVCxGridViewToolbarItem>));
        }

        public static MVCxGridViewToolbarItemCollection AddDeleteRowCommand(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(GridViewToolbarCommand.Delete);
            item.Text = "Διαγραφή";
            item.Image.IconID = IconID.ActionsDeletelist16x16office2013;
            configurator?.Invoke(item);
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddRefreshAllCommand(this MVCxGridViewToolbarItemCollection items)
        {
            return AddRefreshAllCommand(items, default(Action<MVCxGridViewToolbarItem>));
        }

        public static MVCxGridViewToolbarItemCollection AddRefreshAllCommand(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(GridViewToolbarCommand.Refresh);
            item.Text = "Ανανέωση";
            item.Image.IconID = IconID.ActionsRefresh16x16office2013;
            configurator?.Invoke(item);
            return items;
        }


        public static MVCxGridViewToolbarItemCollection AddExportCommandGroup(this MVCxGridViewToolbarItemCollection items)
        {
            items.Add(i =>
            {
                i.Text = "Εξαγωγή";
                i.Image.IconID = IconID.ActionsDownload16x16office2013;
                i.BeginGroup = true;

                var btnExportXls = i.Items.Add(GridViewToolbarCommand.ExportToXls);
                btnExportXls.Text = "Εξαγωγη σε XLS";
                btnExportXls.Image.IconID = IconID.ExportExporttoxls16x16office2013;

                var btnExportXlsx = i.Items.Add(GridViewToolbarCommand.ExportToXlsx);
                btnExportXlsx.Text = "Εξαγωγη σε XLSX";
                btnExportXlsx.Image.IconID = IconID.ExportExporttoxlsx16x16office2013;
            });
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddCustomCommand(
            this MVCxGridViewToolbarItemCollection items,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            return items.AddCustomCommand(false, configurator);
        }

        public static MVCxGridViewToolbarItemCollection AddCustomCommand(
            this MVCxGridViewToolbarItemCollection items,
            bool beginGroup,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var command = items.Add(GridViewToolbarCommand.Custom, beginGroup);
            configurator(command);
            return items;
        }

        public static MVCxGridViewToolbarItemCollection AddCommand(
            this MVCxGridViewToolbarItemCollection items,
            GridViewToolbarCommand command,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            return items.AddCommand(command, false, configurator);
        }

        public static MVCxGridViewToolbarItemCollection AddCommand(
            this MVCxGridViewToolbarItemCollection items,
            GridViewToolbarCommand command,
            bool beginGroup,
            Action<MVCxGridViewToolbarItem> configurator)
        {
            var item = items.Add(command, beginGroup);
            configurator?.Invoke(item);
            return items;
        }
    }
}

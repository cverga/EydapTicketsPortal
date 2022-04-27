using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.Interfaces
{
    public interface ICategory
    {
        int Id { get; set; }
        string CategoryName { get; set; }
        Nullable<int> ParentCategoryId { get; set; }
        bool AllowNew { get; set; }
        bool AllowView { get; set; }
        string Alias { get; set; }
        string JSUrl { get; set; }
        int RowStatus { get; set; }
        System.DateTime RowInserted { get; set; }
        System.DateTime RowLastUpdated { get; set; }

        IEnumerable<Models.Interfaces.ICategoryField> FieldsConfiguration { get; set; }
    }
}

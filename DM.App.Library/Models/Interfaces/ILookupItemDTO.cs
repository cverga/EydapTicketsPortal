using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.Interfaces
{
    public interface ILookupItemDTO
    {
        int? ValueInt { get; set; }
        string ValueString { get; set; }
        string DisplayText { get; set; }
        bool Disabled { get; set; }
    }
}

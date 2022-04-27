using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.DTO
{
    public class LookupItem : Interfaces.ILookupItemDTO
    {
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }
        public string DisplayText { get; set; }
        public bool Disabled { get; set; }
    }
}

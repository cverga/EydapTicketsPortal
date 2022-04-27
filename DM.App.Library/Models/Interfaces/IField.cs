using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.Interfaces
{
    public interface IField
    {
        System.Guid Id { get; set; }
        string Entity { get; set; }
        string FieldName { get; set; }
        string FieldType { get; set; }
        int Size { get; set; }
        bool Nullable { get; set; }
    }
}

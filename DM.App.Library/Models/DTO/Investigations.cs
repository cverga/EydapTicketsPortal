//
// 08.09.2016, Andreas Kasapleris
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Models.DTO
{
    public class Investigation
    {
        public List<EpisynaptomenaFileAttachment> Attachments { get; set; }
    }


    public partial class EpisynaptomenaFileAttachment
    {
        public int Id { get; set; }
        public System.Guid RequestUniqueId { get; set; }
        public string AttachmentUrl { get; set; }
        public string AttachmentFileName { get; set; }
        public string CreatedByLoginName { get; set; }
        public string FieldName { get; set; }
    }

}

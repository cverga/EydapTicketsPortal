using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Areas.Reporting.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public bool Enabled { get; set; }

        public int ReportGroupId { get; set; }

        public int ReportTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EydapTickets.Models
{
    public class _1022EgkatastasiModel
    {
        public int EgkatastasiId { get; set; }

        public string EgkatastasiCode { get; set; } // nvarchar(24)

        public string EgkatastasiDescription { get; set; } // nvarchar(128)

        public _1022EgkatastasiModel()
        {

        }

        public _1022EgkatastasiModel(int aEgkatastasiId,
                                  string aEgkatastasiCode,
                                  string aEgkatastasiDescription)
        {
            EgkatastasiId = aEgkatastasiId;
            EgkatastasiCode = aEgkatastasiCode;
            EgkatastasiDescription = aEgkatastasiDescription;
        }
    }
}
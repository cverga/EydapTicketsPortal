using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EydapTickets.Models
{
    public class _1022D04Model
    {
        public int D04Id { get; set; }

        public string D04Description { get; set; } // nvarchar(50)

        public _1022D04Model()
        {

        }

        public _1022D04Model(int aD04Id,
                          string aD04Description)
        {
            D04Id = aD04Id;
            D04Description = aD04Description;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;                           // 17.06.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations;        // 17.06.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 17.06.2016, SQL Server; need to add this

//using System.Web.Mvc;
//using System.Web.Security;

namespace EydapTickets.Models
{
    public class _1022ProblemsContext : DbContext
    {
        public _1022ProblemsContext()
            : base("DefaultConnection")
        {
        }

        // public System.Data.Entity.DbSet<DX151Admin.Models._1022ProblemsModel> _1022ProblemsModels { get; set; }

    }

     [Table("1022Problems")]
    public class _1022ProblemsModel
    {
        public int ProblemsId { get; set; }

        public string ProblemsCode { get; set; } // nvarchar(24)

        public string ProblemsDescription { get; set; } // nvarchar(128)

        public _1022ProblemsModel()
        {

        }

        public _1022ProblemsModel(int aProblemsId,
                               string aProblemsCode,
                               string aProblemsDescription)
        {
            ProblemsId = aProblemsId;
            ProblemsCode = aProblemsCode;
            ProblemsDescription = aProblemsDescription;
        }
    }

}
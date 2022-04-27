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
    public class _1022EidosProblemsContext : DbContext
    {
        public _1022EidosProblemsContext()
            : base("DefaultConnection")
        {
        }

        // public System.Data.Entity.DbSet<DX151Admin.Models._1022EidosProblemsModel> _1022EidosProblemsModels { get; set; }

    }

    [Table("1022EidosProblems")]
    public class _1022EidosProblemsModel
    {
        public int EidosProblemsId { get; set; }

        public string EidosProblemsCode { get; set; } // nvarchar(24)

        public string EidosProblemsDescription { get; set; } // nvarchar(128)

        public _1022EidosProblemsModel()
        {

        }

        public _1022EidosProblemsModel(int aEidosProblemsId,
                                    string aEidosProblemsCode,
                                    string aEidosProblemsDescription)
        {
            EidosProblemsId = aEidosProblemsId;
            EidosProblemsCode = aEidosProblemsCode;
            EidosProblemsDescription = aEidosProblemsDescription;
        }

    }
}
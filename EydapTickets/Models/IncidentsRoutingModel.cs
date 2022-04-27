using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
// added
//
using System.Data.Entity;                           // 16.06.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations;        // 16.06.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 16.06.2016, SQL Server; need to add this

// using System.Web.Mvc;
// using System.Web.Security;

namespace EydapTickets.Models
{
    public class IncidentsRoutingContext : DbContext
    {
        public IncidentsRoutingContext()
            : base("DefaultConnection")
        {
        }

        // public System.Data.Entity.DbSet<DX151Admin.Models.IncidentsRoutingModel> IncidentsRoutingModel { get; set; }

    }

    //
    // 16.06.2016, Andreas Kasapleris
    // Data Model, Class to represent SQL Table : IncidentsRouting
    //

    [Table("IncidentsRouting")]
    public class IncidentsRoutingModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }                            // SQL type : int  NOT NULL

        // public int RoutingSectorId { get; set; }               // SQL type : int, old implementation

        // hidden column in GridView; remove from model
	    // public string RoutingSectorName { get; set; }          // [nvarchar](128)

        // public int EidosProblemsId { get; set; }               // SQL type : int, old implementation

        // hidden column in GridView; remove from model
        // public string EidosProblemsDescription { get; set; }   // [nvarchar](128)

        // public int ProblemsId { get; set; }                    // SQL type : int, old implementation

        // hidden column in GridView; remove from model
        // public string ProblemsDescription { get; set; }        // [nvarchar](128)

        // public int EgkatastasiId { get; set; }                 // SQL type : int, old implementation

        // hidden column in GridView; remove from model
        // public string EgkatastasiDescription { get; set; }     // [nvarchar](128)

        // public int RoutingDepartmentId { get; set; }           // SQL type : int, old implementation

        // hidden column in GridView; remove from model
        // public string RoutingDepartmentName { get; set; }      // SQL type : [nvarchar](128)

        public string ComesFromTTSectorName { get; set; }         // SQL type : [nvarchar](50)

        public string ComesFromTTDeptName { get; set; }           // SQL type : [nvarchar](50)

        public string ProblemD04Description { get; set; }         // SQL type : nvarchar(150)

        public DateTime FromWorkingDate { get; set; }              // SQL type : DateTime

        public DateTime ToWorkingDate { get; set; }                // SQL type : DateTime

        public DateTime FromWeekendDate { get; set; }              // SQL type : DateTime

        public DateTime ToWeekendDate { get; set; }                // SQL type : DateTime

        public int RouteToDepartmentId { get; set; }              // SQL type : int

        public byte RoutingIsActive { get; set; }                 // SQL type : bit

        public string RouteToDepartmentName { get; set; }         // used in the model; result of join query; holds department name

        public IncidentsRoutingModel()
        {

        }

        //public IncidentsRoutingModel(int aRecId,
        //                             int aRoutingSectorId,     string aRoutingSectorName,
        //                             int aEidosProblemsId,     string aEidosProblemsDescription,
        //                             int aProblemsId,          string aProblemsDescription,
        //                             int aEgkatastasiId,       string aEgkatastasiDescription,
        //                             int aRoutingDepartmentId, string aRoutingDepartmentName,
        //                             byte aRoutingIsActive
        //                             )

        public IncidentsRoutingModel(int      aRecId,
                                     string   aComesFromTTSectorName,
                                     string   aComesFromTTDeptName,
                                     string   aProblemD04Description,
                                     DateTime aFromWorkingDate,
                                     DateTime aToWorkingDate,
                                     DateTime aFromWeekendDate,
                                     DateTime aToWeekendDate,
                                     int      aRouteToDepartmentId,
                                     byte     aRoutingIsActive,
                                     string   aRouteToDepartmentName)
        {
            RecId = aRecId;
            ComesFromTTSectorName = aComesFromTTSectorName;
            ComesFromTTDeptName = aComesFromTTDeptName;
            ProblemD04Description = aProblemD04Description;
            FromWorkingDate = aFromWorkingDate;
            ToWorkingDate = aToWorkingDate;
            FromWeekendDate = aFromWeekendDate;
            ToWeekendDate = aToWeekendDate;
            RouteToDepartmentId = aRouteToDepartmentId;
            RoutingIsActive = aRoutingIsActive;
            RouteToDepartmentName = aRouteToDepartmentName;
        }

    }

}
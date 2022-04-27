using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity; // 08.06.2016, Entity Framework; need to add this
using System.ComponentModel.DataAnnotations; // 08.06.2016, SQL Server; need to add this
using System.ComponentModel.DataAnnotations.Schema; // 08.06.2016, SQL Server; need to add this

//using System.Web.Mvc;
//using System.Web.Security;


namespace EydapTickets.Models
{
    //
    // 08.05.2016, Andreas Kasapleris
    // Data Model, Class to represent SQL Table : Forms
    //

    public class FormsModel
    {
        public int FormId { get; set; }                // SQL type : int
        public string FormCode { get; set; }           // SQL type : nvarchar(50)
        public string FormDescription { get; set; }    // SQL type : nvarchar(250)

        public FormsModel()
        {

        }

        public FormsModel(int aFormId, string aFormCode, string aFormDescription)
        {
            FormId = aFormId;
            FormCode = aFormCode;
            FormDescription = aFormDescription;
        }

    }

}
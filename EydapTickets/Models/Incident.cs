using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Models
{
    public class Incident
    {
        [Key]
        [Display(Name = "Κλειδί")]
        public Guid TTId { get; set; }

        [Display(Name = "Κωδικός 1022")]
        public string ID1022 { get; set; }

        [Display(Name = "Όνομα Καλούντος")]
        public string CustomerName { get; set; }

        [Display(Name = "Επώνυμο Καλούντος")]
        public string CustomerSurName { get; set; }

        [Display(Name = "Τηλέφωνο")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        [Display(Name = "Οδός 2")]
        public string StreetName1 { get; set; }

        [Display(Name = "Αριθμός 2")]
        public string StreetNumber1 { get; set; }

        [Display(Name = "Σχόλια")]
        public string Comments { get; set; }

        public int Sector { get; set; }

        public string SectorName { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [Display(Name = "Ημερομηνία Αναφοράς")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Κατάσταση")]
        public int Status { get; set; }

        //TODO: Fill this from DB
        [Display(Name = "Περιοχή")]
        public string Perioxi { get; set; }

        //TODO: Fill this from DB
        [Display(Name = "Ταχυδρομικός Κώδικας")]
        public string TaxKodikas { get; set; }

        [Display(Name = "ΔΔΥ")]
        public int CommentCount { get; set; }

        public decimal Percent { get; set; }

        public string TicketTraceId { get; set; }

        [Display(Name = "Σχετιζόμενο")]
        public string RelatedID1022 { get; set; }

        [Display(Name = "Είδος Προβλήματος")]
        public string EidosProblimatosDescr { get; set; }

        [Display(Name = "Πρόβλημα")]
        public string Cause { get; set; }

        public string TEBCC { get; set; }

        [Display(Name = "Τμήμα")]
        public int MyDepartmentColor { get; set; }

        [Display(Name = "Άλλα")]
        public int OtherDepartmentColor { get; set; }

        public Incident()
        {
            //Sector = 1;
        }

        public Incident(
            Guid aTTId,
            string aID1022,
            string aCustomerName,
            string aCustomerPhone,
            string aCustomerEmail,
            string aMunicipality,
            string aStreetName,
            string aStreetName1,
            string aStreetNumber,
            string aComments,
            int aSector,
            DateTime? aDateCreated,
            int aStatus,
            int aCommentCount,
            string aPercent,
            string aTicketTraceId,
            string aRelatedID1022,
            string aProblemDescription,
            string aCause,
            string aTEBCC,
            int aColor1,
            int aColor2,
            string aPerioxi,
            double aLongitude = 0.0,
            double aLatitude = 0.0)
        {
            TTId = aTTId;
            CustomerName = aCustomerName;
            CustomerSurName = aCustomerName;
            CustomerPhone = aCustomerPhone;
            CustomerEmail = aCustomerEmail;
            Municipality = aMunicipality;
            StreetName = aStreetName;
            StreetName1 = aStreetName1;
            StreetNumber = aStreetNumber;
            Comments = aComments.Replace(";", " ");
            ID1022 = aID1022;
            Sector = aSector;
            DateCreated = aDateCreated;
            Status = aStatus;
            CommentCount = aCommentCount;
            Longitude = aLongitude;
            Latitude = aLatitude;
            string[] mnumbers = aPercent.Split(new char[1] { '/' });
            if (Convert.ToDecimal(mnumbers[1]) > 0)
            {
                Percent = Convert.ToDecimal(mnumbers[0]) / Convert.ToDecimal(mnumbers[1]) * 100;
            }
            else
            {
                Percent = 0;
            }

            TicketTraceId = aTicketTraceId;
            RelatedID1022 = aRelatedID1022;
            EidosProblimatosDescr = aProblemDescription;
            Cause = aCause;
            TEBCC = String.IsNullOrEmpty(aTEBCC) == true ? null: aTEBCC.Substring(0, aTEBCC.IndexOf(";"));
            MyDepartmentColor = aColor1;
            OtherDepartmentColor = aColor2;
            Perioxi = aPerioxi;
        }
    }
}

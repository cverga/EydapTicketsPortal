using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EydapTickets.Models
{
    //
    // 20/04/2017, Andreas Kasapleris
    // has to be same Class definition as in ΕΥΔΑΠ BackEnd Application
    // SharedEntities.Incident Class. If you make changes there, you MUST
    // also make changes in this class (model)
    // The Class here is called BackEndIncident just for avoiding conflicts
    // between classes defined in Portal DDY application
    //
    public class BackEndIncident
    {
        public Guid TTId { get; set; } // ok
        public string ID1022 { get; set; } // ok
        public string CustomerName { get; set; } // ok
        public string CustomerSurName { get; set; } // ok
        public string SectorName { get; set; } // ok
        public string CustomerPhone { get; set; } // ok
        public string CustomerEmail { get; set; } // ok
        public string Municipality { get; set; } // ok
        public string StreetName { get; set; } // ok
        public string StreetNumber { get; set; } // ok
        public string StreetName1 { get; set; } // ok
        public string StreetNumber1 { get; set; } // ok
        public string Comments { get; set; } // ok
        public int Sector { get; set; } // ok
        public int ForwardToDeptId { get; set; } // ok
        public decimal? Latitude { get; set; } // ok
        public decimal? Longitude { get; set; } // ok
        public string Shift { get; set; } // ok
        public string Perioxi { get; set; } // ok
        public string TaxKodikas { get; set; } // ok
        public string ArithmosMetriti { get; set; }
        public string MitrooMetriti { get; set; }

        public DateTime? CreationDate { get; set; }

        public BackEndUser User { get; set; } // ok
        public List<BackEndUser> Users { get; set; } // ok
        public List<Vehicle> Vehicles { get; set; } //ok

        public BackEndIncident()
        {

        }

        public BackEndIncident(Guid    anewTTId,
                        string   aID1022,        string aCustomer_Name,  string aCustomer_SurName,
                        string   aSectorName,    string aCustomerPhone,  string aCustomerEmail,
                        string   aMunicipality,  string  aStreetName,    string aStreetNumber,
                        string   aStreetName1,   string aStreetNumber1,  string  aComments,
                        int      aSector,        int    aForwardToDeptId,
                        decimal? aLongitude,     decimal? aLatitude,    string  aShift,
                        string aPerioxi,         string  aTaxKodikas,   string aArithmosMetriti,
                        string aMitrooMetriti,
                        BackEndUser aUser,
                        List<BackEndUser> aUsers,
                        List<Vehicle> aVehicles)
        {
            this.TTId            = anewTTId;
            this.ID1022          = aID1022;

            //if (!string.IsNullOrEmpty(aCustomer_Name) && aCustomer_Name.Length > 49)
            //{
            //    this.CustomerName = aCustomer_Name.Substring(0, 49);
            //}

            this.CustomerName    = aCustomer_Name;

            //if (!string.IsNullOrEmpty(aCustomer_SurName) && aCustomer_SurName.Length > 49)
            //{
            //    this.CustomerSurName = aCustomer_SurName.Substring(0, 49);
            //}

            this.CustomerSurName = aCustomer_SurName;

            // SECTORS in BACKEND
            // 2     = ΣΥΝΤΗΡΗΣΗΣ ΑΘΗΝΑΣ
            // 10003 = ΣΥΝΤΗΡΗΣΗΣ ΠΕΙΡΑΙΑΣ
            // 1     = ΣΥΝΤΗΡΗΣΗΣ ΗΡΑΚΛΕΙΟΥ
            // 10011 = ΣΥΝΤΗΡΗΣΗΣ ΑΣΠΡΟΠΥΡΓΟΥ
            // 10012 = ΣΥΝΤΗΡΗΣΗΣ ΣΑΛΑΜΙΝΑΣ
            // 10013 = ΣΥΝΤΗΡΗΣΗΣ ΜΕΝΙΔΙΟΥ

            if (aForwardToDeptId == 1033)
            {
                this.Sector = 2;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΑΘΗΝΑΣ";
            }
            else if (aForwardToDeptId == 1039)
            {
                this.Sector = 10003;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΠΕΙΡΑΙΑΣ";
            }
            else if (aForwardToDeptId == 1043)
            {
                this.Sector = 1;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΗΡΑΚΛΕΙΟΥ";
            }
            else if (aForwardToDeptId == 1082)
            {
                this.Sector = 10011;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΑΣΠΡΟΠΥΡΓΟΥ";
            }
            else if (aForwardToDeptId == 1084)
            {
                this.Sector = 10012;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΣΑΛΑΜΙΝΑΣ";
            }
            else if (aForwardToDeptId == 1097)
            {
                this.Sector = 10013;
                this.SectorName = "ΣΥΝΤΗΡΗΣΗΣ ΜΕΝΙΔΙΟΥ";
            }

            this.CustomerPhone = aCustomerPhone;
            this.CustomerEmail = aCustomerEmail;
            this.Municipality = aMunicipality;
            this.StreetName = aStreetName;
            this.StreetNumber = aStreetNumber;
            this.StreetName1 = aStreetName1;
            this.StreetNumber1 = aStreetNumber1;
            this.Comments = aComments;

            this.ForwardToDeptId = aForwardToDeptId;

            this.Latitude  = aLatitude;
            this.Longitude = aLongitude;

            this.Shift = aShift;

            //convert greek chars to english, cause field works has english A and B but greek Γ
            if (aShift == "Α")
            {
                this.Shift = "A";
            }
            else if (aShift == "Β")
            {
                this.Shift = "B";
            }

            this.Perioxi = aPerioxi;
            this.TaxKodikas = aTaxKodikas;

            ArithmosMetriti = aArithmosMetriti;
            MitrooMetriti = aMitrooMetriti;

            this.User = aUser;
            this.Users = aUsers;
            this.Vehicles = aVehicles;

        }

    }

}
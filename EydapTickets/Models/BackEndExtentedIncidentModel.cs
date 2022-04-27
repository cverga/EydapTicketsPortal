using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EydapTickets.Models
{
    //
    // 21/04/2017, Andreas Kasapleris
    // extends BackEndIncident Class (see BackEndIncidendtModel.cs)
    // Same class definion as in Web Service which imports Tickets/Incidents
    // from 1022 to Portal. When changes happen there, these changes should
    // also be made here.
    //
    public class ExtentedIncident : BackEndIncident
    {
        //
        // 21.04.2017, Andreas Kasapleris
        // Class constructor
        //
        public ExtentedIncident(BackEndIncident aNewIncident)
        {
            aNewIncomingIncident = new BackEndIncident();

            aNewIncomingIncident.TTId = aNewIncident.TTId;
            aNewIncomingIncident.ID1022 = aNewIncident.ID1022;
            aNewIncomingIncident.CustomerName = aNewIncident.CustomerName;
            aNewIncomingIncident.CustomerSurName = aNewIncident.CustomerSurName;
            aNewIncomingIncident.SectorName = aNewIncident.SectorName;
            aNewIncomingIncident.CustomerPhone = aNewIncident.CustomerPhone;
            aNewIncomingIncident.CustomerEmail = aNewIncident.CustomerEmail;
            aNewIncomingIncident.Municipality = aNewIncident.Municipality;
            aNewIncomingIncident.StreetName = aNewIncident.StreetName;
            aNewIncomingIncident.StreetNumber = aNewIncident.StreetNumber;
            aNewIncomingIncident.StreetName1 = aNewIncident.StreetName1;
            aNewIncomingIncident.StreetNumber1 = aNewIncident.StreetNumber1;
            aNewIncomingIncident.Comments = aNewIncident.Comments;
            aNewIncomingIncident.Sector = aNewIncident.Sector;
            aNewIncomingIncident.Latitude = aNewIncident.Latitude;
            aNewIncomingIncident.Longitude = aNewIncident.Longitude;
            aNewIncomingIncident.Shift = aNewIncident.Shift;
            aNewIncomingIncident.Perioxi = aNewIncident.Perioxi;
            aNewIncomingIncident.TaxKodikas = aNewIncident.TaxKodikas;
            aNewIncomingIncident.User = aNewIncident.User;
            aNewIncomingIncident.Users = aNewIncident.Users;
            aNewIncomingIncident.Vehicles = aNewIncident.Vehicles;

        }

        public BackEndIncident aNewIncomingIncident { get; set; }
        // extented properties
        public bool Propagated { get; set; }
        public string BackEndTabletId { get; set; }
    }
}
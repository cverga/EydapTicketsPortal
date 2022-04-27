using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EydapTickets.Models
{
    public class StatisticsPanelModel
    {
        [Display(Name = "Ημερομηνία Από")]
        public DateTime? From { get; set; }

        [Display(Name = "Ημερομηνία Έως")]
        public DateTime? To { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        public List<SelectListItem> Municipalities => IncidentProvider.GetIncidentMunicipalities();

        public List<SelectListItem> StreetNames => IncidentProvider.GetIncidentStreetNames(Municipality);
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

// 05.10.2017, Andreas Kasapleris, needed for implementing custom ValidationAttributes
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class ProvisionDetails
    {
        //
        // 05.10.2017, Andreas Kasapleris
        // define/create a custom validation attribute namely NeaParoxiDateRange(Attribute)
        // for validating various Nea Paroxi date fields entered by the user
        // The custom validation attribute is a Class inheriting from ValidationAttribute Class
        // and overiding the IsValid property of this Class
        //
        private class NeaParoxiDateRangeAttribute : ValidationAttribute
        {
            // Class Constructor
            public NeaParoxiDateRangeAttribute()
            {
                // constructor logic here
            }

            public override bool IsValid(object userDate)
            {
                if (userDate != null)
                {
                    // if user has entered or picked a date
                    if (!String.IsNullOrEmpty(userDate.ToString()))
                    {
                        DateTime userEnteredDate = DateTime.Parse(userDate.ToString()); // user entered date

                        // if user entered date is later (greater) than today;
                        // then the model should report to be not valid and hence
                        // return false
                        if (userEnteredDate > DateTime.Now)
                        {
                            return false;
                        }

                    }
                }

                // the date is correct or empty, return true
                return true;
            }
        }

        public Int32 RAMID { get; set; }

        [DisplayName("Ημερομηνία Παροχής")]
        public DateTime? ProvisionDate { get; set; }
        [DisplayName("Ασφαλτος")]
        public bool Asphaltos { get; set; }
        [DisplayName("Μπετον")]
        public bool Mpeton { get; set; }
        [DisplayName("Πλακες")]
        public bool Plakes { get; set; }

        [DisplayName("Κρασπεδορειθρο")]
        public bool Kraspedorithro { get; set; }
        [DisplayName("Χωμα")]
        public bool Xoma { get; set; }

        //
        // 05.10.2017, Andreas Kasapleris
        // decorate Class property 'EpanaforaAsphatosDate' with custom date
        // validation attribute, user entered date has to be earlier than today
        //
        [NeaParoxiDateRange(ErrorMessage = "Η Ημερομηνία πρέπει να είναι προγενέστερη ή τουλάχιστον σημερινή.")]
        [DisplayName("Ημερομηνια Επαναφορας Ασφαλτου")]
        public DateTime? EpanaforaAsphatosDate { get; set; }

        [NeaParoxiDateRange(ErrorMessage = "Η Ημερομηνία πρέπει να είναι προγενέστερη ή τουλάχιστον σημερινή.")]
        [DisplayName("Ημερομηνια Επαναφορας Πεζοδρομιου")]
        public DateTime? EpanaforaPezodromiouDate { get; set; }

        [NeaParoxiDateRange(ErrorMessage = "Η Ημερομηνία πρέπει να είναι προγενέστερη ή τουλάχιστον σημερινή.")]
        [DisplayName("Ημερομηνια Αποκομιδης Μπαζων")]
        public DateTime? ApokomidiBazaDate { get; set; }

        public ProvisionDetails()
        { }
        public ProvisionDetails(Int32 aId, DateTime? aProvisionDate, bool aAsphaltos, bool aMpeton, bool aPlakes, bool aKraspedorithro, bool aXoma, DateTime? aEpanaforaAsphatosDate, DateTime? aEpanaforaPezodromiouDate, DateTime? aApokomidiBazaDate)
        {
            RAMID = aId;
            ProvisionDate = aProvisionDate;
            Asphaltos = aAsphaltos;
            Mpeton = aMpeton;
            Plakes = aPlakes;
            Kraspedorithro = aKraspedorithro;
            Xoma = aXoma;
            EpanaforaAsphatosDate = aEpanaforaAsphatosDate;
            EpanaforaPezodromiouDate = aEpanaforaPezodromiouDate;
            ApokomidiBazaDate = aApokomidiBazaDate;
        }
    }
}
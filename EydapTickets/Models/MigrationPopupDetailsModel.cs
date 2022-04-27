using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class MigrationPopupDetailsModel
    {
        [Display(Name = "Κωδικός Βλάβης")]
        public string Code { get; set; }

        [Display(Name = "Ημερομηνία Ειδοποίησης")]
        public DateTime? NotificationDate { get; set; }

        [Display(Name = "Ημερομηνία Απομόνωσης")]
        public DateTime? DisconnectionDate { get; set; }

        [Display(Name = "Ημερομηνία Επαναφοράς")]
        public DateTime? ReconnectionDate { get; set; }

        [Display(Name = "Αιτία Βλάβης")]
        public string mBlab { get; set; }

        [Display(Name = "Τρόπος Εντοπισμού")]
        public string mWay { get; set; }

        [Display(Name = "Σημείο Βλάβης")]
        public string mPointbl { get; set; }

        [Display(Name = "Παρατηρήσεις Τρόπου Επισκευής")]
        public string mNote1 { get; set; }

        [Display(Name = "Αλλες Παρατηρήσεις")]
        public string mNote2 { get; set; }

        [Display(Name = "Είδος Βλάβης")]
        public string mEidos_Blabhs { get; set; }

        [Display(Name = "Εργολαβία")]
        public string mZone { get; set; }

        [Display(Name = "Ιδιωτικό")]
        public bool mIdiotiko { get; set; }

        [Display(Name = "Κωδ.1")]
        public string mIdCod1 { get; set; }

        [Display(Name = "Κωδ.2")]
        public string mIdCod2 { get; set; }

        [Display(Name = "Προέλευση")]
        public string mF1202 { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="notificationDate"></param>
        /// <param name="disconnectionDate"></param>
        /// <param name="reconnectionDate"></param>
        /// <param name="aBlab"></param>
        /// <param name="aWay"></param>
        /// <param name="aPointbl"></param>
        /// <param name="aNote1"></param>
        /// <param name="aNote2"></param>
        /// <param name="aEidos_Blabhs"></param>
        /// <param name="aZone"></param>
        /// <param name="aIdiotiko"></param>
        /// <param name="aIdCod1"></param>
        /// <param name="aIdCod2"></param>
        /// <param name="aF1202"></param>
        public MigrationPopupDetailsModel(
            string    code,
            DateTime? notificationDate,
            DateTime? disconnectionDate,
            DateTime? reconnectionDate,
            string   aBlab,
            string   aWay,
            string   aPointbl,
            string   aNote1,
            string   aNote2,
            string   aEidos_Blabhs,
            string   aZone,
            bool     aIdiotiko,
            string   aIdCod1,
            string   aIdCod2,
            string   aF1202)
        {
            Code = code;
            NotificationDate = notificationDate;
            DisconnectionDate = disconnectionDate;
            ReconnectionDate = reconnectionDate;
            mBlab = aBlab;
            mWay = aWay;
            mPointbl = aPointbl;
            mNote1 = aNote1;
            mNote2 = aNote2;
            mEidos_Blabhs = aEidos_Blabhs;
            mZone = aZone;
            mIdiotiko = aIdiotiko;
            mIdCod1 = aIdCod1;
            mIdCod2 = aIdCod2;
            mF1202 = aF1202;
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public MigrationPopupDetailsModel()
        {
            // NOOP
        }
    }
}
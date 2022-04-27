using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class MigrationResultsModel
    {
        [Display(Name = "Κωδικός Βλάβης")]
        public string mCodikos { get; set; }

        [Display(Name = "Κωδικός 1022")]
        public string mCode_1202 { get; set; }

        [Display(Name = "Τομέας")]
        public string mYphr { get; set; }

        [Display(Name = "Τμήμα")]
        public string mTmhma { get; set; }

        [Display(Name = "Περιοχή")]
        public string mArea { get; set; }

        [Display(Name = "Δήμος")]
        public string mDhmos { get; set; }

        [Display(Name = "Οδός")]
        public string mStreet { get; set; }

        [Display(Name = "Οδός 2")]
        public string mStreet2 { get; set; }

        [Display(Name = "Αριθμός")]
        public string mArith { get; set; }

        [Display(Name = "Κωδικός Συσχετιζόμενου")]
        public string mKod_sysx { get; set; }

        [Display(Name = "Ημερομηνία Ειδοποίησης")]
        public DateTime mXdate { get; set; }

        /// <summary>
        /// Create an new instance of <see cref="MigrationResultsModel"/>
        /// </summary>
        /// <param name="aCodikos"></param>
        /// <param name="aCode_1202"></param>
        /// <param name="aYphr"></param>
        /// <param name="aTmhma"></param>
        /// <param name="aArea"></param>
        /// <param name="aDhmos"></param>
        /// <param name="aStreet"></param>
        /// <param name="aStreet2"></param>
        /// <param name="aArith"></param>
        /// <param name="aKod_sysx"></param>
        /// <param name="aXdate"></param>
        public MigrationResultsModel(
            string aCodikos,
            string aCode_1202,
            string aYphr,
            string aTmhma,
            string aArea,
            string aDhmos,
            string aStreet,
            string aStreet2,
            string aArith,
            string aKod_sysx,
            DateTime aXdate)
        {
            mCodikos   = aCodikos;
            mCode_1202 = aCode_1202;
            mYphr      = aYphr;
            mTmhma     = aTmhma;
            mArea      = aArea;
            mDhmos     = aDhmos;
            mStreet    = aStreet;
            mStreet2   = aStreet2;
            mArith     = aArith;
            mKod_sysx  = aKod_sysx;
            mXdate     = aXdate;
        }

        public MigrationResultsModel()
        {
            // NOOP
        }
    }
}

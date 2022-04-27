using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using EydapTickets.Models;

namespace EydapTickets.Models
{
    public class BasicStatisticsModel
    {
        public List<string> Descriptions { get; set; }
        public List<BasciValuesModel> Values { get; set; }

        public BasicStatisticsModel(List<string> aDescriptions, List<BasciValuesModel> aBasicValuesModel)
        {
            Descriptions = aDescriptions;
            Values = aBasicValuesModel;
        }

        public BasicStatisticsModel()
        {

        }
    }

    public class StatisticsCreteriaModel
    {
        List<SelectListItem> mMunicipalities;
        List<SelectListItem> mSectors;

        [Display(Name = "Από")]
        //[Required(ErrorMessage = "First name is required")]
        public DateTime FromStatistics { get; set; }

        [Display(Name = "Εώς")]
        //[Required(ErrorMessage = "Date is required")]
        public DateTime ToStatistics { get; set; }

        public List<SelectListItem> Municipalities
        {
            get
            {
                if (mMunicipalities == null)
                {
                    mMunicipalities = IncidentProvider.GetIncidentMunicipalities();
                }

                return mMunicipalities;
            }
            private set { mMunicipalities = value; }
        }

        public List<SelectListItem> Sectors
        {
            get
            {
                if (mSectors == null)
                {
                    mSectors = new List<SelectListItem>();
                    SelectListItem mItem = new SelectListItem();
                    mItem.Text = "ΤΟΜΕΑΣ ΑΘΗΝΩΝ";
                    mItem.Value = "1";
                    mSectors.Add(mItem);

                    mItem = new SelectListItem();
                    mItem.Text = "ΤΟΜΕΑΣ ΠΕΙΡΑΙΑ";
                    mItem.Value = "2";
                    mSectors.Add(mItem);

                    mItem = new SelectListItem();
                    mItem.Text = "ΤΟΜΕΑΣ ΗΡΑΚΛΕΙΟΥ";
                    mItem.Value = "3";
                    mSectors.Add(mItem);
                }
                return mSectors;
            }
            private set { mSectors = value; }
        }

        public List<SelectListItem> StreetNames
        {
            get
            {
                return IncidentProvider.GetIncidentStreetNames(MunicipalityStatistics);
            }
            private set { }
        }

        [Display(Name = "Δήμος")]
        public String MunicipalityStatistics { get; set; }

        [Display(Name = "Οδός")]
        public string StreetNameStatistics { get; set; }

        [Display(Name = "Αριθμός")]
        public string StreetNumberStatistics { get; set; }

        [Display(Name = "Αναφορά")]
        public string ReportType { get; set; }

        //[Required(ErrorMessage = "First name is required")]
        public string SectorsStatistics { get; set; }

        public IEnumerable<ReportType> ReportTypes
        {
            get
            {
                return IncidentProvider.GetReportTypes();
            }
            set
            {
                //ReportType = value;
            }
        }


        //public IEnumerable<ReportType> ReportTypes = IncidentProvider.GetReportTypes();

        public StatisticsCreteriaModel()
        {

        }
    }

    //public class StatisticsModel
    //{
    //    List<Incident> mIncidents = new List<Incident>();
    //    List<SelectListItem> mMunicipalities;

    //    [Display(Name = "Κωδικός 1022")]
    //    public string Code1022 { get; set; }

    //    [Display(Name = "Από")]
    //    public DateTime? DateFrom { get; set; }

    //    [Display(Name = "Έως")]
    //    public DateTime? To { get; set; }

    //    [Display(Name = "Κατάσταση")]
    //    public Int32 Status { get; set; }

    //    public List<SelectListItem> Municipalities
    //    {
    //        get
    //        {
    //            if (mMunicipalities == null)
    //            {
    //                mMunicipalities = IncidentProvider.GetIncidentMunicipalities();
    //            }
    //            return mMunicipalities;
    //        }
    //        private set { mMunicipalities = value; }
    //    }

    //    public List<SelectListItem> StreetNames
    //    {
    //        get
    //        {
    //            return IncidentProvider.GetIncidentStreetNames(Municipality); ;
    //        }
    //        private set { }
    //    }

    //    [Display(Name = "Δήμος")]
    //    public String Municipality { get; set; }

    //    [Display(Name = "Οδός")]
    //    public string StreetName { get; set; }

    //    [Display(Name = "Αριθμός")]
    //    public string StreetNumber { get; set; }

    //    [Display(Name = "Επίθετο πελάτη")]
    //    public string CustomerSurName { get; set; }

    //    public List<Incident> RelatedIncidents
    //    {
    //        get { return mIncidents; }
    //        set { mIncidents = value; }
    //    }

    //    public IEnumerable<TaskType> TaskList = IncidentProvider.GetTasksTypes();
    //    public StatisticsModel()
    //    {

    //    }
    //}

    public class BasciValuesModel
    {
        public string ONE { get; set; }
        public string TWO { get; set; }
        public string THREE { get; set; }
        public string FOUR { get; set; }
        public string FIVE { get; set; }
        public BasciValuesModel(string aONE, string aTWO, string aTHREE, string aFOUR, string aFIVE)
        {
            ONE = aONE;
            TWO = aTWO;
            THREE = aTHREE;
            FOUR = aFOUR;
            FIVE = aFIVE;
        }
    }
}
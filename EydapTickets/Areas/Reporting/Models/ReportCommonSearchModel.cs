//
// Creation Date: 26.03.2018
// Created by   : Andreas Kasapleris
// Description  : common Class used in criteria search panels
//                for Portal DevExpress Reporting
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Areas.Reporting.Models
{
    public class ReportCommonSearchModel
    {
        // 29.03.2018, show report or not
        public bool ShowReport { get; set; }

        [Display(Name = "Από Ανάθεση")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Έως Ανάθεση")]
        [Required(ErrorMessage = "Το πεδίο είναι υποχρεωτικό")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Δήμος")]
        public string Municipality { get; set; }

        // Class field
        private List<SelectListItem> _Municipalities;

        // Class property
        public List<SelectListItem> Municipalities
        {
            get
            {
                if (_Municipalities == null)
                {
                    _Municipalities = IncidentProvider.GetIncidentMunicipalities();

                    // 08.03.2018, Andreas Kasapleris
                    // add the empty 'SelectListItem' object to the top of mMunicipalities list
                    SelectListItem emptyMunicipality = new SelectListItem();
                    emptyMunicipality.Text = "";
                    emptyMunicipality.Value = "";
                    _Municipalities.Insert(0, emptyMunicipality);
                }
                return _Municipalities;
            }

            set { _Municipalities = value; }
        }

        [Display(Name = "Οδός")]
        public string StreetName { get; set; }

        // Class field
        private List<SelectListItem> mStreetNames;

        // Class Property
        public List<SelectListItem> StreetNames
        {
            get
            {
                if (mStreetNames == null)
                {
                    mStreetNames = IncidentProvider.GetIncidentStreetNames(Municipality);

                    // 08.03.2018, Andreas Kasapleris
                    // and the empty 'SelectListItem' object to the top of mStreetNames list
                    SelectListItem emptyStreetNames = new SelectListItem();
                    emptyStreetNames.Text = "";
                    emptyStreetNames.Value = "";
                    mStreetNames.Insert(0, emptyStreetNames);
                }
                return mStreetNames;
            }

            set { mStreetNames = value; }
        }

        [Display(Name = "Αριθμός")]
        public string StreetNumber { get; set; }

        //======================================================
        // 06.03.2018, Andreas Kasapleris
        // appropriate extensions to this Class to accomodate
        // search based also on TaskTypes
        //======================================================

        // see also Partial View [Views\Search\TaskTypes.cshtml]
        // it is a ComboBox Partial View
        // the selected value of TaskTypeId will be int
        // define property name with same name as the returned SQL SELECT column name
        [Display(Name = "Εργασία")]
        public int TaskTypeID { get; set; }

        // see also Partial View [Views\Search\TaskTypes.cshtml]
        // it is a ComboBox Partial View
        // the selected value of TaskTypeDescription will be string
        // define property name with same name as the returned SQL SELECT column name
        [Display(Name = "Τύπος Εργασίας")]
        public string TaskType { get; set; }

        // 06.03.2018, Andreas Kasapleris
        // this Class property holds the user selection;
        // namely 'TaskStateDescription' from List 'TaskStates'
        [Display(Name = "Κατάσταση Εργασίας")]
        public string TaskState { get; set; }

        // 06.03.2018, Andreas Kasapleris
        // Class field for Task States: 'Ανοιχτή', 'Ολοκληρωμένη', 'Ακυρωμένη'
        private List<State> _TaskStates;

        // 06.03.2018, Andreas Kasapleris
        // see also Partial View [Views\Report100\TaskTypes.cshtml]
        // it is the Partial View of TaskStates Combo box
        // the selected value of TaskStates will be the string TaskState (defined above)
        // public Class property for TaskStates
        public List<State> TaskStates
        {
            get
            {
                if (_TaskStates == null)
                {
                    _TaskStates = new List<State>
                    {
                        new State
                        {
                            TaskStateDescription = ""
                        },
                        new State
                        {
                            TaskStateDescription = "Ανοιχτή"
                        },
                        new State
                        {
                            TaskStateDescription = "Ολοκληρωμένη"
                        },
                        new State
                        {
                            TaskStateDescription = "Ακυρωμένη"
                        }
                    };
                }

                return _TaskStates;
            }

            set { _TaskStates = value; }
        }


        // Class Property; the UserDepartmentId in which user belongs
        // this property will be set to this 'Report100SearchModel' Class
        // from C# Controller after the instantiation of this Class
        // see Index() action of Controllers\Report100Controller.cs
        public int DepartmentId { get; set; }

        // class field _DepartmentTaskTypes
        private List<TaskType> _DepartmentTaskTypes;

        // Class property DepartmentTaskTypes
        public List<TaskType> DepartmentTaskTypes
        {
            get
            {
                if (_DepartmentTaskTypes == null)
                {
                    // 06.03.2018, Andreas Kasapleris; call your method
                    // to return the user's department task types
                    _DepartmentTaskTypes = TaskTypeProvider
                        .GetAllTaskTypesForDepartment(DepartmentId) as List<TaskType>;

                    // 08.03.2018, Andreas Kasapleris
                    // add the empty 'TaskType' object to the top of _DepartmentTaskTypes list
                    var emptyTaskType = new TaskType
                    {
                        Id = 0,
                        Description = string.Empty
                    };

                    _DepartmentTaskTypes.Insert(0, emptyTaskType);
                }

                return _DepartmentTaskTypes;
            }

            set { _DepartmentTaskTypes = value; }
        }

        [Display(Name = "Κατάσταση")]
        public int Status { get; set; }

        // 06.03.2018, Andreas Kasapleris
        // helper Class to accomodate Task States descriptions
        public class State
        {
            public string TaskStateDescription { get; set; }
        }

        //
        // 07.03.2018, Andreas Kasapleris
        // this part of Class deals with Ergolavoi
        //

        // SectorId will be set from server-side code,
        // in order to find Εργολάβους for a specific Sector
        public int SectorId { get; set; }

        // see also Partial View [Views\Report100\Ergolavoi.cshtml]
        // the selected value of Contractor will be string
        // define property name with same name as the returned SQL SELECT column name
        // holds Contractor selection from ComboBox View
        [Display(Name = "Εργολάβος")]
        public string Contractor { get; set; }

        // Class field
        private List<Ergolavos> _Ergolavoi;

        // Class property
        public List<Ergolavos> Ergolavoi
        {
            get
            {
                if (_Ergolavoi == null)
                {
                    // find Εργολάβους for a specific Sector
                    _Ergolavoi = IncidentProvider.GetErgolavoi(SectorId);

                    // 08.03.2018, Andreas Kasapleris
                    // and the empty 'Ergolavos' object to the top of mErgolavoi list
                    var emptyErgolavos = new Ergolavos
                    {
                        ErgolavosId = 0,
                        ErgName = ""
                    };

                    _Ergolavoi.Insert(0, emptyErgolavos);
                }

                return _Ergolavoi;
            }

            set { _Ergolavoi = value; }
        }
    }
}
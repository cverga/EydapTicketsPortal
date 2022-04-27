using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DevExpress.Web;
using DevExpress.Web.Mvc;
using EydapTickets.Models;

namespace EydapTickets.Helpers
{
    public static class ValidationsHelper
    {
        //
        // Validation for Department (Department Model)
        //
        private static ValidationSettings _departmentValidationSettings;

        public static ValidationSettings DepartmentValidationSettings
        {
            get
            {
                if (_departmentValidationSettings == null)
                {
                    _departmentValidationSettings = ValidationSettings.CreateValidationSettings(null);
                    _departmentValidationSettings.Display = Display.Dynamic;
                    _departmentValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    _departmentValidationSettings.ErrorText = "Department Name is required.";
                }
                return _departmentValidationSettings;
            }
        }
    }
}
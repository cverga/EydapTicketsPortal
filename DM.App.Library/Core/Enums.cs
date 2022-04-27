using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.App.Library.Core
{
    public class Enums
    {
        public enum FieldStates
        {
            Readonly = 1,
            Editable,
            Hidden,
            Unavailable
        }

        public enum FormStates
        {
            New = 1,
            Edit,
            View,
            ViewEmbedded,
            List
        }

        public enum DataSourceTypes
        {
            None = 1,
            ListValues,
            WS,
            REST,
            Proxy,
            DBQuery
        }

        public enum ErrorNumbers
        {
            OK = 0,
            ItemDoesNotExist = -100,
            InvalidArguments = -200,
            UnexpectedReturnedValue = -300,
            GeneralError = -10000
        }

        public enum RowStatus
        {
            OK = 0,
            Deleted = -1000,
        }

        public enum RequestOrderByFields
        {
            KeepDatabaseOrder = 0,
            ByStatus,
            ByArea
        }

    }
}
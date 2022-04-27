using System;
using System.Web.Script.Serialization;

namespace EydapTickets.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }
}
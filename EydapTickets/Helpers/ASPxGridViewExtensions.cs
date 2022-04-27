using DevExpress.Utils.Extensions;
using DevExpress.Web;

namespace EydapTickets.Helpers
{
    // ReSharper disable once InconsistentNaming
    public static class ASPxGridViewExtensions
    {
        /// <summary>
        /// Returns the values of the specified data source fields within the specified row.
        /// </summary>
        /// <param name="gridView">The grid view from which to get row values.</param>
        /// <param name="visibleIndex">An integer value that identifies the data row.</param>
        /// <param name="fieldNames">The names of data source fields whose values within the specified row are returned.</param>
        /// <returns>An object which is an array of field values (if several field names are passed via the <i>fieldNames</i> parameter) or a direct field value (if a single field name is passed via the <i>fieldNames</i> parameter).</returns>
        public static TResult GetRowValues<TResult>(this ASPxGridView gridView, int visibleIndex, params string[] fieldNames)
        {
            var result = gridView
                .GetRowValues(visibleIndex, fieldNames);

            return result != null
                ? result.CastTo<TResult>()
                : default(TResult);
        }

        /// <summary>
        /// Returns the specified row's values displayed within the specified columns (fields).
        /// </summary>
        /// <param name="gridView">The grid view from which to get row values.</param>
        /// <param name="keyValue">An object that uniquely identifies the row.</param>
        /// <param name="fieldNames">The names of data source fields whose values are returned.</param>
        /// <returns>An object that contains the row values displayed within the specified columns (fields).</returns>
        public static TResult GetRowValuesByKeyValue<TResult>(this ASPxGridView gridView, object keyValue, params string[] fieldNames)
        {
            var result = gridView
                .GetRowValuesByKeyValue(keyValue, fieldNames);

            return result != null
                ? result.CastTo<TResult>()
                : default(TResult);
        }
    }
}

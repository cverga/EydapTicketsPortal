using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DM.App.Library.Core
{
    public static class HtmlFieldExtensions
    {
        public static MvcHtmlString HierarchyFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var htmlAttributes = new Dictionary<string, object>
                {
                    { "readonly", "readonly" },
                    { "class", "lockedField amountField" },
                };

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var value = string.Format("{0}", metadata.Model);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            return htmlHelper.TextBox(fullHtmlFieldName, value, htmlAttributes);
        }
    }
}
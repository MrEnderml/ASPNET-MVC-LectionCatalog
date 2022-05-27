using LectionCatalog.Data.Static;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Web.Mvc;

namespace LectionCatalog.Data.Helpers
{
    public static class PagingHelper
    {
        public static IHtmlContent PageLinks(this IHtmlHelper htmlHelper, PageInfo pageInfo, Func<int, string> pageUrl)
		{
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                System.Web.Mvc.TagBuilder tag = new System.Web.Mvc.TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return new HtmlString(result.ToString());
        }
    }
}

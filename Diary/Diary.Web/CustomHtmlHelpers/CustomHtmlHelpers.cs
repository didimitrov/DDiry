using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Diary.Web.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString StarRate(this HtmlHelper helper, int rate,int maxRate)
        {
            var starRate = new StringBuilder();
            for (int counter = 1; counter <= maxRate; counter++) {
                var tb = new TagBuilder("img");
                if (counter <= rate)
                {
                    tb.Attributes.Add("src", "/Content/Images/full_star.png");
                }
                else {
                    tb.Attributes.Add("src", "/Content/Images/empty_star.png");
                }
                tb.Attributes.Add("id", "str" + counter);
                tb.Attributes.Add("data-number",counter.ToString());
                tb.Attributes.Add("class", "RateStare");
                starRate.Append(tb.ToString(TagRenderMode.SelfClosing));
            }
                return new MvcHtmlString(starRate.ToString());
        }
    }
}
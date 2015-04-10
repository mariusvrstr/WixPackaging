
namespace Spike.Web.HtmlHelper
{
    using System.Web;

    public static class HtmlHelperExtensions
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;

            var appUrl = (string.IsNullOrEmpty(HttpRuntime.AppDomainAppVirtualPath)
                ? string.Empty
                : HttpRuntime.AppDomainAppVirtualPath);

            var test = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return test;
        }
    }
}

namespace Spike.Web.HtmlHelper
{
    using System.Web;

    public static class HtmlHelperExtensions
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var response = request.Url.Scheme
                   + "://" + request.Url.Authority
                   + ((request.ApplicationPath == null) ? string.Empty : request.ApplicationPath.TrimEnd('/'));

            return response;
        }
    }
}
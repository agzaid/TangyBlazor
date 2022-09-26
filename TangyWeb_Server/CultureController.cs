using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TangyWeb_Server
{
    [Route("[controller]/[action]")]
    public class CultureController : ControllerBase
    {
        public IActionResult Set(string culture, string redirectUri)
        {
            if (culture != null)
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(
                        new RequestCulture(culture, culture)));
            }

            return LocalRedirect(redirectUri);
        }

        //[HttpGet]
        //public IActionResult SetCulture()
        //{
        //    var culture = HttpContext.Features.Get<IRequestCultureFeature>();
        //    Response.Cookies.Append(
        //        CookieRequestCultureProvider.DefaultCookieName,
        //        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(new string[] { "en-US", "fr-FR" }.Where(s => s != culture.RequestCulture.Culture.Name).FirstOrDefault()))
        //        );

        //    return Redirect("/");
        //}
    }
}

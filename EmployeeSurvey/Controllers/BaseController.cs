using EmployeeSurvey.LocalizationProvider;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeSurvey.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ChangeCulture(string Culture = CultureHelper.DefaultCulture)
        {
            if (CultureHelper.GetCultureInfo(Culture, out CultureInfo cultureInfo))
            {
                Session["CurrentCulture"] = cultureInfo.Name;

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }            

            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session == null || Session["CurrentCulture"] == null)
                Session["CurrentCulture"] = CultureHelper.DefaultCulture;

            Thread.CurrentThread.CurrentCulture = new CultureInfo((string)Session["CurrentCulture"]);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}
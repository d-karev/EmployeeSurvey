using EmployeeSurvey.Service;
using System.Web.Mvc;

namespace EmployeeSurvey.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View(StatisticsService.GetCharts());
        }
    }
}
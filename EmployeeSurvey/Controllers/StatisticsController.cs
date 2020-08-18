using EmployeeSurvey.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EmployeeSurvey.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Statistics
        public ActionResult Index()
        {
            var model = StatisticsService.GetCharts();

            

            return View(model);
        }
    }
}
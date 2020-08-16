using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSurvey.MVC.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult New()
        {
            return View();
        }
    }
}
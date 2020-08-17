using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSurvey.MVC.Controllers
{
    public class SurveyController : BaseController
    {
        // GET: Survey
        public ActionResult New()
        {
            return View();
        }
    }
}
using EmployeeSurvey.PresentationData.ViewModels;
using EmployeeSurvey.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSurvey.Controllers
{
    public class SurveyController : BaseController
    {
        // GET: Survey
        public ActionResult New()
        {
            var model = new SurveyNewViewModel();
            model.NomenKnownLanguages = ProgrammingLanguageService.GetAllLanguages();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(SurveyNewViewModel model)
        {
            
            return RedirectToAction("New");
        }
    }
}
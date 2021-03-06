﻿using EmployeeSurvey.PresentationData.ViewModels;
using EmployeeSurvey.Service;
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
            if (EmployeeSurveyService.IsNewEmployeeValid(model.Survey) == EmployeeSurveyService.EmployeeValidityCheckResult.Ok)
                EmployeeSurveyService.PersistNewEmployeeSurvey(model.Survey);

            return RedirectToAction("Index", "Statistics");
        }
    }
}
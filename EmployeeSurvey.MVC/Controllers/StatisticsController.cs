﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSurvey.MVC.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels = EmployeeSurvey.PresentationData.ViewModels;
using EmployeeSurvey.PersistentData.Model;
using System.Web.Script.Serialization;

namespace EmployeeSurvey.Service
{
    public static class EmployeeSurveyService
    {
        public static EmployeeValidityCheckResult IsNewEmployeeValid(ViewModels.EmployeeSurvey Survey)
        {
            if (Survey == null 
                || string.IsNullOrEmpty(Survey.Email) 
                || string.IsNullOrEmpty(Survey.NameFirst)
                || string.IsNullOrEmpty(Survey.NameLast))
                return EmployeeValidityCheckResult.BadInputData;

            using (var db = new EmployeeSurveyModelContainer())
            {
                var employeeExists = db.EmployeeSet.Where(e => e.Email == Survey.Email).Any();

                if (employeeExists)
                    return EmployeeValidityCheckResult.EmployeeAlreadyExists;
            }

            return EmployeeValidityCheckResult.Ok;
        }

        public static void PersistNewEmployeeSurvey(ViewModels.EmployeeSurvey Survey)
        {
            var serializer = new JavaScriptSerializer();
            var knownLanguages = serializer.Deserialize<List<ViewModels.KnownLanguage>>(Survey.KnownLanguagesJson);

            using (var db = new EmployeeSurveyModelContainer())
            {
                var dbEmployee = new Employee();
                dbEmployee.NameFirst = Survey.NameFirst;
                dbEmployee.NameLast = Survey.NameLast;
                dbEmployee.Email = Survey.Email;

                dbEmployee.Survey = new Survey();
                dbEmployee.Survey.CurrentPosition = Survey.CurrentPosition;
                dbEmployee.Survey.ExperienceYears = Survey.ExperienceYears;

                foreach (var knownLang in knownLanguages)
                {
                    var progLang = ProgrammingLanguageService.GetProgrammingLanguage(knownLang.LanguageId);
                    db.ProgrammingLanguageSet.Attach(progLang);

                    dbEmployee.Survey.KnownLanguages.Add(new KnownLanguage
                    {
                        SeniorityLevel = (int)knownLang.SeniorityLevel,
                        Survey = dbEmployee.Survey,
                        ProgrammingLanguage = progLang
                    });
                }

                db.EmployeeSet.Add(dbEmployee);
                db.SaveChanges();

                /*
                foreach (var asd in db.EmployeeSet)
                {
                    var survey = asd.Survey;
                    foreach(var qwe in survey.KnownLanguages)
                    {
                        var lang = qwe.ProgrammingLanguage.Name;
                    }
                }
                */
            }
        }

        public enum EmployeeValidityCheckResult
        {
            Ok,
            EmployeeAlreadyExists,
            BadInputData
        }
    }
}

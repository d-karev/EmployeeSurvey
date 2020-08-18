using EmployeeSurvey.PersistentData.Model;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSurvey.Service
{
    public static class ProgrammingLanguageService
    {
        public static Dictionary<int, string> GetAllLanguages()
        {
            var resultList = new Dictionary<int, string>();

            using (var db = new EmployeeSurveyModelContainer())
            {
                var dbLangs = db.ProgrammingLanguageSet.ToList();

                foreach (var dbLang in dbLangs)
                    resultList.Add(dbLang.Id, dbLang.Name);
            }

            return resultList;
        }
    }
}

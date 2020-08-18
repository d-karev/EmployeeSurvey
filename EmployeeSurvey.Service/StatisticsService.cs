using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels = EmployeeSurvey.PresentationData.ViewModels;
using EmployeeSurvey.PersistentData.Model;
using EmployeeSurvey.PresentationData.Enums;
using System.Web.Script.Serialization;

namespace EmployeeSurvey.Service
{
    public static class StatisticsService
    {
        public static ViewModels.StatisticsIndexViewModel GetCharts()
        {
            return new ViewModels.StatisticsIndexViewModel
            {
                DatapointDictionary = new Dictionary<SeniorityLevel, string>
                {
                    { SeniorityLevel.Junior, GetChartData(SeniorityLevel.Junior) },
                    { SeniorityLevel.Mid, GetChartData(SeniorityLevel.Mid) },
                    { SeniorityLevel.Senior, GetChartData(SeniorityLevel.Senior) }
                }
            };
        }

        private static string GetChartData(SeniorityLevel Level)
        {
            using (var db = new EmployeeSurveyModelContainer())
            {
                var total = db.KnownLanguageSet
                    .Where(l => l.SeniorityLevel == (int)Level)
                    .Count() / 100.0;

                var seniorityStats = db.KnownLanguageSet
                    .Where(l => l.SeniorityLevel == (int)Level)
                    .GroupBy(l => l.ProgrammingLanguage.Name)
                    .Select(l => new ViewModels.DataPoint { name = l.Key, y = l.Count() / total });

                var serializer = new JavaScriptSerializer();

                return serializer.Serialize(seniorityStats.ToList());
            }
        }
    }
}

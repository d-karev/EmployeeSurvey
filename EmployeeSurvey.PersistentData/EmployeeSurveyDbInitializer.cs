using EmployeeSurvey.PersistentData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSurvey.PersistentData
{
    public class EmployeeSurveyDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<EmployeeSurveyModelContainer>
    {
        protected override void Seed(EmployeeSurveyModelContainer context)
        {
            var Languages = new List<ProgrammingLanguage>
            {
                new ProgrammingLanguage { Name = "C" },
                new ProgrammingLanguage { Name = "C++" },
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "VB.NET" },
                new ProgrammingLanguage { Name = "Delphi" },
                new ProgrammingLanguage { Name = "Python" },
                new ProgrammingLanguage { Name = "Perl" },
                new ProgrammingLanguage { Name = "Ruby" },
                new ProgrammingLanguage { Name = "SQL" },
                new ProgrammingLanguage { Name = "Java" }
            };

            Languages.ForEach(lang => context.ProgrammingLanguageSet.Add(lang));
            context.SaveChanges();
        }
    }
}

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
                new ProgrammingLanguage { Name = "Java" },
                new ProgrammingLanguage { Name = "Clojure" },
                new ProgrammingLanguage { Name = "Powershell" },
                new ProgrammingLanguage { Name = "Lisp" }
            };

            Languages.ForEach(lang => context.ProgrammingLanguageSet.Add(lang));
            context.SaveChanges();

            var Employees = new List<Employee>
            {
                new Employee
                {
                    NameFirst = "Georgi",
                    NameLast = "Mihailov",
                    Email = "g.mihailov@company.org",                    
                    Survey = new Survey
                    {
                        CurrentPosition = "Backend",
                        ExperienceYears = 4
                    }                    
                },
                new Employee
                {
                    NameFirst = "Alexander",
                    NameLast = "Ivanov",
                    Email = "alex.ivanov@company.org",
                    Survey = new Survey
                    {
                        CurrentPosition = "Full-stack",
                        ExperienceYears = 6
                    }
                },
                new Employee
                {
                    NameFirst = "Anna",
                    NameLast = "Borisova",
                    Email = "a.borisova@company.org",
                    Survey = new Survey
                    {
                        CurrentPosition = "Frontend",
                        ExperienceYears = 3
                    }
                }
            };

            Employees[0].Survey.KnownLanguages = new List<KnownLanguage>
            {
                new KnownLanguage
                {
                    SeniorityLevel = 2,
                    Survey = Employees[0].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 2,
                    Survey = Employees[0].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 3,
                    Survey = Employees[0].Survey
                }
            };

            Employees[1].Survey.KnownLanguages = new List<KnownLanguage>
            {
                new KnownLanguage
                {
                    SeniorityLevel = 1,
                    Survey = Employees[1].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 2,
                    Survey = Employees[1].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 3,
                    Survey = Employees[1].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 3,
                    Survey = Employees[1].Survey
                }
            };

            Employees[2].Survey.KnownLanguages = new List<KnownLanguage>
            {
                new KnownLanguage
                {
                    SeniorityLevel = 1,
                    Survey = Employees[2].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 1,
                    Survey = Employees[2].Survey
                },
                new KnownLanguage
                {
                    SeniorityLevel = 2,
                    Survey = Employees[2].Survey
                }
            };

            var random = new Random();

            foreach (var employee in Employees)
                foreach (var knownLang in employee.Survey.KnownLanguages)
                {
                    var randomId = random.Next(1, 13);
                    var lang = context.ProgrammingLanguageSet.First(l => l.Id == randomId);
                    context.ProgrammingLanguageSet.Attach(lang);
                    knownLang.ProgrammingLanguage = lang;
                }

            Employees.ForEach(e => context.EmployeeSet.Add(e));
            context.SaveChanges();
        }
    }
}

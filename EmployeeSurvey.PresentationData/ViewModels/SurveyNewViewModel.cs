using EmployeeSurvey.PresentationData.Enums;
using LocalizationResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeSurvey.PresentationData.ViewModels
{
    public class SurveyNewViewModel
    {
        public EmployeeSurvey Survey { get; set; }
        public Dictionary<int, string> NomenKnownLanguages { get; set; }

        public SurveyNewViewModel()
        {
            Survey = new EmployeeSurvey();
            NomenKnownLanguages = new Dictionary<int, string>();
        }
    }

    public class EmployeeSurvey
    {
        [Required]
        [Display(Name = "EmployeeNameFirst", ResourceType = typeof(Localization))]
        public string NameFirst { get; set; }

        [Required]
        [Display(Name = "EmployeeNameLast", ResourceType = typeof(Localization))]
        public string NameLast { get; set; }

        [Required]
        [Display(Name = "EmployeeEmail", ResourceType = typeof(Localization))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "EmployeeExperienceYears", ResourceType = typeof(Localization))]
        public int ExperienceYears { get; set; }

        [Required]
        [Display(Name = "EmployeeCurrentPosition", ResourceType = typeof(Localization))]
        public string CurrentPosition { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public string KnownLanguagesJson { get; set; }

        public List<KnownLanguage> KnownLanguages { get; set; }

        public EmployeeSurvey()
        {
            KnownLanguages = new List<KnownLanguage>();
        }
    }

    public class KnownLanguage
    {
        public int LanguageId { get; set; }
        public SeniorityLevel SeniorityLevel { get; set; }
    }
}
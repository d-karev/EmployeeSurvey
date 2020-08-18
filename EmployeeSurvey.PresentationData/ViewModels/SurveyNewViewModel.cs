using EmployeeSurvey.PresentationData.Enums;
using LocalizationResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100)]
        [Display(Name = "EmployeeNameFirst", ResourceType = typeof(Localization))]
        public string NameFirst { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "EmployeeNameLast", ResourceType = typeof(Localization))]
        public string NameLast { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "EmployeeEmail", ResourceType = typeof(Localization))]
        public string Email { get; set; }

        [Range(0, 50, ErrorMessageResourceName ="ValidationError", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "EmployeeExperienceYears", ResourceType = typeof(Localization))]
        public int ExperienceYears { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "EmployeeCurrentPosition", ResourceType = typeof(Localization))]
        public string CurrentPosition { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public string KnownLanguagesJson { get; set; }

        /*
        public List<KnownLanguage> KnownLanguages { get; set; }

        public EmployeeSurvey()
        {
            KnownLanguages = new List<KnownLanguage>();
        }
        */
    }

    public class KnownLanguage
    {
        public int LanguageId { get; set; }
        public SeniorityLevel SeniorityLevel { get; set; }
    }
}
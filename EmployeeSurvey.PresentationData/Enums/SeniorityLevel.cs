using LocalizationResources;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSurvey.PresentationData.Enums
{
    public enum SeniorityLevel
    {
        [Display(Name = "SeniorityLevelJunior", ResourceType = typeof(Localization))]
        Junior = 1,

        [Display(Name = "SeniorityLevelMid", ResourceType = typeof(Localization))]
        Mid,

        [Display(Name = "SeniorityLevelSenior", ResourceType = typeof(Localization))]
        Senior
    }
}

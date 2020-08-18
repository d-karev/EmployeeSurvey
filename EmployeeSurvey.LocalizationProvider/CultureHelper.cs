using System.Globalization;
using System.Linq;

namespace EmployeeSurvey.LocalizationProvider
{
    public class CultureHelper
    {
        public const string DefaultCulture = "en-US";

        private static readonly string[] allowedCultures = new string[] {
            DefaultCulture,
            "bg-BG"
        };        

        public static bool IsCultureValid(string Culture)
        {
            if (string.IsNullOrEmpty(Culture))
                return false;

            return allowedCultures.Contains(Culture);
        }

        public static bool GetCultureInfo(string Culture, out CultureInfo CultureObject)
        {
            if (!IsCultureValid(Culture))
            {
                CultureObject = new System.Globalization.CultureInfo(DefaultCulture);
                return false;
            }

            CultureObject = new System.Globalization.CultureInfo(Culture);
            return true;
        }
    }
}
using EmployeeSurvey.PresentationData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSurvey.PresentationData.ViewModels
{
    public class StatisticsIndexViewModel
    {
        public Dictionary<SeniorityLevel, string> DatapointDictionary { get; set; }
    }

    public class DataPoint
    {
        [DataMember(Name = "name")]
        public string name = "";

        [DataMember(Name = "y")]
        public Nullable<double> y = null;

    }
}

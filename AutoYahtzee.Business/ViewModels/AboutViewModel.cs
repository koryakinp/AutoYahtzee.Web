using AutoYahtzee.Business.DTO;
using System.Collections.Generic;

namespace AutoYahtzee.Business.ViewModels
{
    public class AboutViewModel
    {
        public int NumberOfYahtzees { get; set; }
        public int NumberOfAttempts { get; set; }
        public List<YahtzeeSummary> YahtzeeSummary { get; set; }
    }
}

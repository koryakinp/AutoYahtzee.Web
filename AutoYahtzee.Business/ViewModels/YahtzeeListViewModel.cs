using AutoYahtzee.Business.DTO;
using System.Collections.Generic;

namespace AutoYahtzee.Business.ViewModels
{
    public class YahtzeeListViewModel
    {
        public readonly int NumberOfDices;
        public readonly List<YahtzeeDto> Yahtzees;

        public YahtzeeListViewModel(List<YahtzeeDto> yahtzees)
        {
            Yahtzees = yahtzees;
        }
    }
}

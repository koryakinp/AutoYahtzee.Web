using System.Collections.Generic;

namespace AutoYahtzee.Business.DTO
{
    public class YahtzeeDto
    {
        public readonly int NumberOfDices;
        public readonly List<ThrowDto> Throws;

        public YahtzeeDto(List<ThrowDto> throws, int numberOfDices)
        {
            Throws = throws;
            NumberOfDices = numberOfDices;
        }
    }
}

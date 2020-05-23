using System;
using System.Collections.Generic;
using System.Text;

namespace AutoYahtzee.Data.Models
{
    public class YahtzeeResult
    {
        public Guid ThrowId { get; set; }
        public DateTime DateCreated { get; set; }
        public byte Prediction { get; set; }
    }
}

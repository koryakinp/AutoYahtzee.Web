using System;

namespace AutoYahtzee.Data.Models
{
    public partial class Predictions
    {
        public Guid Id { get; set; }
        public Guid ThrowId { get; set; }
        public byte Prediction { get; set; }
        public double Confidence { get; set; }

        public virtual Throws Throw { get; set; }
    }
}

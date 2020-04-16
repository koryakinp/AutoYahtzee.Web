using System;

namespace AutoYahtzee.Data.Models
{
    public partial class Throw
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Result { get; set; }
        public Guid ExperimentId { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public int ThrowNumber { get; internal set; }
        public DateTime? ResultProcessedDate { get; set; }
        public virtual Experiment Experiment { get; set; }
    }
}

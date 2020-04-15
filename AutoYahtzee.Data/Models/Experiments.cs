using System;
using System.Collections.Generic;

namespace AutoYahtzee.Data.Models
{
    public partial class Experiment
    {
        public Experiment()
        {
            Throws = new HashSet<Throw>();
        }

        public Guid Id { get; set; }
        public DateTime DateStarted { get; set; }
        public string Description { get; set; }
        public int NumberOfDices { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Throw> Throws { get; set; }
    }
}

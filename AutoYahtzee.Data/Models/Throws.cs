using System;
using System.Collections.Generic;

namespace AutoYahtzee.Data.Models
{
    public partial class Throws
    {
        public Throws()
        {
            Predictions = new HashSet<Predictions>();
        }

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int ThrowNumber { get; set; }

        public virtual ICollection<Predictions> Predictions { get; set; }
    }
}

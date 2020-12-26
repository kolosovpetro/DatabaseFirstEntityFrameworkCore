using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.SqlServer.SqlServerScaffold
{
    public partial class Movie
    {
        public Movie()
        {
            Copies = new HashSet<Copy>();
            Starrings = new HashSet<Starring>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int AgeRestriction { get; set; }
        public float Price { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
        public virtual ICollection<Starring> Starrings { get; set; }
    }
}

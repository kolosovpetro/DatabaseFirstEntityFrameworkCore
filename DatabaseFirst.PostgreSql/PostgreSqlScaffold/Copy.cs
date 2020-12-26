﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.PostgreSql.PostgreSqlScaffold
{
    public partial class Copy
    {
        public Copy()
        {
            Rentals = new HashSet<Rental>();
        }

        public int CopyId { get; set; }
        public bool Available { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}

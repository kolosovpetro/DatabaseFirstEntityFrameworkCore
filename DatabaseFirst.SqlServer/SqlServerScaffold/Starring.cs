using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.SqlServer.SqlServerScaffold
{
    public partial class Starring
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.SqlServer.SqlServerScaffold
{
    public partial class Actor
    {
        public Actor()
        {
            Starrings = new HashSet<Starring>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Starring> Starrings { get; set; }
    }
}

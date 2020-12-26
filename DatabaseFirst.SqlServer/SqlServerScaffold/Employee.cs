using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.SqlServer.SqlServerScaffold
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float? Salary { get; set; }
        public string City { get; set; }
    }
}

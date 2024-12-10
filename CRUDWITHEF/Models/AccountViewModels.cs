using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }

        public class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }
    }
}

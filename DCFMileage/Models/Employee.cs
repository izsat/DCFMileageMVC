using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCFMileage.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee Supervisor { get; set; }
        public ICollection<Trip> Mileages { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCFMileage.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public int StartMileage { get; set; }

        public int EndMileage { get; set; }

        public virtual Location StartLocation { get; set; }
        public virtual Location EndLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Purpose { get; set; }
        public Employee Employee { get; set; }
    }
}
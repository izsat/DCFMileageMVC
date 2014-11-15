﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCFMileage.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
    }
}
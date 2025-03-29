﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Access.Entity
{
    public class Customer
    {
        public required string CustomerID { get; set; }

        public required string CustomerName { get; set; }

        public required string ContactName { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public string? Region { get; set; }

        public required string PostalCode { get; set; }

        public required string Country { get; set; }

        public required string Phone { get; set; }

        public string? Fax { get; set; }
    }
}

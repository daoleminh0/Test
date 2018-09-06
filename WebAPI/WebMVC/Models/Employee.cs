﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public partial class Employee
    {
        [DisplayName("ID")]
        [Required]
        public string id { get; set; }
        [Required]
        [DisplayName("Fullname")]
        public string fullname { get; set; }
        [Required]
        [DataType(DataType.Date)]

        [DisplayName("Birthday")]
        public System.DateTime birthday { get; set; }
        [Required]
        [DisplayName("Gender")]
        public bool gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string phone { get; set; }
        [Required]
        [DisplayName("Address")]
        public string address { get; set; }
    }
}
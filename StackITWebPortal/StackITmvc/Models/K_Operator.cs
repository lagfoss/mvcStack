﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class K_Operator
    {
        public int K_OperatorId { get; set; }

        [Required,
        StringLength(50),
        Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required,
        StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters."),
        Column("FirstName"),
        Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [Display(Name = "Company")]
        public int CustomerId { get; set; }

        public Customer Company { get; set; }

        [Display(Name = "Phone No."),
        DataType(DataType.PhoneNumber),
        StringLength(20)]
        public string PhoneNo { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<K_OperatorSubscriptions> K_OperatorSubscriptions { get; set; }
    }
}

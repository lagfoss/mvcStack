using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Display(Name = "Company Name")]
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string CompanyName { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        public string VAT { get; set; }

        [Display(Name = "Street Name")]
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string StreetName { get; set; }

        [Display(Name = "Street No.")]
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string StreetNo { get; set; }

        [Display(Name = "Postal Code")]
        [Column(TypeName = "varchar(20)")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string PostalCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Phone No.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required]
        public string PhoneNo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

}

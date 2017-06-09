using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class LoanTaker
    {
        [Key]
        public int ID { get; set; }
        public string MembershipNumber { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
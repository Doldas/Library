using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class Loan
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public bool IsReturned { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual ICollection<Book> Books { get; set; }
        [ForeignKey("LoanTaker")]
        public int LoanTakerID { get; set; }
        public virtual LoanTaker LoanTaker { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
namespace LibraryMVC.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Condition { get; set; }
        public bool IsRented { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [StringLength(2,ErrorMessage="Please use two character country code")]
        public string Nation {get; set;}
        public bool IsAlive { get; set; }
        public bool HasNobelPrize { get; set; }
        
    }
}
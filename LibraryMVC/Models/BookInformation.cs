using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class BookInformation
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int PublishedYear { get; set; }
    }
    public enum Category
    {
        Scifi,
        Adventure,
        Romance,
        Biography,
        Nature,
        NonFiction
    }
}
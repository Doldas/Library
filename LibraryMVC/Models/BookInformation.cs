using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Models
{
    public class BookInformation
    {
        [Key]
        //[Key, ForeignKey("Book")] 1 - 1
        public int ID { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int PublishedYear { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Author> Authors { get; set; }  
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
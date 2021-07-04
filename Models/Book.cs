using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public short Rating { get; set; } 
    }
}

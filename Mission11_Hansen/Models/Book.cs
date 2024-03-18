using System.ComponentModel.DataAnnotations;

namespace Mission11_Hansen.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public required string Publisher { get; set; }

        public required string ISBN { get; set; }

        public required string Classification { get; set; }

        public required string Category { get; set; }

        public required int PageCount { get; set; }

        public required float Price { get; set; }

    }
}

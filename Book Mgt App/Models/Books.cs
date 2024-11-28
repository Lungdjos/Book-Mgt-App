using System.ComponentModel.DataAnnotations;

namespace Book_Mgt_App.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
    }
}

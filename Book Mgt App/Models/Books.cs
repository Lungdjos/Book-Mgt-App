namespace Book_Mgt_App.Models
{
    public class Books
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
    }
}

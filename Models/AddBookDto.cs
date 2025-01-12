namespace LibEaseAPI.Models
{
    public class AddBookDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

    }
}

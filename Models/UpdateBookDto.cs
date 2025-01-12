namespace LibEaseAPI.Models
{
    public class UpdateBookDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        //public string Genre { get; set; }
        //public int PublicationYear { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

        public UpdateBookDto() {
            AddedDate = DateTime.Now;
        }

    }
}

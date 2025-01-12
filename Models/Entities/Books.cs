namespace LibEaseAPI.Models.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        //public string Genre { get; set; }
        //public int PublicationYear { get; set; }
        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public Book()
        {
            AddedDate = DateTime.Now;
        }


    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace LibEaseAPI.Models
{
    public class AddBookDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        public AddBookDto()
        {
            AddedDate = DateTime.Now;
        }

    }
}

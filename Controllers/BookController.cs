using LibEaseAPI.Models;
using LibEaseAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibEaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BookController(BookDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var AllBooks = await dbContext.Books.Select(x => new Book()
            {
                BookId = x.BookId,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                AddedDate = x.AddedDate,
                ImageName = x.ImageName,
                ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName),

            }).ToListAsync();

            return Ok(AllBooks);

        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromForm] AddBookDto addBookDto)
        {
            if (addBookDto == null || addBookDto.ImageFile == null)
            {
                return BadRequest("Invalid book data or missing image file.");
            }

            try
            {
                addBookDto.ImageName = await SaveImage(addBookDto.ImageFile);

                var bookEntity = new Book()
                {
                    Title = addBookDto.Title,
                    Author = addBookDto.Author,
                    Description = addBookDto.Description,
                    AddedDate = addBookDto.AddedDate,
                    ImageName = addBookDto.ImageName
                };

                await dbContext.Books.AddAsync(bookEntity);
                await dbContext.SaveChangesAsync();

                return Ok(bookEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{BookId:guid}")]
        public async Task<IActionResult> GetBookById(Guid BookId)
        {
            var book = await dbContext.Books
                .Where(x => x.BookId == BookId)
                .Select(x => new Book()
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    AddedDate = x.AddedDate,
                    ImageName = x.ImageName,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName),
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound(new { message = "Book not found." });
            }

            return Ok(book);
        }


        [HttpPut]
        [Route("{BookId:guid}")]
        public async Task<IActionResult> UpdateBookAsync(Guid BookId, [FromForm] UpdateBookDto updateBookDto)
        {
            if (updateBookDto == null)
            {
                return BadRequest("Invalid update data.");
            }

            var book = await dbContext.Books.FindAsync(BookId);
            if (book == null)
            {
                return NotFound(new { message = "Book not found." });
            }

            try
            {
                // Update other properties
                book.Title = updateBookDto.Title;
                book.Author = updateBookDto.Author;
                book.Description = updateBookDto.Description;
                book.AddedDate = updateBookDto.AddedDate;

                // Check if a new image file is provided
                if (updateBookDto.ImageFile != null)
                {
                    // Delete the existing image
                    DeleteImage(book.ImageName);

                    // Save the new image
                    string newImageName = await SaveImage(updateBookDto.ImageFile);
                    book.ImageName = newImageName; // Update the image name in the entity
                }

                dbContext.Books.Update(book);
                await dbContext.SaveChangesAsync();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{BookId:guid}")]
        public IActionResult DeleteBook(Guid BookId)
        {
            var book = dbContext.Books.Find(BookId);
            if (book == null)
            {
                return NotFound(new { message = "Book not found." });
            }

            try
            {
                DeleteImage(book.ImageName);
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
                return Ok(new { message = "Book deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            if (imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile), "Image file cannot be null.");
            }

            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

            var imageDirectory = Path.Combine(_hostEnvironment.ContentRootPath, "Images");
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            var imagePath = Path.Combine(imageDirectory, imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}

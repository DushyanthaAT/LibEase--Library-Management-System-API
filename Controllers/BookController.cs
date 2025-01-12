using LibEaseAPI.Models;
using LibEaseAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibEaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext dbContext;

        public BookController(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks=dbContext.Books.ToList();
            return Ok(allBooks);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto addBookDto) 
        {
            var bookEntity = new Book()
            {
                Title = addBookDto.Title,
                Author = addBookDto.Author,
                //Genre = addBookDto.Genre,
                //PublicationYear = addBookDto.PublicationYear,
                Description = addBookDto.Description,
                AddedDate =addBookDto.AddedDate
            };
            dbContext.Books.Add(bookEntity);
            dbContext.SaveChanges();
            return Ok(bookEntity);
        }

        [HttpGet]
        [Route("{BookId:guid}")]
        public IActionResult GetBookById(Guid BookId) 
        {
            var Book=dbContext.Books.Find(BookId);
            if (Book == null) {
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpPut]
        [Route("{BookId:guid}")]
        public IActionResult UpdateBook(Guid BookId,UpdateBookDto updateBookDto ) 
        { 
          var book =dbContext.Books.Find(BookId);
            if (book == null) 
            {
                return NotFound();
            }

            book.Title = updateBookDto.Title;
            book.Author = updateBookDto.Author;
            //book.Genre = updateBookDto.Genre;
            //book.PublicationYear=updateBookDto.PublicationYear;
            book.Description = updateBookDto.Description;
            book.AddedDate = updateBookDto.AddedDate;

            dbContext.SaveChanges();

            return Ok(book);

        }

        [HttpDelete]
        public IActionResult DeleteBook(Guid BookId) 
        { 
            var book =dbContext.Books.Find(BookId); 
            if (book == null) 
            {
                return NotFound();
            }

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}

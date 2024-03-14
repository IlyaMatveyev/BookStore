using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksSevice _booksSevice;

        public BooksController(IBooksSevice booksSevice)
        {
            _booksSevice = booksSevice;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> Get()
        {
            var books = await _booksSevice.GetAllBooks();


            //маппинг из Core.Book в BooksResponce
            var booksResponse = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

            return Ok(booksResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(), 
                request.Title, 
                request.Description, 
                request.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksSevice.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksSevice.UpdateBook(id, request.Title, request.Description, request.Price);

            return Ok(bookId);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            return Ok(await _booksSevice.DeleteBook(id));
        }
    }
}

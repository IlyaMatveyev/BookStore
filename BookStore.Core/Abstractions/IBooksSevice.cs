using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IBooksSevice
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}
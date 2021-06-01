using System.Threading.Tasks;

using CSharpFunctionalExtensions;

using ServiceTemplate.Domain.Models;

namespace ServiceTemplate.Domain.Interfaces
{
    public interface IBookService
    {
        Task<Result<BooksResponse>> GetBooks();
        Task<Result<BookResponse>> FindBook(string code);
        Task<Result<BookCreatedResponse>> CreateBook(CreateBookRequest request);
        Task<Result> DeleteBook(string code);
    }
}

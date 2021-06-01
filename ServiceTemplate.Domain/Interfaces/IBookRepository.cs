using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using ServiceTemplate.Domain.Entities;

namespace ServiceTemplate.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Result<IEnumerable<BookEntity>>> GetBooks();
        Task<Result<BookEntity>> FindBook(string code);
        Task<Result> CreateBook(BookEntity entity);
        Task<Result> DeleteBook(string code);
    }
}

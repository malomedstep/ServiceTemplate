using System.Linq;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using ServiceTemplate.Domain.Common;
using ServiceTemplate.Domain.Entities;
using ServiceTemplate.Domain.Interfaces;
using ServiceTemplate.Domain.Models;

namespace ServiceTemplate.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IUniqueCodeGenerator _codeGen;
        private readonly IModelConverter<BookEntity, Book> _bookEntityConverter;
        private readonly IModelConverter<(CreateBookRequest request, string code), BookEntity> _createBookRequestConverter;

        public BookService(
            IBookRepository repo,
            IUniqueCodeGenerator codeGen,
            IModelConverter<BookEntity, Book> bookEntityConverter,
            IModelConverter<(CreateBookRequest request, string code), BookEntity> createBookRequestConverter)
        {
            _repo = repo;
            _codeGen = codeGen;
            _bookEntityConverter = bookEntityConverter;
            _createBookRequestConverter = createBookRequestConverter;
        }

        public async Task<Result<BooksResponse>> GetBooks()
        {
            var result = await _repo.GetBooks();

            return result.IsSuccess
                ? Result.Success(new BooksResponse(result.Value.Select(_bookEntityConverter.Convert)))
                : Result.Failure<BooksResponse>(result.Error);
        }

        public async Task<Result<BookResponse>> FindBook(string code)
        {
            var result = await _repo.FindBook(code);

            return result.IsSuccess
                ? Result.Success(new BookResponse(_bookEntityConverter.Convert(result.Value)))
                : Result.Failure<BookResponse>(result.Error);
        }

        public async Task<Result<BookCreatedResponse>> CreateBook(CreateBookRequest request)
        {
            var codeResult = await _codeGen.Generate();

            if (codeResult.IsFailure)
            {
                return Result.Failure<BookCreatedResponse>(codeResult.Error);
            }

            var entity = _createBookRequestConverter.Convert((request, codeResult.Value));

            var result = await _repo.CreateBook(entity);

            return result.IsSuccess
                ? Result.Success<BookCreatedResponse>(new BookCreatedResponse(codeResult.Value))
                : Result.Failure<BookCreatedResponse>(result.Error);
        }

        public async Task<Result> DeleteBook(string code)
        {
            return await _repo.DeleteBook(code);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MongoDB.Driver;
using ServiceTemplate.Domain.Entities;
using ServiceTemplate.Domain.Interfaces;
using ServiceTemplate.Infrastructure.Common;

namespace ServiceTemplate.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<BookEntity>, IBookRepository
    {
        public BookRepository(RepositorySettings<BookRepository> settings) 
            : base(settings){ }

        public async Task<Result<IEnumerable<BookEntity>>> GetBooks()
        {
            var filter = FilterDefinition<BookEntity>.Empty;
            var entities = await Collection.Find(filter).ToListAsync();

            return Result.Success<IEnumerable<BookEntity>>(entities);
        }

        public async Task<Result<BookEntity>> FindBook(string code)
        {
            var filter = Builders<BookEntity>.Filter.Eq(e => e.Code, code);
            var entity = await Collection.Find(filter).FirstOrDefaultAsync();

            return entity is not null
                ? Result.Success(entity)
                : Result.Failure<BookEntity>("Book not found");
        }

        public async Task<Result> CreateBook(BookEntity entity)
        {
            try
            {
                await Collection.InsertOneAsync(entity);
                return Result.Success();
            } catch(Exception ex)
            {
                return Result.Failure(ex.ToString());
            }
        }

        public async Task<Result> DeleteBook(string code)
        {
            var filter = Builders<BookEntity>.Filter.Eq(e => e.Code, code);
            var result = await Collection.DeleteOneAsync(filter);

            return result.DeletedCount == 1
                ? Result.Success()
                : Result.Failure<BookEntity>("Failed to delete book");
        }
    }
}
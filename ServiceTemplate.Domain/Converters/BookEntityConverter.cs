using ServiceTemplate.Domain.Common;
using ServiceTemplate.Domain.Entities;
using ServiceTemplate.Domain.Models;

namespace ServiceTemplate.Domain.Converters
{
    public class BookEntityConverter : IModelConverter<BookEntity, Book>
    {
        public Book Convert(BookEntity source)
        {
            return new Book
            {
                Author = source.Author,
                Code = source.Code,
                Title = source.Title,
                Year = source.Year
            };
        }
    }
}

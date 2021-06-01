using ServiceTemplate.Domain.Common;
using ServiceTemplate.Domain.Entities;
using ServiceTemplate.Domain.Models;

namespace ServiceTemplate.Domain.Converters
{
    public class CreateBookRequestConverter : IModelConverter<(CreateBookRequest request, string code), BookEntity>
    {
        public BookEntity Convert((CreateBookRequest request, string code) source)
        {
            return new BookEntity
            {
                Author = source.request.Author,
                Code = source.code,
                Title = source.request.Title,
                Year = source.request.Year
            };
        }
    }
}
using System;
using System.Text.Json.Serialization;

namespace ServiceTemplate.Domain.Models
{
    public class BookResponse
    {
        [JsonPropertyName("item")]
        public Book Item { get; }

        public BookResponse(Book item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }
    }
}

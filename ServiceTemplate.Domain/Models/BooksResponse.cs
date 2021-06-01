using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServiceTemplate.Domain.Models
{
    public class BooksResponse
    {
        private static BooksResponse _empty = new(Array.Empty<Book>());
        public static BooksResponse Empty => _empty;


        [JsonPropertyName("items")]
        public IEnumerable<Book> Items { get; }
        public BooksResponse(IEnumerable<Book> books)
        {
            Items = books ?? throw new ArgumentNullException(nameof(books));
        }
    }
}

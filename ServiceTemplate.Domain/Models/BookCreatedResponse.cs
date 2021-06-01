using System;
using System.Text.Json.Serialization;

namespace ServiceTemplate.Domain.Models
{
    public class BookCreatedResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; }

        public BookCreatedResponse(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}

using System.Text.Json.Serialization;

namespace ServiceTemplate.Domain.Models
{
    public class Book
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}

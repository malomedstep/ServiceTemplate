using MongoDB.Bson.Serialization.Attributes;
using ServiceTemplate.Domain.Common;

namespace ServiceTemplate.Domain.Entities
{
    public class BookEntity : EntityBase
    {
        [BsonElement("code")]
        public string Code { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("year")]
        public int Year { get; set; }
    }
}

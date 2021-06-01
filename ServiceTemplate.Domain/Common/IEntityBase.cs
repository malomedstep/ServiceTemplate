using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceTemplate.Domain.Common
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}
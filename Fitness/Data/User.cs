using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fitness.Data
{
    public class User
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Password { get; set; } = false;
    }
}

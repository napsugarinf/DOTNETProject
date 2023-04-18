using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fitness.Data
{
    public class Gym
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = string.Empty;

        public bool isDeleted { get; set; } = false;
    }
}

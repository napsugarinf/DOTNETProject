using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fitness.Data
{
    public class Sale
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string UserId { get; set; } = string.Empty;
        public string MembershipId { get; set; } = string.Empty;

    }
}

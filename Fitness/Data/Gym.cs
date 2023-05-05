using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fitness.Data
{
    public class Gym
    {

        /*[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();*/

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; } 

        public bool isDeleted { get; set; }
    }
}

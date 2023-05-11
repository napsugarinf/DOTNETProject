using Fitness.Data;
using Fitness.IService;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class GymService : IGymService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Gym> _gymTable = null;

        public GymService() {

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _gymTable = _database.GetCollection<Gym>("Gyms");
        }
        public string Delete(string gymId)
        {
            _gymTable.DeleteOne(x => x.Id == gymId);
            return "Deleted";
        }

        public Gym GetGym(string gymId)
        {
            return _gymTable.Find(x => x.Id == gymId).FirstOrDefault();
        }

        public List<Gym> GetGyms()
        {
            return _gymTable.Find(FilterDefinition<Gym>.Empty).ToList();
        }

        public void SaveOrUpdate(Gym gym)
        {
            var gymObj = _gymTable.Find(x => x.Id == gym.Id).FirstOrDefault();
            if (gymObj == null)
            {
                _gymTable.InsertOne(gym);
            }
            else
            {
                _gymTable.ReplaceOne(x => x.Id == gym.Id, gym);
            }
        }
        /*

        public async Task<List<Gym>> GetGymsWithMemberships()
        {
            var filter = Builders<Gym>.Filter.Eq(g => g.isDeleted, false);

            var lookupStage = new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "TypeOfMemberships" },
        { "localField", "GymId" },
        { "foreignField", "GymId" },
        { "as", "TypeOfMemberships" }
    });

            var projectStage = new BsonDocument("$project", new BsonDocument
    {
        { "TypeOfMemberships.GymId", 0 }
    });

            var pipeline = new[]
            {
        PipelineStageDefinitionBuilder.Match(filter),
        lookupStage,
        projectStage
    };

            var cursor = await _gymTable.AggregateAsync<Gym>(pipeline);
            return await cursor.ToListAsync();
        }
        */


        public async Task<List<Gym>> GetGymsWithMemberships()
        {
            var pipeline = new BsonDocument[]
            {
        new BsonDocument("$match", new BsonDocument("isDeleted", false)),
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "TypeOfMemberships" },
            { "localField", "Id" },
            { "foreignField", "GymId" },
            { "as", "TypeOfMemberships" }
        }),
        new BsonDocument("$project", new BsonDocument
        {
            { "TypeOfMemberships.GymId", 0 }
        })
            };

            var cursor = await _gymTable.AggregateAsync<Gym>(pipeline);
            return await cursor.ToListAsync();
        }




    }
}


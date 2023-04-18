using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class TypeOfMembershipService : ITypeOfMembership
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<TypeOfMembership> _typeOfMembershipTable = null;
        public TypeOfMembershipService() {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _typeOfMembershipTable = _database.GetCollection<TypeOfMembership>("TypeOfMembership");
        }
        public string Delete(string typeOfMembershipId)
        {
            _typeOfMembershipTable.DeleteOne(x => x.Id == typeOfMembershipId);
            return "Deleted";
        }

        public TypeOfMembership GetTypeOfMembership(string typeOfMembershipId)
        {
            return _typeOfMembershipTable.Find(x => x.Id == typeOfMembershipId).FirstOrDefault();
        }

        public List<TypeOfMembership> GetTypeOfMemberships()
        {
           return _typeOfMembershipTable.Find(FilterDefinition<TypeOfMembership>.Empty).ToList();
        }

        public void SaveOrUpdate(TypeOfMembership typeOfMembership)
        {
            var typeOfMembershipObj = _typeOfMembershipTable.Find(x => x.Id == typeOfMembership.Id).FirstOrDefault();
            if (typeOfMembershipObj == null)
            {
                _typeOfMembershipTable.InsertOne(typeOfMembership);
            }
            else
            {
                _typeOfMembershipTable.ReplaceOne(x => x.Id == typeOfMembership.Id, typeOfMembership);
            }
        }
    }
}

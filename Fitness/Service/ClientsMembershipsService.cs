using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class ClientsMembershipsService: IClientsMembershipsService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<ClientsMemberships> _clientsMembershipsTable = null;
        public ClientsMembershipsService()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
			_clientsMembershipsTable = _database.GetCollection<ClientsMemberships>("ClientsMemberships");
        }

		public async Task SaveAsync(ClientsMemberships clientsMemberships)
		{
            if(clientsMemberships != null)
            {
				await _clientsMembershipsTable.InsertOneAsync(clientsMemberships);
			}
		}

		public async Task<List<ClientsMemberships>> GetClientsMembershipsAsync()
		{
			var result = await _clientsMembershipsTable.FindAsync(FilterDefinition<ClientsMemberships>.Empty);
			return result.ToList();
		}
	}
}

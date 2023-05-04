using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class ClientService : IClientService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Client> _clientTable = null;
        public ClientService() {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _clientTable = _database.GetCollection<Client>("Clients");
        }
        public string Delete(string clientId)
        {
            _clientTable.DeleteOne(x => x.Id == clientId);
            return "Deleted";
        }

        public Client GetClient(string clientId)
        {
            return _clientTable.Find(x => x.Id == clientId).FirstOrDefault();
        }

		public async Task<Client> GetClientAsync(string clientId)
		{
			var result = await _clientTable.FindAsync(x => x.Id == clientId);
            return result.FirstOrDefault();
		}

		public List<Client> GetClients()
        {
            return _clientTable.Find(FilterDefinition<Client>.Empty).ToList();
        }

		public async Task<List<Client>> GetClientsAsync()
		{
			var result = await _clientTable.FindAsync(FilterDefinition<Client>.Empty);
            return result.ToList();
		}

		public async Task SaveAsync(Client client)
        {
            client.InsertedByDate = DateTime.Now;
            client.IsDeleted = false;
            await _clientTable.InsertOneAsync(client);
            
        }

        public void SaveOrUpdate(Client client)
        {
            var clientObj = _clientTable.Find(x => x.Id == client.Id).FirstOrDefault();
            if (clientObj == null)
            {
                client.InsertedByDate = DateTime.Now;
                client.IsDeleted = false;
                _clientTable.InsertOne(client);
            }
            else
            {
               _clientTable.ReplaceOne(x => x.Id == client.Id, client);
            }
        }
    }
}

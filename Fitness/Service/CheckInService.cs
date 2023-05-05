using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
	public class CheckInService: ICheckInService
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<CheckIns> _checkInsTable = null;
		public CheckInService()
		{
			MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
			_mongoClient = new MongoClient(settings);
			_database = _mongoClient.GetDatabase("GymDb");
			_checkInsTable = _database.GetCollection<CheckIns>("CheckIns");
		}

		public async Task SaveAsync(CheckIns checkIns)
		{
			checkIns.Date = DateTime.Now;
			await _checkInsTable.InsertOneAsync(checkIns);

		}
	}
}

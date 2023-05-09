using Fitness.Data;
using Fitness.IService;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

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

        public async Task UpdateAsync(ClientsMemberships clientsMemberships)
        {
			var clientsMembershipsObj = _clientsMembershipsTable.FindAsync(x => x.ClientsMembershipsId == clientsMemberships.ClientsMembershipsId);
			if (clientsMembershipsObj.Result != null)
			{
				await _clientsMembershipsTable.ReplaceOneAsync(x => x.ClientsMembershipsId == clientsMemberships.ClientsMembershipsId, clientsMemberships);
			}
		}

		public async Task<List<ClientsMemberships>> GetClientsMembershipsAsync()
		{
			var result = await _clientsMembershipsTable.FindAsync(FilterDefinition<ClientsMemberships>.Empty);
			return result.ToList();
		}

		public string Delete(string clientMembershipId)
		{
			_clientsMembershipsTable.DeleteOne(x => x.ClientsMembershipsId == clientMembershipId);
			return "Deleted";
		}

		public async Task<List<ClientsMemberships>> GetClientAllMembershipsAsync(string clientId)
		{
			var result = await _clientsMembershipsTable.FindAsync(x => x.ClientId == clientId);
			return result.ToList();
		}

        public async Task<ClientsMemberships> GetClientMembershipAsync(string cmId)
        {
            var result = await _clientsMembershipsTable.FindAsync(x => x.ClientsMembershipsId.Equals(cmId));
            return result.First();
        }

		public Task<List<ClientsMembershipsExtended>> SearchClientMembershipDescriptioAsync(string clientId)
		{
            /*var lookupPipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument
                {
                    {"$expr", new BsonDocument
                        {
                            {"$eq", new BsonArray { "$_id", "$$membershipId" } }
                        }
                    }
                }),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", "$MembershipType._id" },
                    { "description", "$MembershipType.Description" }
                })
            };

            return _clientsMembershipsTable.Aggregate()
				.Match(Builders<ClientsMemberships>.Filter.Eq("ClientId", clientId))
				.Lookup("TypeOfMembership","typeOfMembershipId","_id","TypeOfMembership")
                .Unwind("TypeOfMembership")
                .AppendStage<BsonDocument>("{$lookup: {form: 'TypeOfMembership', let:{membershipId: '$MembershipId'}, pipeline: " + lookupPipeline.ToJson() + ", as: 'TypeOfMembership'}}")
				.Match(Builders<TypeOfMembership>.Filter.Regex(x => x.Description, new BsonRegularExpression(searchText, "i"))
				.Project<ClientsMembershipsExtended>( new BsonDocument
				{
					{"_id","$ClientsMemberships._id" },
					{nameof(ClientsMemberships.ClientId), "$ClientsMemberships.ClientId"},
					{nameof(ClientsMemberships.MembershipId), "$ClientsMemberships.MembershipId"},
                    {nameof(ClientsMemberships.DateOfPurchasing), "$ClientsMemberships.DateOfPurchasing"},
                    {nameof(ClientsMemberships.Barcode), "$ClientsMemberships.Barcode"},
					{nameof(ClientsMemberships.CheckInsSoFa), "$ClientsMemberships.CheckInsSoFa"},
                    {nameof(ClientsMemberships.Price), "$ClientsMemberships.Price"},
                    {nameof(ClientsMemberships.Validity), "$ClientsMemberships.Validity"},
                    {nameof(ClientsMemberships.DateOfFirstUse), "$ClientsMemberships.DateOfFirstUse"},
                    {nameof(ClientsMemberships.GymId), "$ClientsMemberships.GymId"},
                    {nameof(ClientsMembershipsExtended.TypeOfMembersip), "$Description"},
                })
				.ToListAsync();*/

            //null a visszateritett ertek 
            var result = _clientsMembershipsTable.Aggregate()
                .Match(Builders<ClientsMemberships>.Filter.Eq("ClientId", clientId))
                .Lookup("TypeOfMembership", "MembershipId", "_id", "TypeOfMembership")
				.Lookup("Gym", "GymId", "_id", "Gym")
				.Project<ClientsMembershipsExtended>(new BsonDocument
                {
                    {"_id","$ClientsMemberships._id" },
                    {nameof(ClientsMemberships.ClientId), "$ClientsMemberships.ClientId"},
                    {nameof(ClientsMemberships.MembershipId), "$ClientsMemberships.MembershipId"},
                    {nameof(ClientsMemberships.DateOfPurchasing), "$ClientsMemberships.DateOfPurchasing"},
                    {nameof(ClientsMemberships.Barcode), "$ClientsMemberships.Barcode"},
                    {nameof(ClientsMemberships.CheckInsSoFa), "$ClientsMemberships.CheckInsSoFa"},
                    {nameof(ClientsMemberships.Price), "$ClientsMemberships.Price"},
                    {nameof(ClientsMemberships.Validity), "$ClientsMemberships.Validity"},
                    {nameof(ClientsMemberships.DateOfFirstUse), "$ClientsMemberships.DateOfFirstUse"},
                    {nameof(ClientsMemberships.GymId), "$ClientsMemberships.GymId"},
                    {nameof(ClientsMembershipsExtended.TypeOfMembersip), "$TypeOfMembership.Description"},
					{nameof(ClientsMembershipsExtended.Gym), "$Gym.Name"},
				})
                .ToListAsync();
            return result;
        }
	}
}

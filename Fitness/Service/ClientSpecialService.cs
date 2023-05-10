using Fitness.Data;
using Fitness.IService;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Syncfusion.Blazor.Data;

namespace Fitness.Service
{
    public class ClientSpecialService : IClientSpecialService
    {

        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Client> _clientTable;
        private IMongoCollection<ClientsMemberships> _clientsMembershipsTable;
        private IMongoCollection<CheckIns> _checkInsTable;

        public ClientSpecialService()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _clientTable = _database.GetCollection<Client>("Clients");
            _clientsMembershipsTable = _database.GetCollection<ClientsMemberships>("ClientsMemberships");
            _checkInsTable = _database.GetCollection<CheckIns>("CheckIns");
        }

        public List<ClientSpecial> GetClientSpecial()
        {
            var query = _clientTable.AsQueryable()
      .GroupJoin(
          _clientsMembershipsTable.AsQueryable(),
          client => client.Id,
          membership => membership.ClientId,
          (client, memberships) => new { Client = client, ClientsMemberships = memberships }
      )
      .SelectMany(
          clientMemberships => clientMemberships.ClientsMemberships.DefaultIfEmpty(),
          (clientMemberships, membership) => new ClientSpecial
          {
              Id = clientMemberships.Client.Id,
              Name = clientMemberships.Client.Name,
              PhoneNr = clientMemberships.Client.PhoneNr,
              Email = clientMemberships.Client.Email,
              IsDeleted = clientMemberships.Client.IsDeleted,
              Photo = clientMemberships.Client.Photo,
              InsertedByDate = clientMemberships.Client.InsertedByDate,
              IdCard = clientMemberships.Client.IdCard,
              Address= clientMemberships.Client.Address,
              AdditionanInformation = clientMemberships.Client.AdditionanInformation,
              ClientMemberships = membership != null ? new List<ClientsMemberships>
              {
                new ClientsMemberships
                {
                    ClientsMembershipsId=membership.ClientsMembershipsId,
                    ClientId=membership.ClientId,
                    MembershipId = membership.ClientId,
                    DateOfPurchasing = membership.DateOfPurchasing,
                    Barcode = membership.Barcode,
                    CheckInsSoFa = membership.CheckInsSoFa,
                    Validity = membership.Validity,
                    DateOfFirstUse = membership.DateOfFirstUse,
                    GymId = membership.GymId
                }
              } : null
          }
      ).ToList();
            var result = query.ToList();
            return result;

        }
    }
}

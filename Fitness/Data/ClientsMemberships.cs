using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Data
{
    public class ClientsMemberships
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string ClientId { get; set; }

        public string MembershipId { get; set; }

        public DateTime DateOfPurchasing { get; set; }

        public string Barcode { get; set; }

        public int CheckInsSoFa { get; set; }

        public float Price { get; set; }

        public bool Validity { get; set; }

        public DateTime DateOfFirstUse { get; set; }

        public string GymId { get;set; }



    }
}

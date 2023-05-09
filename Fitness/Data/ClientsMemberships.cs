using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Data
{
    public class ClientsMemberships
    {
        [BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ClientsMembershipsId { get; set; }
        public string ClientId { get; set; }

        public string MembershipId { get; set; }

        public DateTime DateOfPurchasing { get; set; }

        public string Barcode { get; set; }

        public int CheckInsSoFa { get; set; }

        public double Price { get; set; }

        public bool Validity { get; set; }

        public DateTime DateOfFirstUse { get; set; }

        public string GymId { get;set; }

    }
    public class ClientsMembershipsExtended: ClientsMemberships { 
        public string TypeOfMembersip { get; set; }
        public string Gym { get; set; }
    }

}

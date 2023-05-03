using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fitness.Data
{
	public class CheckIns
	{
		[BsonId]
		public string CheckInId { get; set; } 

		public string ClientId { get; set; }

		public string MembershipId { get; set; }

		public DateTime Date { get; set; }

		public string InsertedByUserId { get; set; }

		public string Barcode { get; set; }

		public string GymId { get; set; }



	}
	//checkIn_id, client_id, membership_id, date, insertedBy_user_id, barcode, gym_id);
}

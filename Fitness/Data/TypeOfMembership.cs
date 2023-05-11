using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Data
{
    public class TypeOfMembership
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;

        public int ValidityInDays { get; set; } = 0;
        public int ValidityInCheckIn { get; set; } = 0;
        public bool isDeleted { get; set; } = false;
 		public string GymId { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[0-2][0-3]:[0-5][0-9]$", ErrorMessage = "Wrong time format.")]
        public TimeSpan FromTime { get; set; } = TimeSpan.Zero;
        [Required]
        [RegularExpression(@"^[0-2][0-3]:[0-5][0-9]$", ErrorMessage = "Wrong time format.")]
        public TimeSpan ToTime { get; set; }= TimeSpan.Zero;
        public int NrOfPossibleUsagesDaily { get; set; } = 0;

        //TypeOfMembership (membership_id, description, price,
        ////validityInDays, validityInCheckIn, is_deleted, gym_id, fromTime, toTime, nrOfPossibleUsagesDaily);
    }
}

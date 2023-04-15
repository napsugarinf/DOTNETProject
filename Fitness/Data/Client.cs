using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Fitness.Data
{
    public class Client
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } =string.Empty;
        public string PhoneNr { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public bool isDeleted { get; set; } = false;
        //public string Photo{ get; set; } = string.Empty;

        //public DateTime Date { get; set; } = DateTime.Now;
        //public string IdCard { get; set; } = string.Empty;
       // public string Address { get; set; } = string.Empty;

        //public string Barcode { get; set; } = string.Empty;
       // public string AdditionanInformation { get; set; } = string.Empty;


        //client_id, name, phone_nr, email, is_deleted, photo, inserted_date, id_card, address, barcode, additional_information
    }
}

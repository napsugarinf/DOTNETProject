using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Data
{
    public class Client
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        [Required]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Client name contains invalid characters.")]
        public string Name { get; set; } =string.Empty;
        [Required]
        [RegularExpression(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}$", ErrorMessage = "Invalid phone number.")]

        public string PhoneNr { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public string Photo{ get; set; } = string.Empty;

        public DateTime InsertedByDate { get; set; } = DateTime.Now;
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{12}$", ErrorMessage = "Client id card contains invalid characters.")]
        public string IdCard { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^[0-9]+\s[a-zA-Z\s\-']{2,}.\s?[a-zA-Z\s\(\),]{2,}$", ErrorMessage = "Wrong address format.")]
        public string Address { get; set; } = string.Empty;

        public string Barcode { get; set; } = string.Empty;
        public string AdditionanInformation { get; set; } = string.Empty;


        //client_id, name, phone_nr, email, is_deleted, photo, inserted_date, id_card, address, barcode, additional_information
    }
}

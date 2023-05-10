using System.ComponentModel.DataAnnotations;

namespace Fitness.Data
{
    public class ClientSpecial : Client
    {
   
       // public List<CheckIns> CheckIns { get; set; }
        public List<ClientsMemberships> ClientMemberships { get; set; }
    }
}

using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientSpecialService
    {
        //Task<List<Client>> GetClientSpecial();
        public List<ClientSpecial> GetClientSpecial();
    }
}

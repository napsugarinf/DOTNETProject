using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientService
    {
        void SaveOrUpdate(Client client);
        Client GetClient(string clientId);
        List<Client> GetClients();

        string Delete(string clientId);

    }
}

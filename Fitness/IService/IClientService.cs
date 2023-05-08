using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientService
    {
        void SaveOrUpdate(Client client);

        Task UpdateAsync(Client client);

        Task SaveAsync(Client client);
        Client GetClient(string clientId);
        Task<Client> GetClientAsync(string clientId);

		List<Client> GetClients();

        Task<List<Client>> GetClientsAsync();

        string Delete(string clientId);

    }
}

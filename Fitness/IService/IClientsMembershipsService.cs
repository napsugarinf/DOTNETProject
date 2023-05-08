using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientsMembershipsService
    {
		Task SaveAsync(ClientsMemberships clientsMemberships);
		Task<List<ClientsMemberships>> GetClientsMembershipsAsync();

		Task<List<ClientsMemberships>> GetClientMembershipsAsync(string clientId);
		string Delete(string clientMembershipId);
	}
}

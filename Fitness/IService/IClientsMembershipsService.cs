using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientsMembershipsService
    {
		Task SaveAsync(ClientsMemberships clientsMemberships);
		Task<List<ClientsMemberships>> GetClientsMembershipsAsync();
		string Delete(string clientMembershipId);
	}
}

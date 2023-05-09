using Fitness.Data;

namespace Fitness.IService
{
    public interface IClientsMembershipsService
    {
		Task SaveAsync(ClientsMemberships clientsMemberships);

		Task UpdateAsync(ClientsMemberships clientsMemberships);
		Task<List<ClientsMemberships>> GetClientsMembershipsAsync();

		Task<List<ClientsMemberships>> GetClientAllMembershipsAsync(string clientId);

        Task<List<ClientsMembershipsExtended>> SearchClientMembershipDescriptioAsync(string clientId);

		Task<ClientsMemberships> GetClientMembershipAsync(string cmId);

        string Delete(string clientMembershipId);
	}
}

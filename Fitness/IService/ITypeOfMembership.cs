using Fitness.Data;

namespace Fitness.IService
{
    public interface ITypeOfMembership
    {

            void SaveOrUpdate(TypeOfMembership typeOfMembership);
            TypeOfMembership GetTypeOfMembership(string typeOfMembershipId);
		    
            Task<TypeOfMembership> GetTypeOfMembershipAsync(string typeOfMembershipId);

            Task<List<TypeOfMembership>> GetTypeOfMembershipsAsync();

		    List<TypeOfMembership> GetTypeOfMemberships();
            string Delete(string typeOfMembershipId);

        }
    }


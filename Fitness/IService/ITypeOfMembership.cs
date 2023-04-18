using Fitness.Data;

namespace Fitness.IService
{
    public interface ITypeOfMembership
    {

            void SaveOrUpdate(TypeOfMembership typeOfMembership);
            TypeOfMembership GetTypeOfMembership(string typeOfMembershipId);
            List<TypeOfMembership> GetTypeOfMemberships();
            string Delete(string typeOfMembershipId);

        }
    }


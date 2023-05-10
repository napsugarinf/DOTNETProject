using Fitness.Data;

namespace Fitness.IService
{
    public interface IGymService
    {
            void SaveOrUpdate(Gym gym);
            Gym GetGym(string gymId);
            List<Gym> GetGyms();
            string Delete(string gymId);
        Task<List<Gym>> GetGymsWithMemberships();


        }
}

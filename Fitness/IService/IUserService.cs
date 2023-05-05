using Fitness.Data;

namespace Fitness.IService
{
    public interface IUserService
    {
        void SaveOrUpdate(User user);

        Task SaveAsync(User user);
        User GetUser(string userId);
        Task<User> GetUserAsync(string userId);

        List<User> GetUsers();

        Task<List<User>> GetUsersAsync();

        string Delete(string userId);
    }
}

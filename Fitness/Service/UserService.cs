using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<User> _userTable = null;

        public UserService()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _userTable = _database.GetCollection<User>("Users");
        }
        public string Delete(string userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userId)
        {
            return _userTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var result = await _userTable.FindAsync(x => x.Id == userId);
            return result.FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _userTable.Find(FilterDefinition<User>.Empty).ToList();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var result = await _userTable.FindAsync(FilterDefinition<User>.Empty);
            return result.ToList();
        }

        public async Task SaveAsync(User user)
        {
            await _userTable.InsertOneAsync(user);
        }

        public void SaveOrUpdate(User user)
        {
            var userObj = _userTable.Find(x => x.Id == user.Id).FirstOrDefault();
            if (userObj == null)
            {
               
                _userTable.InsertOne(user);
            }
            else
            {
                _userTable.ReplaceOne(x => x.Id == user.Id, user);
            }
        }
    }
}

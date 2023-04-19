﻿using Fitness.Data;
using Fitness.IService;
using MongoDB.Driver;

namespace Fitness.Service
{
    public class GymService : IGymService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Gym> _gymTable = null;

        public GymService() {

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://veressnapsugar:3cQB3uuv7HCpCwbN@gymdb.1d0eumj.mongodb.net/?retryWrites=true&w=majority"));
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase("GymDb");
            _gymTable = _database.GetCollection<Gym>("Gyms");
        }
        public string Delete(string gymId)
        {
            _gymTable.DeleteOne(x => x.Id == gymId);
            return "Deleted";
        }

        public Gym GetGym(string gymId)
        {
            return _gymTable.Find(x => x.Id == gymId).FirstOrDefault();
        }

        public List<Gym> GetGyms()
        {
            return _gymTable.Find(FilterDefinition<Gym>.Empty).ToList();
        }

        public void SaveOrUpdate(Gym gym)
        {
            var gymObj = _gymTable.Find(x => x.Id == gym.Id).FirstOrDefault();
            if (gymObj == null)
            {
                _gymTable.InsertOne(gym);
            }
            else
            {
                _gymTable.ReplaceOne(x => x.Id == gym.Id, gym);
            }
        }
    }
}
using MongoDB.Driver;

namespace Certification_System.DAL
{
    public class DbContext
    {
        private MongoClient _mongoClient;
        public IMongoDatabase db;

        public DbContext()
        {
            string _user = "Admin";
            string _password = "vg8Jj6GPhnqS8Kf";
            string _database = "smarthouse";

            string _connectionstring = $"mongodb://{_user}:{_password}@ds040309.mlab.com:40309/{_database}";

            _mongoClient = new MongoClient(_connectionstring);
            db = _mongoClient.GetDatabase(_database);
        }
    }
}
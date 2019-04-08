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
            string _password = "Z4UELk3F9GGLdw5";
            string _database = "smarthouse";

            string _connectionstring = $"mongodb://{_user}:{_password}@ds040309.mlab.com:40309/{_database}";

            _mongoClient = new MongoClient(_connectionstring);
            db = _mongoClient.GetDatabase(_database);
        }
    }
}
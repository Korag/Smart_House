using MongoDB.Driver;

namespace SmartHouse_API.DAL
{
    public class DbContext
    {
        private MongoClient _mongoClient;
        public IMongoDatabase db;

        public DbContext()
        {
            string _user = "Admin";
            string _password = "admin123";
            string _database = "smarthouse_swagger";

            string _connectionstring = $"mongodb://{_user}:{_password}@ds038547.mlab.com:38547/{_database}";

            _mongoClient = new MongoClient(_connectionstring);
            db = _mongoClient.GetDatabase(_database);
        }
    }
}
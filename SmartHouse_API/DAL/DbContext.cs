using MongoDB.Driver;

namespace SmartHouse_API.DAL
{
    public class DbContext
    {
        private MongoClient _mongoClient;
        public IMongoDatabase db;

        public DbContext()
        {
            string _user = "OpenUser";
            string _password = "FLbTnwrUSZ";
            string _database = "smarthouse_swagger";

            string _connectionstring = $"mongodb + srv://{_user}:{_password}@mongodbcluster.wqayz.azure.mongodb.net/{_database}?retryWrites=true&w=majority";
            _mongoClient = new MongoClient(_connectionstring);
            db = _mongoClient.GetDatabase(_database);
        }
    }
}
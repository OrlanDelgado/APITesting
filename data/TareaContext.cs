using MongoDB.Driver;
using TareasApi.Models;

namespace TareasApi.Data
{
    public class TareasContext
    {
        private readonly IMongoDatabase _database;

        public TareasContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Tareas> Tareas => _database.GetCollection<Tareas>("Tareas");
    }
}

using MongoDBCRUDWithRepositoryPattern.Models;

namespace MongoDBCRUDWithRepositoryPattern.Services
{
    public class CarsRepository : BaseMongoRepository<Cars>
    {
        public CarsRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {
        }
    }
}

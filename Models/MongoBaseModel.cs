using MongoDB.Bson;

namespace MongoDBCRUDWithRepositoryPattern.Models
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCRUDWithRepositoryPattern.Models
{
    public class Cars : MongoBaseModel
    {
        [BsonElement("Brand")]
        public string Brand { get; set; }

        [BsonElement("Model")]
        public string Model { get; set; }

        [BsonElement("Year")]
        public int Year { get; set; }
    }
}

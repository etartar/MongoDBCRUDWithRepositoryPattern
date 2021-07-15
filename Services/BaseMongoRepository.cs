using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCRUDWithRepositoryPattern.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCRUDWithRepositoryPattern.Services
{
    public class BaseMongoRepository<T> where T : MongoBaseModel
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public BaseMongoRepository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _mongoCollection = database.GetCollection<T>(collectionName);
        }

        public List<T> GetAll()
        {
            return _mongoCollection.Find(x => true).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public T GetById(string id)
        {
            var documentId = new ObjectId(id);
            return _mongoCollection.Find<T>(x => x.Id == documentId).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var documentId = new ObjectId(id);
            return await _mongoCollection.Find<T>(x => x.Id == documentId).FirstOrDefaultAsync();
        }

        public T Create(T model)
        {
            _mongoCollection.InsertOne(model);
            return model;
        }

        public async Task<T> CreateAsync(T model)
        {
            await _mongoCollection.InsertOneAsync(model);
            return model;
        }

        public void Update(string id, T model)
        {
            var documentId = new ObjectId(id);
            _mongoCollection.ReplaceOne(x => x.Id == documentId, model);
        }

        public async Task UpdateAsync(string id, T model)
        {
            var documentId = new ObjectId(id);
            await _mongoCollection.ReplaceOneAsync(x => x.Id == documentId, model);
        }

        public void Delete(T model)
        {
            _mongoCollection.DeleteOne(x => x.Id == model.Id);
        }

        public async Task DeleteAsync(T model)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == model.Id);
        }

        public void Delete(string id)
        {
            var documentId = new ObjectId(id);
            _mongoCollection.DeleteOne(x => x.Id == documentId);
        }

        public async Task DeleteAsync(string id)
        {
            var documentId = new ObjectId(id);
            await _mongoCollection.DeleteOneAsync(x => x.Id == documentId);
        }
    }
}

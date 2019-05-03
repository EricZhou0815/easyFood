using System.Collections.Generic;
using System.Linq;
using easyFood.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace easyFood.Services
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _categorys;

        public CategoryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("easyFoodDb"));
            var database = client.GetDatabase("easyFoodDb");
            _categorys = database.GetCollection<Category>("Categorys");
        }

        public List<Category> Get()
        {
            return _categorys.Find(category => true).ToList();
        }

        public Category Get(string id)
        {
            return _categorys.Find<Category>(category => category.Id == id).FirstOrDefault();
        }

        public Category Create(Category category)
        {
            _categorys.InsertOne(category);
            return category;
        }

        public void Update(string id, Category categoryIn)
        {
            _categorys.ReplaceOne(category => category.Id == id, categoryIn);
        }

        public void Remove(Category categoryIn)
        {
            _categorys.DeleteOne(category => category.Id == categoryIn.Id);
        }

        public void Remove(string id)
        {
            _categorys.DeleteOne(category => category.Id == id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using easyFood.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace easyFood.Services
{
    public class FoodService
    {
        private readonly IMongoCollection<Food> _foods;

        public FoodService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("easyFoodDb"));
            var database = client.GetDatabase("easyFood");
            _foods = database.GetCollection<Food>("Foods");
        }

        public List<Food> Get()
        {
            return _foods.Find(food => true).ToList();
        }

        public Food Get(string id)
        {
            return _foods.Find<Food>(food => food.Id == id).FirstOrDefault();
        }

        public Food Create(Food food)
        {
            _foods.InsertOne(food);
            return food;
        }

        public void Update(string id, Food foodIn)
        {
            _foods.ReplaceOne(food => food.Id == id, foodIn);
        }

        public void Remove(Food foodIn)
        {
            _foods.DeleteOne(food => food.Id == foodIn.Id);
        }

        public void Remove(string id)
        {
            _foods.DeleteOne(food => food.Id == id);
        }
    }
}
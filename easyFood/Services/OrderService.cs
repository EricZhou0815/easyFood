using System.Collections.Generic;
using System.Linq;
using easyFood.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace easyFood.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("easyFoodDb"));
            var database = client.GetDatabase("easyFoodDb");
            _orders = database.GetCollection<Order>("Orders");
        }

        public List<Order> Get()
        {
            return _orders.Find(order => true).ToList();
        }

        public Order Get(string id)
        {
            return _orders.Find<Order>(order => order.Id == id).FirstOrDefault();
        }

        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void Update(string id, Order orderIn)
        {
            _orders.ReplaceOne(order => order.Id == id, orderIn);
        }

        public void Remove(Order orderIn)
        {
            _orders.DeleteOne(order => order.Id == orderIn.Id);
        }

        public void Remove(string id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }
    }
}
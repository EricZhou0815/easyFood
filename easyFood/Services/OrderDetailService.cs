using System.Collections.Generic;
using System.Linq;
using easyFood.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace easyFood.Services
{
    public class OrderDetailService
    {
        private readonly IMongoCollection<OrderDetail> _orderDetails;

        public OrderDetailService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("easyFoodDb"));
            var database = client.GetDatabase("easyFoodDb");
            _orderDetails = database.GetCollection<OrderDetail>("OrderDetails");
        }

        public List<OrderDetail> Get()
        {
            return _orderDetails.Find(orderDetail => true).ToList();
        }

        public OrderDetail Get(string id)
        {
            return _orderDetails.Find<OrderDetail>(orderDetail => orderDetail.Id == id).FirstOrDefault();
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            _orderDetails.InsertOne(orderDetail);
            return orderDetail;
        }

        public void Update(string id, OrderDetail orderDetailIn)
        {
            _orderDetails.ReplaceOne(orderDetail => orderDetail.Id == id, orderDetailIn);
        }

        public void Remove(OrderDetail orderDetailIn)
        {
            _orderDetails.DeleteOne(orderDetail => orderDetail.Id == orderDetailIn.Id);
        }

        public void Remove(string id)
        {
            _orderDetails.DeleteOne(orderDetail => orderDetail.Id == id);
        }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace easyFood.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Total")]
        public decimal Total { get; set; }

        [BsonElement("GST")]
        public decimal GST { get; set; }
        
        [BsonElement("GrandTotal")]
        public decimal GrandTotal { get; set; }
        public System.DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }  
        public User User {get;set;}
    }
    
}
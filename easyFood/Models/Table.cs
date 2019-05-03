using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace easyFood.Models
{
    public class Table
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}

        [BsonElement("NumberOfPeople")]
        public int NumberOfPeople {get;set;}

        [BsonElement("Status")]
        public string Status {get;set;}

        public User user {get;set;}
        
        public List <Order> Orders {get;set;}
    }
    
}
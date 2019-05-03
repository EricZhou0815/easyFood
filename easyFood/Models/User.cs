using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace easyFood.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}

        [BsonElement("UserName")]
        public string UserName {get;set;}

        [BsonElement("FirstName")]
        public string FirstName {get;set;}

        [BsonElement("LastName")]
        public string LastName {get;set;}

        [BsonElement("Email")]
        public string Email {get;set;}

        [BsonElement("Phone")]
        public string Phone {get;set;}

        [BsonElement("Password")]
        public string Password {get;set;}

        [BsonElement("Birthday")]
        public string Birthday {get;set;}
        
        public List <Order> Orders {get;set;}
    }
    
}
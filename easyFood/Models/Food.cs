using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace easyFood.Models
{
    public class Food
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}

        [BsonElement("Name")]
        public string Name {get;set;}

        [BsonElement("Price")]
        public decimal Price {get;set;}

        [BsonElement("PictureUrl")]
        public string PictureUrl {get;set;}

        [BsonElement("Summary")]
        public string Summary {get;set;}

        [BsonElement("Description")]
        public string Description {get;set;}

        [BsonElement("IsSoldOut")]
        public bool IsSoldOut {get;set;}

        public Category category {get;set;}
    }
    
}
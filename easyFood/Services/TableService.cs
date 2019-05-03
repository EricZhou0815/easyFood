using System.Collections.Generic;
using System.Linq;
using easyFood.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace easyFood.Services
{
    public class TableService
    {
        private readonly IMongoCollection<Table> _tables;

        public TableService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("easyFoodDb"));
            var database = client.GetDatabase("easyFood");
            _tables = database.GetCollection<Table>("Tables");
        }

        public List<Table> Get()
        {
            return _tables.Find(table => true).ToList();
        }

        public Table Get(string id)
        {
            return _tables.Find<Table>(table => table.Id == id).FirstOrDefault();
        }

        public Table Create(Table table)
        {
            _tables.InsertOne(table);
            return table;
        }

        public void Update(string id, Table tableIn)
        {
            _tables.ReplaceOne(table => table.Id == id, tableIn);
        }

        public void Remove(Table tableIn)
        {
            _tables.DeleteOne(table => table.Id == tableIn.Id);
        }

        public void Remove(string id)
        {
            _tables.DeleteOne(table => table.Id == id);
        }
    }
}
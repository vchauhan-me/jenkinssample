using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AzureApiApp.Controllers
{
    public class MongoDbController : ApiController
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoDbController()
        {
            _mongoClient = new MongoClient("mongodb+srv://admin01:admin01@cluster0-cgx4u.azure.mongodb.net/test?retryWrites=true");
            _database = _mongoClient.GetDatabase("newdb");
        }

        // GET api/<controller>
        public string Get()
        {
            var col = _database.GetCollection<BsonDocument>("comptentiaDb");
            
            var documents = col.Find(new BsonDocument()).ToList();

            return JsonConvert.SerializeObject(documents);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
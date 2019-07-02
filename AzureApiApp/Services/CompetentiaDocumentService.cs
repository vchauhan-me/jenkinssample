using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using AzureApiApp.Models;
using MongoDB.Driver;

namespace AzureApiApp.Services
{
    public class CompetentiaDocumentService : ICompetentiaDocumentService
    {
        private readonly IMongoCollection<CompetentiaDoc> _docs;

        #region snippet_CompetentiaDocServiceConstructor
        public CompetentiaDocumentService()
        {
            var client = new MongoClient(WebConfigurationManager.AppSettings["MongoDbConnectionString"]);
            var database = client.GetDatabase(WebConfigurationManager.AppSettings["MongoDatabase"]);
            _docs = database.GetCollection<CompetentiaDoc>("Bullhorn");
        }
        #endregion

        public List<CompetentiaDoc> Get()
        {
            return _docs.Find(CompetentiaDoc => true).ToList();
        }

        public CompetentiaDoc Get(string id)
        {
            return _docs.Find<CompetentiaDoc>(CompetentiaDoc => CompetentiaDoc.Id == id).FirstOrDefault();
        }

        public CompetentiaDoc Create(CompetentiaDoc CompetentiaDoc)
        {
            _docs.InsertOne(CompetentiaDoc);
            return CompetentiaDoc;
        }

        public void Update(string id, CompetentiaDoc CompetentiaDocIn)
        {
            _docs.ReplaceOne(CompetentiaDoc => CompetentiaDoc.Id == id, CompetentiaDocIn);
        }

        public void Remove(CompetentiaDoc CompetentiaDocIn)
        {
            _docs.DeleteOne(CompetentiaDoc => CompetentiaDoc.Id == CompetentiaDocIn.Id);
        }

        public void Remove(string id)
        {
            _docs.DeleteOne(CompetentiaDoc => CompetentiaDoc.Id == id);
        }
    }
}
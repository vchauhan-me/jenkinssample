using CompetentiaSolution.Models;
using CompetentiaSolution.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetentiaSolution.Controllers
{
    public class CompetentiaController : ApiController
    {
        private readonly ICompetentiaDocumentService _competentiaDocumentService;

        public CompetentiaController(ICompetentiaDocumentService CompetentiaDocumentService)
        {
            _competentiaDocumentService = CompetentiaDocumentService;
        }

        [HttpGet]
        public List<CompetentiaDoc> Get()
        {
            return _competentiaDocumentService.Get();
        }

        [HttpGet]
        public CompetentiaDoc Get(string id)
        {
            var CompetentiaDoc = _competentiaDocumentService.Get(id);

            if (CompetentiaDoc != null)
            {
                return CompetentiaDoc;
            }

            return null;
        }

        [HttpPost]
        public HttpResponseMessage Create(CompetentiaDoc CompetentiaDoc)
        {
            try
            {
                _competentiaDocumentService.Create(CompetentiaDoc);

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (MongoException ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.ReasonPhrase = ex.Message;
                return response;
            }
        }

        [HttpPut]
        public void Update(string id, CompetentiaDoc CompetentiaDocIn)
        {
            var CompetentiaDoc = _competentiaDocumentService.Get(id);

            if (CompetentiaDoc != null)
            {
                _competentiaDocumentService.Update(id, CompetentiaDocIn);
            }
        }

        [HttpDelete]
        public void Delete(string id)
        {
            var CompetentiaDoc = _competentiaDocumentService.Get(id);

            if (CompetentiaDoc != null)
            {
                _competentiaDocumentService.Remove(CompetentiaDoc.Id);
            }
        }
    }
}
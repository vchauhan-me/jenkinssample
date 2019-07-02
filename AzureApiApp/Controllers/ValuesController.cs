using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AzureApiApp.Models;
using AzureApiApp.Services;
using Swashbuckle.Swagger.Annotations;

namespace AzureApiApp.Controllers
{
    public class ValuesController : ApiController
    {
        private List<string> listofValues = new List<string> { "value1", "value2", "value3", "value4" };
        private readonly ICompetentiaDocumentService _competentiaDocumentService;

        public ValuesController(ICompetentiaDocumentService competentiaDocumentService)
        {
            this._competentiaDocumentService = competentiaDocumentService;
        }

        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return listofValues;
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string Get(int id)
        {
            return listofValues[id];
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [AllowAnonymous]
        public HttpResponseMessage Post(CompetentiaDoc CompetentiaDoc)
        {
            try
            {
                _competentiaDocumentService.Create(CompetentiaDoc);

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                
                if (ex.Message.Contains("E11000 duplicate key error collection"))
                {
                    response.ReasonPhrase = "DuplicateEntryWithSameId";
                }
                return response;
            }
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<string> Put(int id, [FromBody]string value)
        {
            if (id > -1 && id < listofValues.Count)
            {
                listofValues[id] = value;
                return listofValues;
            }
            return listofValues;
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<string> Delete(int id = -1)
        {
            if (id > -1 && id < listofValues.Count)
            {
                listofValues.RemoveAt(id);
                return listofValues;
            }
            else if (id == -1)
            {
                return new List<string>() { };
            }
            return listofValues;
        }
    }
}

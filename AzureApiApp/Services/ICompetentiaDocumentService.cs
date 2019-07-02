using AzureApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureApiApp.Services
{
    public interface ICompetentiaDocumentService 
    {
        List<CompetentiaDoc> Get();

        CompetentiaDoc Get(string id);

        CompetentiaDoc Create(CompetentiaDoc CompetentiaDoc);

        void Update(string id, CompetentiaDoc CompetentiaDocIn);

        void Remove(CompetentiaDoc CompetentiaDocIn);

        void Remove(string id);
    }
}
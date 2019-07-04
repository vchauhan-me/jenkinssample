using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetentiaSolution.Models;

namespace CompetentiaSolution.Services
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

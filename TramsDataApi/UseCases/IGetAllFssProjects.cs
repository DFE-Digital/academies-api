using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetAllFssProjects
    {
         public IEnumerable<FssProjectResponse> Execute();
    }
}

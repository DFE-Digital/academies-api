using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetAllFssProject
    {
         public IEnumerable<FssProjectResponse> Execute();
    }
}

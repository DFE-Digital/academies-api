using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetAllFssProjects
    {
         public Task<List<FssProjectResponse>> Execute();
    }
}

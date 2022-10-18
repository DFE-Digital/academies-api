using System.Collections.Generic;
using System.Threading.Tasks;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProjectStatuses 
    {
        Task<List<string>> Execute();
    }
}

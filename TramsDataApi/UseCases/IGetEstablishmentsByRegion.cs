using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishmentsByRegion
    {
        public IEnumerable<int> Execute(ICollection<string> region);
    }
}

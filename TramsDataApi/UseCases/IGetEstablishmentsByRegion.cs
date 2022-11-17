using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishmentURNsByRegion
    {
        public IEnumerable<int> Execute(ICollection<string> region);
    }
}

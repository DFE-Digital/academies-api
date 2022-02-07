using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetAllFssProject : IGetAllFssProject
    {
        private readonly IFssProjectGateway _fssProjectGateway;
        public GetAllFssProject(IFssProjectGateway fssProjectGateway)
        {
            _fssProjectGateway = fssProjectGateway;
        }

        public IEnumerable<FssProjectResponse> Execute(int page, int count)
        {
            return _fssProjectGateway.GetAll(page, count).Select(fssProject => FssProjectResponseFactory.Create(fssProject)).ToList();
        }
    }
}

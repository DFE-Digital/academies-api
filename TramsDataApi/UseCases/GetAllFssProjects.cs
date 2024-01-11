using Microsoft.FeatureManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.Services;

namespace TramsDataApi.UseCases
{
    public class GetAllFssProjects : IGetAllFssProjects
    {
        private readonly IFssProjectGateway _fssProjectGateway;
        private readonly MfspApiClient _mfspApiClient;
        private readonly IFeatureManager _featureManager;

        public GetAllFssProjects(
            IFssProjectGateway fssProjectGateway,
            MfspApiClient mfspApiClient,
            IFeatureManager featureManager)
        {
            _fssProjectGateway = fssProjectGateway;
            _mfspApiClient = mfspApiClient;
            _featureManager = featureManager;
        }

        public async Task<List<FssProjectResponse>> Execute()
        {
            var useMfspApi = await _featureManager.IsEnabledAsync("IsGetProjectsFromMfspEnabled");

            if (useMfspApi)
            {
                var mfspProjects = await _mfspApiClient.Get<List<FssProjectResponse>>("/v2/fss/projects");

                return mfspProjects;
            }

            return _fssProjectGateway.GetAll().Select(fssProject => FssProjectResponseFactory.Create(fssProject)).ToList();
        }
    }
}

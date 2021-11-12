using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCaseByUrn
    {
        public ConcernsCaseResponse Execute(int urn);
    }
}
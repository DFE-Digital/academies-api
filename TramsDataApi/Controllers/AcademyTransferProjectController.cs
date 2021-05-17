using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class AcademyTransferProjectController : ControllerBase
    {
        private readonly ICreateAcademyTransferProject _createAcademyTransferProject;
        public AcademyTransferProjectController(ICreateAcademyTransferProject createAcademyTransferProject)
        {
            _createAcademyTransferProject = createAcademyTransferProject;
        }
        
        [HttpPost]
        [Route("academyTransferProject")]
        public ActionResult<AcademyTransferProjectResponse> Create(CreateOrUpdateAcademyTransferProjectRequest request)
        {
            return CreatedAtAction( "Create", _createAcademyTransferProject.Execute(request));
        }
    }
}
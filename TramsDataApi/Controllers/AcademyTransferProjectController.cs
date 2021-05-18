using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using TramsDataApi.Validators;

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
            var validator = new CreateOrUpdateAcademyTransferProjectRequestValidator();
            if (validator.Validate(request).IsValid)
            {
                var createdAcademyTransferProject = _createAcademyTransferProject.Execute(request);
                return CreatedAtAction("Create", createdAcademyTransferProject);
            }

            return BadRequest();
        }
    }
}
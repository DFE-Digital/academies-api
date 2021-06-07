using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        private readonly IGetAcademyTransferProject _getAcademyTransferProject;
        private readonly IUpdateAcademyTransferProject _updateAcademyTransferProject;

        public AcademyTransferProjectController(
            ICreateAcademyTransferProject createAcademyTransferProject,
            IGetAcademyTransferProject getAcademyTransferProject,
            IUpdateAcademyTransferProject updateAcademyTransferProject)
        {
            _createAcademyTransferProject = createAcademyTransferProject;
            _getAcademyTransferProject = getAcademyTransferProject;
            _updateAcademyTransferProject = updateAcademyTransferProject;
        }
        
        [HttpPost]
        [Route("academyTransferProject")]
        public ActionResult<AcademyTransferProjectResponse> Create(AcademyTransferProjectRequest request)
        {
            var validator = new AcademyTransferProjectRequestValidator();
            if (validator.Validate(request).IsValid)
            {
                var createdAcademyTransferProject = _createAcademyTransferProject.Execute(request);
                return CreatedAtAction("Create", createdAcademyTransferProject);
            }

            return BadRequest();
        }

        [HttpPatch]
        [Route("academyTransferProject/{urn}")]
        public ActionResult<AcademyTransferProjectResponse> Update(int urn, AcademyTransferProjectRequest request)
        {
            if (_getAcademyTransferProject.Execute(urn) == null)
            {
                return NotFound();
            }

            var validator = new AcademyTransferProjectRequestValidator();
            if (validator.Validate(request).IsValid)
            {
                var updatedAcademyTransferProject = _updateAcademyTransferProject.Execute(urn, request);
                return Ok(updatedAcademyTransferProject);
            }

            return BadRequest();
        }

        public ActionResult<AcademyTransferProjectResponse> GetByUrn(int urn)
        {
            var academyTransferProject = _getAcademyTransferProject.Execute(urn);
            if (academyTransferProject == null)
            {
                return NotFound();
            }

            return Ok(academyTransferProject);
        }        
    }
}
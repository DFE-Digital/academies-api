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
    [ApiVersion("1.0")]

    public class AcademyTransferProjectController : ControllerBase
    {
        private readonly ICreateAcademyTransferProject _createAcademyTransferProject;
        private readonly IGetAcademyTransferProject _getAcademyTransferProject;
        private readonly IUpdateAcademyTransferProject _updateAcademyTransferProject;
        private readonly IIndexAcademyTransferProjects _indexAcademyTransferProject;

        public AcademyTransferProjectController(
            ICreateAcademyTransferProject createAcademyTransferProject,
            IGetAcademyTransferProject getAcademyTransferProject,
            IUpdateAcademyTransferProject updateAcademyTransferProject,
            IIndexAcademyTransferProjects indexAcademyTransferProjects)
        {
            _createAcademyTransferProject = createAcademyTransferProject;
            _getAcademyTransferProject = getAcademyTransferProject;
            _updateAcademyTransferProject = updateAcademyTransferProject;
            _indexAcademyTransferProject = indexAcademyTransferProjects;
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

        [HttpGet]
        [Route("academyTransferProject/{urn}")]
        public ActionResult<AcademyTransferProjectResponse> GetByUrn(int urn)
        {
            var academyTransferProject = _getAcademyTransferProject.Execute(urn);
            if (academyTransferProject == null)
            {
                return NotFound();
            }

            return Ok(academyTransferProject);
        }
        
        [HttpGet]
        [Route("academyTransferProject")]
        public ActionResult<AcademyTransferProjectResponse> Index([FromQuery(Name="page")]int page = 1)
        {
            return Ok(_indexAcademyTransferProject.Execute(page));
        }
    }
}
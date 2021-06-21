using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.DatabaseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    public class KeyStagePerformanceController : ControllerBase
    {
        private readonly IGetKeyStagePerformanceByUkprn _getKeyStagePerformanceByUkprn;

        public KeyStagePerformanceController(IGetKeyStagePerformanceByUkprn getKeyStagePerformanceByUkprn)
        {
            _getKeyStagePerformanceByUkprn = getKeyStagePerformanceByUkprn;
        }
        
        [HttpGet]
        [Route("phonics/{year}")]
        public ActionResult<List<SipPhonics>> GetPhonicsByYear(string year)
        {
            var phonics = _getKeyStagePerformanceByUkprn.Execute(year);
            if (phonics == null)
            {
                return NotFound();
            }

            return Ok(phonics);
        }
    }
}
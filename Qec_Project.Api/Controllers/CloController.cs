using Microsoft.AspNetCore.Mvc;
using QEC_Project.API.DTOs;
using QEC_Project.API.Services;

namespace Qec_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloController : ControllerBase
    {
        private CLOService _cloService;
        public CloController(CLOService service)
        {
            this._cloService = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateClo(CLODTO clo)
        {
            var res = await this._cloService.CreateClo(clo);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClo(string courseId)
        {
            var res = await this._cloService.GetClo(courseId);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClo(CLODTO clo)
        {
            var res = await this._cloService.UpdateClo(clo);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);
        }

        public async Task<IActionResult> DeleteClo(string id)
        {
            var res = await this._cloService.DeleteClo(id);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);
        }

    }
}

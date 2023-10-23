using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidatesController : ControllerBase
    {
        IVerificationService _verificationService;
        public ValidatesController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }
        [HttpGet("validate")]
        public IActionResult validate([FromQuery]string UId,int doorId)
        {
            var result = _verificationService.Validate(UId,doorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("offlinevalidate")]
        public IActionResult offlineValidate(int doorId)
        {
            var result=_verificationService.OfflineValidate(doorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

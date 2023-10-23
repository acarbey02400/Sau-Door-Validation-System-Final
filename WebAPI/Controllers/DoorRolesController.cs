using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorRolesController : ControllerBase
    {
        IDoorRoleService _doorRoleService;
        public DoorRolesController(IDoorRoleService doorRoleService)
        {
            _doorRoleService=doorRoleService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _doorRoleService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

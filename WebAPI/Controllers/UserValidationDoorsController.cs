using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserValidationDoorsController : ControllerBase
    {
        IUserValidationDoorService _userValidationDoorService;
        public UserValidationDoorsController(IUserValidationDoorService userValidationDoorService)
        {
            _userValidationDoorService=userValidationDoorService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _userValidationDoorService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _userValidationDoorService.getById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        

        [HttpPost("add")]
        public IActionResult Add(UserValidationDoor userValidationDoor)
        {
            var result = _userValidationDoorService.add(userValidationDoor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

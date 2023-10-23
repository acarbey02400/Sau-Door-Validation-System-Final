using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
            IUserService _userService;
            public UsersController(IUserService userService)
            {
                _userService = userService;
            }
            [HttpGet("getall")]
            public IActionResult GetAll()
            {

                var result = _userService.getAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            [HttpGet("getbyid")]
            public IActionResult GetById(int Id)
            {
                var result = _userService.getById(Id);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
        [HttpGet("getbytypeid")]
        public IActionResult GetByTypeId(int TypeId)
        {
            var result = _userService.getByTypeId(TypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getbyuid")]
        public IActionResult GetByUId(string UId)
        {
            var result = _userService.getByUId(UId);
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
            public IActionResult Add(User user)
            {
                var result = _userService.add(user);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

        
        }
    }


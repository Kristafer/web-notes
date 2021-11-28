using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNotesApi.Authorization;
using WebNotesApi.Models.Users;
using WebNotesApplication.Models;
using WebNotesApplication.Services;
using WebNotesData.Entities;

namespace WebNotesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.AuthenticateAsync(_mapper.Map<LoginModel>(model));
            HttpContext.Items["User"] = _mapper.Map<User>(response);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            var response = await _userService.RegisterAsync(_mapper.Map<User>(model));
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return users;
        }

        [Authorize(Role.Admin)]
        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [Authorize(Role.Admin)]
        [HttpPost("[action]/{id:int}")]
        public async Task<ActionResult<List<User>>> ResetPassword(int id)
        {
             await _userService.ResetPassword(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
    }
}

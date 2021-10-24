using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebNotesApi.Authorization;
using WebNotesApi.Models.Users;
using WebNotesApplication.Models;
using WebNotesApplication.Services;
using WebNotesData.Entities;

namespace WebNotesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(_mapper.Map<LoginModel>(model));
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register(RegisterRequest model)
        {
            var response = _userService.Register(_mapper.Map<User>(model));
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}

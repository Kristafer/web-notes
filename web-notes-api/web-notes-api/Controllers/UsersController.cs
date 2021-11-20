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
        private IUserService _userService;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
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

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNotesApi.Authorization;
using WebNotesApi.Models.Notes;
using WebNotesApplication.Services;
using WebNotesData.Entities;

namespace WebNotesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController
    {
        private INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id:int}")]
        public Task<IActionResult<NoteResponse>> Get(int id)
        {
            var response = _noteService.Get(_mapper.Map<LoginModel>(model));
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public Task<IActionResult> Authenticate(AuthenticateRequest model)
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
    }
}

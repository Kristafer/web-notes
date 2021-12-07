using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNotesApi.Authorization;
using WebNotesApi.Models.Notes;
using WebNotesApplication.Models;
using WebNotesApplication.Services;

namespace WebNotesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<NoteResponse>> GetNote(int id)
        {
            var response = await _noteService.GetNote(new SearchNoteModel()
            {
                Id = id
            });

            return _mapper.Map<NoteResponse>(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NoteResponse>>> GetNotes([FromQuery] SearchNoteModel searchNoteModel)
        {
            var response = await _noteService.GetNotes(searchNoteModel);
            var lResponse = _mapper.Map<IEnumerable<NoteResponse>>(response);
            foreach (var note in lResponse)
            {
                note.AllAccessTags = await _noteService.Tags( note.UserId);

            }

            return new OkObjectResult(lResponse);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<NoteResponse>> CreateNote(CreateNoteRequest request)
        {
            var response = await _noteService.CreateNoteAsync(_mapper.Map<CreateNoteModel>(request));

            var lResponse = _mapper.Map<NoteResponse>(response);
            lResponse.AllAccessTags = await _noteService.Tags( lResponse.UserId);

            return new OkObjectResult(lResponse);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<NoteResponse>> UpdateNote(UpdateNoteRequest request)
        {
            var response = await _noteService.UpdateNoteAsync(_mapper.Map<UpdateNoteModel>(request));

            var lResponse = _mapper.Map<NoteResponse>(response);
            lResponse.AllAccessTags = await _noteService.Tags( lResponse.UserId);

            return new OkObjectResult(lResponse);
        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            await _noteService.DeleteNoteAsync(id);

            return new OkResult();
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<NoteResponse>> GetNoteShared(Guid id)
        {
            var response = await _noteService.GetNote(new SearchNoteModel()
            {
                SharedId = id
            });

            var lResponse = _mapper.Map<NoteResponse>(response);
            lResponse.AllAccessTags = await _noteService.Tags( lResponse.UserId);

            return new OkObjectResult(lResponse);
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<Guid> GetNoteSharedId(int id)
        {
            var response = await _noteService.CreateSharedId(id);

            return response;
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<string>>> GetTags(int userId)
        {
            var response = await _noteService.Tags(userId);

            return response;
        }
    }
}
